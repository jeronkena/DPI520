using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSDevice.Data;

namespace DPI520NEW
{
    public partial class SettingsForm : Form
    {
        private ProgramState pStateInit;
        public SettingsForm()
        {
            InitializeComponent();
            pStateInit = new ProgramState(MainForm.progState);
            //            if (MainForm.CurrentDPI != null && MainForm.CurrentDPI.HasBarometricSensor) nudBarometricP.Enabled = false;
        }

        private void nudSetpointPrecision_ValueChanged(object sender, EventArgs e)
        {
            MainForm.progState.CurrentSetptPrecision = (double)nudSetpointPrecision.Value / 100;
        }

        private void nudTimeToSetpoint_ValueChanged(object sender, EventArgs e)
        {
            MainForm.progState.SetptDelay = (int)nudTimeToSetpoint.Value;
        }

        private void nudMeasurementInterval_ValueChanged(object sender, EventArgs e)
        {
            MainForm.progState.ReadPInterval = (int)nudMeasurementInterval.Value;
        }

        private void nudBarometricP_ValueChanged(object sender, EventArgs e)
        {
            MainForm.progState.CurrentBarometricP = PUnitConverter.ConvertP((double)nudBarometricP.Value, PressureUnits.KGS, MainForm.progState.CurrentPUnits);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainForm.progState = new ProgramState(pStateInit);
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            nudSetpointPrecision.Value = (decimal)MainForm.progState.CurrentSetptPrecision * 100;
            nudBarometricP.Value = (decimal)PUnitConverter.ConvertP(MainForm.progState.CurrentBarometricP, MainForm.progState.CurrentPUnits, PressureUnits.KGS);
            nudMeasurementInterval.Value = MainForm.progState.ReadPInterval;
            nudTimeToSetpoint.Value = MainForm.progState.SetptDelay;
            nudGraphTScale.Value = MainForm.progState.TimeLength;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
           
        }

        private void nudGraphTScale_ValueChanged(object sender, EventArgs e)
        {
            MainForm.progState.TimeLength = (int)nudGraphTScale.Value;
        }
    }
}
