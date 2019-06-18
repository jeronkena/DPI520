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

namespace DPI520NEW
{
    public partial class SplitterModeControl : UserControl
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
            tbPrevPoint.Text = (currentPtIndex > 0) ? Math.Round(pPoints[currentPtIndex - 1], MainForm.progState.RoundToDigits).ToString() : "---";
            tbNextPoint.Text = (currentPtIndex < pPoints.Length - 1) ? Math.Round(pPoints[currentPtIndex + 1], MainForm.progState.RoundToDigits).ToString() : "---";
        }



        public SplitterModeControl(Form parentForm)
        {
            InitializeComponent();

            mainFormRef = (MainForm)parentForm;

            mainFormRef.OnPUnitsChanged += new MainForm.PUnitsChangedEventHandler(Control_PUnitsChanged);
            mainFormRef.OnPTypeChanged += new MainForm.PTypeChangedEventHandler(Control_PTypeChanged);
            mainFormRef.OnNewControllerSelected += new MainForm.SelectedControllerChangedEventHandler(Control_NewControllerSelected);

            nudPointCount.Value = 10;
            currentPtIndex = 0;

            if (MainForm.CurrentDPI != null)
            {
                Control_NewControllerSelected(null);
            }
            else
            {
                nudMaxP.DecimalPlaces = MainForm.progState.RoundToDigits;
                nudMaxP.Maximum = 10;
                nudMaxP.Minimum = 0;
                nudMaxP.Value = 0;
                nudMaxP.Increment = 0.1M;

                nudMinP.DecimalPlaces = MainForm.progState.RoundToDigits;
                nudMinP.Maximum = 10;
                nudMinP.Minimum = 0;
                nudMinP.Value = 0;
                nudMinP.Increment = 0.1M;

                UpdatePtLabels();
            }
        }



        private void Control_PUnitsChanged(object source, MainForm.PUnitsChangedEventArgs args)
        {
            double vmin = (double)nudMinP.Value;
            double vmax = (double)nudMaxP.Value;

            nudMaxP.DecimalPlaces = MainForm.progState.RoundToDigits;
            nudMaxP.Maximum = (decimal)PUnitConverter.ConvertP((double)nudMaxP.Maximum, args.OldPUnits, MainForm.progState.CurrentPUnits);
            nudMaxP.Minimum = (decimal)PUnitConverter.ConvertP((double)nudMaxP.Minimum, args.OldPUnits, MainForm.progState.CurrentPUnits);
            nudMaxP.Value = (decimal)PUnitConverter.ConvertP(vmax, args.OldPUnits, MainForm.progState.CurrentPUnits);
            nudMaxP.Increment = Math.Round((nudMaxP.Maximum - nudMaxP.Minimum) / 1000, 1);
            if (nudMaxP.Increment < 0.1M) nudMaxP.Increment = 0.1M;

            nudMinP.DecimalPlaces = MainForm.progState.RoundToDigits;
            nudMinP.Maximum = (decimal)PUnitConverter.ConvertP((double)nudMinP.Maximum, args.OldPUnits, MainForm.progState.CurrentPUnits);
            nudMinP.Minimum = (decimal)PUnitConverter.ConvertP((double)nudMinP.Minimum, args.OldPUnits, MainForm.progState.CurrentPUnits);
            nudMinP.Value = (decimal)PUnitConverter.ConvertP(vmin, args.OldPUnits, MainForm.progState.CurrentPUnits);
            nudMinP.Increment = nudMaxP.Increment;

            UpdatePtLabels();
        }



        private void Control_PTypeChanged(object source)
        {
            double vmin = (double)nudMinP.Value;
            double vmax = (double)nudMaxP.Value;

            if (MainForm.progState.PIsAbsolute)
            {
                nudMaxP.Maximum += (decimal)MainForm.progState.CurrentBarometricP;
                nudMaxP.Minimum += (decimal)MainForm.progState.CurrentBarometricP;
                nudMaxP.Value = (decimal)(vmax + Math.Round(MainForm.progState.CurrentBarometricP, MainForm.progState.RoundToDigits));
                nudMinP.Maximum += (decimal)MainForm.progState.CurrentBarometricP;
                nudMinP.Minimum += (decimal)MainForm.progState.CurrentBarometricP;
                nudMinP.Value = (decimal)(vmin + Math.Round(MainForm.progState.CurrentBarometricP, MainForm.progState.RoundToDigits));
            }
            else
            {
                nudMaxP.Maximum -= (decimal)MainForm.progState.CurrentBarometricP;
                nudMaxP.Minimum -= (decimal)MainForm.progState.CurrentBarometricP;
                nudMaxP.Value = (decimal)(vmax - Math.Round(MainForm.progState.CurrentBarometricP, MainForm.progState.RoundToDigits));
                nudMinP.Maximum -= (decimal)MainForm.progState.CurrentBarometricP;
                nudMinP.Minimum -= (decimal)MainForm.progState.CurrentBarometricP;
                nudMinP.Value = (decimal)(vmin - Math.Round(MainForm.progState.CurrentBarometricP, MainForm.progState.RoundToDigits));
            }

            UpdatePtLabels();
        }



        private void Control_NewControllerSelected(object source)
        {
            // пределы
            nudMaxP.DecimalPlaces = MainForm.progState.RoundToDigits;
            nudMaxP.Maximum = (decimal)MainForm.CurrentDPI.MaximalPressure;
            nudMaxP.Minimum = (decimal)MainForm.CurrentDPI.MinimalPressure;
            nudMaxP.Increment = Math.Round((nudMaxP.Maximum - nudMaxP.Minimum) / 1000, 1);
            if (nudMaxP.Increment < 0.1M) nudMaxP.Increment = 0.1M;

            nudMinP.DecimalPlaces = MainForm.progState.RoundToDigits;
            nudMinP.Maximum = (decimal)MainForm.CurrentDPI.MaximalPressure;
            nudMinP.Minimum = (decimal)MainForm.CurrentDPI.MinimalPressure;
            nudMinP.Increment = nudMaxP.Increment;
            
            // заполняем точки
            pPoints = new double[(int)nudPointCount.Value];
            for (int i = 0; i < pPoints.Length; i++)
                pPoints[i] = (double)(nudMinP.Value + (nudMaxP.Value - nudMinP.Value) / (pPoints.Length - 1) * i);

            // обновляем интерфейсные таблички
            currentPtIndex = 0;
            Control_PTypeChanged(null);

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



        private void nudMinP_ValueChanged(object sender, EventArgs e)
        {
            if (nudMinP.Value > nudMaxP.Value)
            {
                nudMinP.Value = (decimal)pPoints[0];
                mainFormRef.UpdateStatusLabel(Color.DarkRed, "Минимальное давление не может быть больше максимального!");
                return;
            }
            mainFormRef.UpdateStatusLabel(Color.Black, "");
            ChangePoints();           
        }



        private void nudMaxP_ValueChanged(object sender, EventArgs e)
        {
            if (nudMinP.Value > nudMaxP.Value)
            {
                nudMaxP.Value = (decimal)pPoints[pPoints.Length - 1];
                mainFormRef.UpdateStatusLabel(Color.DarkRed, "Минимальное давление не может быть больше максимального!");
                return;
            }
            mainFormRef.UpdateStatusLabel(Color.Black, "");
            ChangePoints();
        }



        private void nudPointCount_ValueChanged(object sender, EventArgs e)
        {
            ChangePoints();
        }



        private void ChangePoints()
        {
            // останавливаем подачу давления
            if (SetPThread != null && SetPThread.IsAlive)
            {
                SetPThread.Abort();
                SetPThread.Join(100);
            }

            if (MainForm.CurrentDPI != null) MainForm.CurrentDPI.SetMeasureMode();

            // заполняем точки
            pPoints = new double[(int)nudPointCount.Value];
            for (int i = 0; i < pPoints.Length; i++)
                pPoints[i] = (double)(nudMinP.Value + (nudMaxP.Value - nudMinP.Value) / (pPoints.Length - 1) * i);

            UpdatePtLabels();
        }
    }
}
