using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using CSDevice.Data;
using CSDevice;

namespace DPI520NEW
{
    public partial class BasicModeControl : UserControl
    {
        private MainForm mainFormRef;
        private double setPressure;
        private bool isSetPressure;

        private delegate void ChangeButtonStatesCallback(bool goBtn, bool ventBtn);

        public void ChangeButtonStates(bool goBtn, bool ventBtn)
        {
            btnGo.Enabled = goBtn;
            btnVent.Enabled = ventBtn;
        }



        public BasicModeControl(Form parentForm)
        {
            InitializeComponent();
            mainFormRef = (MainForm)parentForm;
            setPressure = (double)nudSetpoint.Value;
            isSetPressure = false;

            mainFormRef.OnPUnitsChanged += new MainForm.PUnitsChangedEventHandler(Control_PUnitsChanged);
            mainFormRef.OnPTypeChanged += new MainForm.PTypeChangedEventHandler(Control_PTypeChanged);
            mainFormRef.OnNewControllerSelected += new MainForm.SelectedControllerChangedEventHandler(Control_NewControllerSelected);
        }

        private void NudSetpoint_ValueChanged(object sender, EventArgs e)
        {
            setPressure = (double)nudSetpoint.Value;
            if (isSetPressure) MainForm.CurrentDPI.SetPressure((double)nudSetpoint.Value, MainForm.progState.PIsAbsolute);
        }



        private void Control_PUnitsChanged(object source, MainForm.PUnitsChangedEventArgs args)
        {
            // не меняем реальное давление при смене едениц
            bool isSetPressureOld = isSetPressure;
            isSetPressure = false;

            double v = (double)nudSetpoint.Value;
            nudSetpoint.DecimalPlaces = MainForm.progState.RoundToDigits;
            nudSetpoint.Maximum = (decimal)PUnitConverter.ConvertP((double)nudSetpoint.Maximum, args.OldPUnits, MainForm.progState.CurrentPUnits);
            nudSetpoint.Minimum = (decimal)PUnitConverter.ConvertP((double)nudSetpoint.Minimum, args.OldPUnits, MainForm.progState.CurrentPUnits);
            nudSetpoint.Value = (decimal)PUnitConverter.ConvertP(v, args.OldPUnits, MainForm.progState.CurrentPUnits);
            nudSetpoint.Increment = Math.Round((nudSetpoint.Maximum - nudSetpoint.Minimum) / 1000, 1);
            if (nudSetpoint.Increment < 0.1M) nudSetpoint.Increment = 0.1M;

            isSetPressure = isSetPressureOld;
        }



        private void Control_PTypeChanged(object source)
        {
            double v = (double)nudSetpoint.Value;
            if (MainForm.progState.PIsAbsolute)
            {
                nudSetpoint.Maximum += (decimal)MainForm.progState.CurrentBarometricP;
                nudSetpoint.Minimum += (decimal)MainForm.progState.CurrentBarometricP;
                nudSetpoint.Value = (decimal)(v + MainForm.progState.CurrentBarometricP);
            }
            else
            {
                nudSetpoint.Maximum -= (decimal)MainForm.progState.CurrentBarometricP;
                nudSetpoint.Minimum -= (decimal)MainForm.progState.CurrentBarometricP;
                nudSetpoint.Value = (decimal)(v - MainForm.progState.CurrentBarometricP);
            }
        }



        private void Control_NewControllerSelected(object source)
        {
            double v = (double)nudSetpoint.Value;
            nudSetpoint.DecimalPlaces = MainForm.progState.RoundToDigits;
            nudSetpoint.Maximum = (decimal)MainForm.CurrentDPI.MaximalPressure;
            nudSetpoint.Minimum = (decimal)MainForm.CurrentDPI.MinimalPressure;
            nudSetpoint.Value = (decimal)v;
        }



        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            double accuracy;        // точность
            double differentValues; // разность текущего и установленного давлений
            MainForm.UpdateColor changeColor = new MainForm.UpdateColor(mainFormRef.ChangeCurrentPColor);

            MainForm.CurrentDPI.SetPressure(setPressure, MainForm.progState.PIsAbsolute);

            while (!worker.CancellationPending)
            {
                accuracy = MainForm.CurrentDPI.Accuracy * MainForm.CurrentDPI.MaximalPressure;
                differentValues = Math.Abs(setPressure - MainForm.CurrentP);
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



        private void btnGo_Click(object sender, EventArgs e)
        {
            if (DPIIsNull()) return;
            isSetPressure = true;
            ChangeButtonStates(false, true);
            if (!backgroundWorker1.IsBusy) backgroundWorker1.RunWorkerAsync();
        }



        private void btnVent_Click(object sender, EventArgs e)
        {
            if (DPIIsNull()) return;
            ChangeButtonStates(false, false);
            backgroundWorker1.CancelAsync();
            MainForm.CurrentDPI.Ventilate();
            ChangeButtonStates(true, true);
            isSetPressure = false;
        }



        private bool DPIIsNull()
        {
            if (MainForm.CurrentDPI == null)
            {
                mainFormRef.UpdateStatusLabel(Color.DarkRed, "ОШИБКА! Не выбран задатчик давления!");
                return true;
            }

            mainFormRef.UpdateStatusLabel(Color.Black, "");
            return false;
        }
    }
}
