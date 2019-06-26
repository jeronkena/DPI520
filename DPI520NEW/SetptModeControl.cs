using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSDevice;
using CSDevice.Data;
using System.Threading;
using System.IO;

namespace DPI520NEW
{
    public partial class SetptModeControl : UserControl
    {
        // текущий индекс точки давления
        private int currentPtIndex;

        private bool controllerIsOn;

        // точки давления
        private double[] pPoints;

        private MainForm mainFormRef;
        private bool numericUpDown; 

        private delegate void ChangeButtonStatesCallback(bool nextBtn, bool prevBtn, bool conoffBtn, bool ventBtn);

        public void ChangeButtonStates(bool nextBtn, bool prevBtn, bool conoffBtn, bool ventBtn)
        {
            btnNextP.Enabled = nextBtn;
            btnPrevP.Enabled = prevBtn;
            btnControllerOnOff.Enabled = conoffBtn;
            btnVent.Enabled = ventBtn;
        }
        private void UpdatePtLabels()
        {
            lbCurrentSetpoint.Text = string.Format("Уставка {0}/{1}", currentPtIndex + 1, nudPointsCount.Value);
            tbCurrentSetpoint.Text = Math.Round(pPoints[currentPtIndex], MainForm.progState.RoundToDigits).ToString();
            try
            {
                if (dgvSetpoints.Rows.Count != 0) {
                for (int i = 0; i < nudPointsCount.Value; i++)
                {
                    dgvSetpoints.Rows[i].Selected = false;
                }
            }
                dgvSetpoints.Rows[currentPtIndex].Selected = true;
                if (controllerIsOn) MainForm.CurrentDPI.SetPressure(pPoints[currentPtIndex], MainForm.progState.PIsAbsolute);
            }
            catch
            {

            }
        }
        
        public SetptModeControl(Form parentForm)
        {
            InitializeComponent();
            numericUpDown = false;
            pPoints = new double[(int)nudPointsCount.Maximum];
            mainFormRef = (MainForm)parentForm;

            mainFormRef.OnPUnitsChanged += new MainForm.PUnitsChangedEventHandler(Control_PUnitsChanged);
            mainFormRef.OnPTypeChanged += new MainForm.PTypeChangedEventHandler(Control_PTypeChanged);
            mainFormRef.OnNewControllerSelected += new MainForm.SelectedControllerChangedEventHandler(Control_NewControllerSelected);

            nudPointsCount.Value = 10;
            currentPtIndex = 0;

            if (MainForm.CurrentDPI != null)
            {
                Control_NewControllerSelected(null);
            }
            else
            {
                UpdatePtLabels();
            }
            
        }

        private void Control_PUnitsChanged(object source, MainForm.PUnitsChangedEventArgs args)
        {
            for (int i = 0; i < pPoints.Length; i++)
            {
                pPoints[i] = (double)PUnitConverter.ConvertP((double)pPoints[i], args.OldPUnits, MainForm.progState.CurrentPUnits);
            }
            for (int i = 0; i < nudPointsCount.Value; i++)
            {
                dgvSetpoints.Rows[i].Cells[0].Value = Math.Round(((double)PUnitConverter.ConvertP((double)pPoints[i], args.OldPUnits, MainForm.progState.CurrentPUnits)), 1);
            }
            UpdatePtLabels();
        }
        private void Control_PTypeChanged(object source)
        {
            if (MainForm.progState.PIsAbsolute)
            {

            }
            else
            {

            }

            UpdatePtLabels();
        }



