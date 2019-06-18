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

        private Thread SetPThread;
        private Thread DropPThread;

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

            //try
            //{
            //    MainForm.CurrentDPI.SetMeasureMode();
            //    controllerIsOn = false;
            //    mainFormRef.UpdateStatusLabel(Color.Black, "");
            //}
            //catch (Exception exp)
            //{
            //    mainFormRef.UpdateStatusLabel(Color.DarkRed, "ОШИБКА! " + exp.Message);
            //}
        }



        private void SetPressureDrill()
        {
            MainForm.UpdateStatusLabelCallback d = new MainForm.UpdateStatusLabelCallback(mainFormRef.UpdateStatusLabel);
            try
            {
                MainForm.CurrentDPI.SetPressure(pPoints[currentPtIndex], MainForm.progState.PIsAbsolute);
                Invoke(d, Color.Black, "");
            }
            catch (ThreadAbortException)
            {
                Invoke(d, Color.Black, "");
                return;
            }
            catch (Exception exp)
            {
                Invoke(d, Color.DarkRed, "ОШИБКА! " + exp.Message);
            }
        }



        private void DropPressureDrill()
        {
            ChangeButtonStatesCallback dbtns = new ChangeButtonStatesCallback(ChangeButtonStates);
            MainForm.UpdateStatusLabelCallback d = new MainForm.UpdateStatusLabelCallback(mainFormRef.UpdateStatusLabel);
            try
            {
                MainForm.CurrentDPI.Ventilate();
                Invoke(d, Color.Black, "");
            }
            catch (Exception exp)
            {
                Invoke(d, Color.DarkRed, "ОШИБКА! " + exp.Message);
            }
            finally
            {
                Invoke(dbtns, true, true, true, true);
            }
        }



        private void btnControllerOnOff_Click(object sender, EventArgs e)
        {
            // не выбран контроллер
            if (MainForm.CurrentDPI == null)
            {
                controllerIsOn = false;
                mainFormRef.UpdateStatusLabel(Color.DarkRed, "ОШИБКА! Не выбран задатчик давления!");
                return;
            }
            else
            {
                mainFormRef.UpdateStatusLabel(Color.Black, "");
            }

            // контроллер включен
            if (controllerIsOn)
            {
                btnControllerOnOff.Text = "Включить контроллер";
                try
                {
                    // прекращаем подачу давления
                    if (SetPThread != null && SetPThread.IsAlive)
                    {
                        SetPThread.Abort();
                        SetPThread.Join(100);
                    }

                    MainForm.CurrentDPI.SetMeasureMode();
                    controllerIsOn = false;
                    mainFormRef.UpdateStatusLabel(Color.Black, "");
                }
                catch (Exception exp)
                {
                    mainFormRef.UpdateStatusLabel(Color.DarkRed, "ОШИБКА! " + exp.Message);
                }
            }
            else
            {
                btnControllerOnOff.Text = "Выключить контроллер";
                controllerIsOn = true;

                // переходим к задаче давления
                if (SetPThread != null && SetPThread.IsAlive)
                {
                    SetPThread.Abort();
                    SetPThread.Join(100);
                }
                SetPThread = new Thread(SetPressureDrill);
                SetPThread.Start();
            }
        }



        private void btnVent_Click(object sender, EventArgs e)
        {
            if (MainForm.CurrentDPI == null)
            {
                mainFormRef.UpdateStatusLabel(Color.DarkRed, "ОШИБКА! Не выбран задатчик давления!");
                return;
            }
            else
            {
                mainFormRef.UpdateStatusLabel(Color.Black, "");
            }

            ChangeButtonStates(false, false, false, false);

            if (SetPThread != null && SetPThread.IsAlive)
            {
                SetPThread.Abort();
                SetPThread.Join(100);
            }
            DropPThread = new Thread(DropPressureDrill);
            DropPThread.Start();
        }



        private void btnPrevP_Click(object sender, EventArgs e)
        {
            if (currentPtIndex == 0) return;

            // уменьшаем индекс точки
            currentPtIndex--;
            UpdatePtLabels();

            // переходим к задаче давления, если контроллер включен
            if (controllerIsOn)
            {
                if (SetPThread != null && SetPThread.IsAlive)
                {
                    SetPThread.Abort();
                    SetPThread.Join(100);
                }
                SetPThread = new Thread(SetPressureDrill);
                SetPThread.Start();
            }
        }

        private void btnNextP_Click(object sender, EventArgs e)
        {
            if (currentPtIndex == pPoints.Length - 1) return;

            // уменьшаем индекс точки
            currentPtIndex++;
            UpdatePtLabels();

            // переходим к задаче давления, если контроллер включен
            if (controllerIsOn)
            {
                if (SetPThread != null && SetPThread.IsAlive)
                {
                    SetPThread.Abort();
                    SetPThread.Join(100);
                }
                SetPThread = new Thread(SetPressureDrill);
                SetPThread.Start();
            }
        }

        private void btnLoadProfile_Click(object sender, EventArgs e)
        {
          //fleStream fstream = new FileStream(@"")
        }

        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < nudPointsCount.Value; i++) {
                dgvSetpoints.Rows.Add("");
            }
            dgvSetpoints.Rows.Add("");
            FileStream fstream = new FileStream(@"С:\test.txt", FileMode.OpenOrCreate);
            byte[] point = new byte[]
            fstream.Write(pPoints, 0, pPoints.Length);

        }
    }
}
