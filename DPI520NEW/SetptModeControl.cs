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
            lbCurrentSetpoint.Text = string.Format("Уставка {0}/{1}", currentPtIndex + 1, pPoints.Length);
            tbCurrentSetpoint.Text = Math.Round(pPoints[currentPtIndex], MainForm.progState.RoundToDigits).ToString();

            //tbPrevPoint.Text = (currentPtIndex > 0) ? Math.Round(pPoints[currentPtIndex - 1], MainForm.progState.RoundToDigits).ToString() : "---";
            //tbNextPoint.Text = (currentPtIndex < pPoints.Length - 1) ? Math.Round(pPoints[currentPtIndex + 1], MainForm.progState.RoundToDigits).ToString() : "---";
            if (controllerIsOn) MainForm.CurrentDPI.SetPressure(pPoints[currentPtIndex], MainForm.progState.PIsAbsolute);
        }



        public SetptModeControl(Form parentForm)
        {
            InitializeComponent();

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
//            nudMaxP.DecimalPlaces = MainForm.progState.RoundToDigits;
//            nudMaxP.Maximum = (decimal)PUnitConverter.ConvertP((double)nudMaxP.Maximum, args.OldPUnits, MainForm.progState.CurrentPUnits);

            UpdatePtLabels();
        }



        private void Control_PTypeChanged(object source)
        {
            if (MainForm.progState.PIsAbsolute)
            {
//                nudMaxP.Maximum += (decimal)MainForm.progState.CurrentBarometricP;
            }
            else
            {
//                nudMaxP.Maximum -= (decimal)MainForm.progState.CurrentBarometricP;
            }

            UpdatePtLabels();
        }



        private void Control_NewControllerSelected(object source)
        {
            // пределы
            //nudMaxP.DecimalPlaces = MainForm.progState.RoundToDigits;
            //nudMaxP.Maximum = (decimal)MainForm.CurrentDPI.MaximalPressure;
            //nudMaxP.Minimum = (decimal)MainForm.CurrentDPI.MinimalPressure;
            //nudMaxP.Increment = Math.Round((nudMaxP.Maximum - nudMaxP.Minimum) / 1000, 1);
            //if (nudMaxP.Increment < 0.1M) nudMaxP.Increment = 0.1M;

            //nudMinP.DecimalPlaces = MainForm.progState.RoundToDigits;
            //nudMinP.Maximum = (decimal)MainForm.CurrentDPI.MaximalPressure;
            //nudMinP.Minimum = (decimal)MainForm.CurrentDPI.MinimalPressure;
            //nudMinP.Increment = nudMaxP.Increment;

            //// заполняем точки
            //pPoints = new double[(int)nudPointCount.Value];
            //for (int i = 0; i < pPoints.Length; i++)
            //    pPoints[i] = (double)(nudMinP.Value + (nudMaxP.Value - nudMinP.Value) / (pPoints.Length - 1) * i);

            //// обновляем интерфейсные таблички
            //currentPtIndex = 0;
            //Control_PTypeChanged(null);

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


        private void btnPrevP_Click(object sender, EventArgs e)
        {
            if (currentPtIndex == 0) return;

            // уменьшаем индекс точки
            currentPtIndex--;
            UpdatePtLabels();
        }

        private void btnNextP_Click(object sender, EventArgs e)
        {
            if (currentPtIndex == pPoints.Length - 1) return;

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
            string patch = @"test.txt";
            FileStream fstream = new FileStream(patch, FileMode.OpenOrCreate);
            StreamWriter streamWriter = new StreamWriter(fstream);
            for (int j = 0; j < nudPointsCount.Value; j++)
            {
                streamWriter.WriteLine("{0} ", j + 1);
            };
            streamWriter.Close();
            fstream.Close();

            openFileDialog1.ShowDialog();
            patch = openFileDialog1.FileName;
            StreamReader streamreader = new StreamReader(patch);
            string str = "";
            pPoints = new double[(int)nudPointsCount.Value];
            int count = 0;
            currentPtIndex = 0;
            while ((str = streamreader.ReadLine()) != null)
            {
                if (count < (int)nudPointsCount.Value) {
                
                dgvSetpoints.Rows.Add(str);
                pPoints[count] = Convert.ToDouble(str);
                count++;
            };
        }
            streamreader.Close();
            UpdatePtLabels();

        }

        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvSetpoints.RowCount; i++)
            {
                dgvSetpoints.Rows.Remove(dgvSetpoints.Rows[i]);
            };

            

           // dgvSetpoints.Rows.Add("");
           // FileStream fstream = new FileStream(@"С:\test.txt", FileMode.OpenOrCreate);
           // byte[] point = new byte[8];
           // fstream.Write(pPoints, 0, pPoints.Length);


        }
        //private void nudPointCount_ValueChanged(object sender, EventArgs e)
        //{
        //    ChangePoints();
        //}



        //private void ChangePoints()
        //{
        //    // заполняем точки
        //    pPoints = new double[(int)nudPointsCount.Value];
        //    for (int i = 0; i < pPoints.Length; i++)
        //        pPoints[i] = (double)i;

        //    UpdatePtLabels();
        //}
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvSetpoints_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

       
    }
}
