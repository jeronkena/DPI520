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
    public partial class SplitterModeControl : UserControl
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
            tbPrevPoint.Text = (currentPtIndex > 0) ? Math.Round(pPoints[currentPtIndex - 1], MainForm.progState.RoundToDigits).ToString() : "---";
            tbNextPoint.Text = (currentPtIndex < pPoints.Length - 1) ? Math.Round(pPoints[currentPtIndex + 1], MainForm.progState.RoundToDigits).ToString() : "---";
            if (controllerIsOn) MainForm.CurrentDPI.SetPressure(pPoints[currentPtIndex], MainForm.progState.PIsAbsolute);
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
            // не меняем реальное давление при смене едениц
            bool controllerIsOnOld = controllerIsOn;
            controllerIsOn = false;

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

            controllerIsOn = controllerIsOnOld;
            UpdatePtLabels();
        }



        private void Control_PTypeChanged(object source)
        {
            // не меняем реальное давление при смене едениц
            bool controllerIsOnOld = controllerIsOn;
            controllerIsOn = false;

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

            controllerIsOn = controllerIsOnOld;
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
                nudMinP.Enabled = false;
                nudMaxP.Enabled = false;
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
            nudMinP.Enabled = true;
            nudMaxP.Enabled = true;
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



        private void nudMinP_ValueChanged(object sender, EventArgs e)
        {
            if ((nudMinP.Value > nudMaxP.Value) && (controllerIsOn))
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
            if ((nudMinP.Value > nudMaxP.Value) && (controllerIsOn))
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
            // заполняем точки
            pPoints = new double[(int)nudPointCount.Value];
            for (int i = 0; i < pPoints.Length; i++)
                pPoints[i] = (double)(nudMinP.Value + (nudMaxP.Value - nudMinP.Value) / (pPoints.Length - 1) * i);

            UpdatePtLabels();
        }
    }
}