        private void Control_NewControllerSelected(object source)
        {
            try
            {
                MainForm.CurrentDPI.SetMeasureMode();
                controllerIsOn = false;
                mainFormRef.UpdateStatusLabel(Color.Black, "");
            }
            catch (Exception exp)
            {
                mainFormRef.UpdateStatusLabel(Color.DarkRed, "ОШИБКА! " + exp.Message);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            MainForm.UpdateColor changeColor = new MainForm.UpdateColor(mainFormRef.ChangeCurrentPColor);
            double accuracy;        // точность
            double differentValues; // разность текущего и установленного давлений

            MainForm.CurrentDPI.SetPressure(pPoints[currentPtIndex], MainForm.progState.PIsAbsolute);

            while (!worker.CancellationPending)
            {
                accuracy = MainForm.CurrentDPI.Accuracy * MainForm.CurrentDPI.MaximalPressure;
                differentValues = Math.Abs(Math.Round(pPoints[currentPtIndex], MainForm.progState.RoundToDigits) - MainForm.CurrentP);
                if (differentValues > accuracy)
                    Invoke(changeColor, 1);
                else
                    Invoke(changeColor, 2);
                Thread.Sleep(500);
            }

            Invoke(changeColor, 0);
            e.Cancel = true;
            return;
        }

        
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MainForm.UpdateStatusLabelCallback d = new MainForm.UpdateStatusLabelCallback(mainFormRef.UpdateStatusLabel);
            if (e.Error != null) Invoke(d, Color.DarkRed, "ОШИБКА! " + e.Error.Message);
            Invoke(d, Color.Black, "");
        }

        
        private void btnControllerOnOff_Click(object sender, EventArgs e)
        {
            // не выбран контроллер
            if (DPIIsNull()) return;

            if (!controllerIsOn) // включаем контроллер
            {
                btnControllerOnOff.Text = "Выключить контроллер";
                controllerIsOn = true;
                if (!backgroundWorker1.IsBusy) backgroundWorker1.RunWorkerAsync();
            }
            else // выключаем контроллер
            {
                backgroundWorker1.CancelAsync();
                offController();
            }
        }

        private void btnVent_Click(object sender, EventArgs e)
    {

        if (DPIIsNull()) return;

        ChangeButtonStates(false, false, false, false);
        backgroundWorker1.CancelAsync();
        MainForm.CurrentDPI.Ventilate();
        offController();
        ChangeButtonStates(true, true, true, true);
    }
    
        private void offController()
        {
         btnControllerOnOff.Text = "Включить контроллер";
         controllerIsOn = false;
        }

        private void btnPrevP_Click_1(object sender, EventArgs e)
        {
            if (currentPtIndex == 0) return;

            // уменьшаем индекс точки
            currentPtIndex--;
            
            UpdatePtLabels();
        }

        private void btnNextP_Click(object sender, EventArgs e)
        {
            if (currentPtIndex == nudPointsCount.Value - 1) return;
            // уменьшаем индекс точки
            currentPtIndex++;
            UpdatePtLabels();
        }
        private bool DPIIsNull()
        {
            if (MainForm.CurrentDPI == null)
            {
                controllerIsOn = false;
                mainFormRef.UpdateStatusLabel(Color.DarkRed, "ОШИБКА! Не выбран задатчик давления!");
                return true;
            }

            mainFormRef.UpdateStatusLabel(Color.Black, "");
            return false;
        }

        private void btnLoadProfile_Click(object sender, EventArgs e)
        {
            numericUpDown = true;
            string patch;
            openFileDialog1.ShowDialog();
            patch = openFileDialog1.FileName;
            if (patch != "") {
                StreamReader streamreader = new StreamReader(patch);
                string str = "";
                int count = 0;
                currentPtIndex = 0;

                dgvSetpoints.Rows.Clear();
                while ((str = streamreader.ReadLine()) != null)
                {
                    // if (count < (int)nudPointsCount.Value) {

                    dgvSetpoints.Rows.Add(str);
                    pPoints[count] = Convert.ToDouble(str);
                    count++;
                    // };
                }
                nudPointsCount.Value = count;
                streamreader.Close();
                UpdatePtLabels();
            }
        }

        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            string filename = saveFileDialog1.FileName;
            if (filename != "")
            {
                FileStream fstream = new FileStream(filename, FileMode.OpenOrCreate);
                StreamWriter streamWriter = new StreamWriter(fstream);
                for (int j = 0; j < nudPointsCount.Value; j++)
                {
                    streamWriter.WriteLine("{0} ", pPoints[j]);
                };
                streamWriter.Close();
                fstream.Close();
            }
        }
 
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvSetpoints_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <= 20 &&  e.RowIndex >= 0)
            {
                pPoints[e.RowIndex] = Convert.ToDouble(dgvSetpoints.Rows[e.RowIndex].Cells[0].Value);
                UpdatePtLabels();
            };
        }

        private void nudPointsCount_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown == false) 
            {
                int rowcount = (int)nudPointsCount.Value - Convert.ToInt32(Convert.ToString(dgvSetpoints.RowCount, 10));
                if (rowcount > 0)
                {
                    dgvSetpoints.Rows.Add(rowcount);
                }
                else
                {
                    for (int i = 0; i < Math.Abs(rowcount); i++)
                    {
                        dgvSetpoints.Rows.Remove(dgvSetpoints.Rows[dgvSetpoints.Rows.Count - 1]);
                    }
                }
            }
            else
            {
                numericUpDown = false;
            }
            UpdatePtLabels();
        }
        
    }
}
