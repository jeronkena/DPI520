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

namespace DPI520
{
    public partial class BasicModeControl : UserControl
    {
        private MainForm mainFormRef;

        //private Thread SetPThread;
        //private Thread DropPThread;

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

            mainFormRef.OnPUnitsChanged += new MainForm.PUnitsChangedEventHandler(Control_PUnitsChanged);
            mainFormRef.OnPTypeChanged += new MainForm.PTypeChangedEventHandler(Control_PTypeChanged);
            mainFormRef.OnNewControllerSelected += new MainForm.SelectedControllerChangedEventHandler(Control_NewControllerSelected);
        }



        private void Control_PUnitsChanged(object source, MainForm.PUnitsChangedEventArgs args)
        {
            double v = (double)nudSetpoint.Value;
            nudSetpoint.DecimalPlaces = MainForm.progState.RoundToDigits;
            nudSetpoint.Maximum = (decimal)PUnitConverter.ConvertP((double)nudSetpoint.Maximum, args.OldPUnits, MainForm.progState.CurrentPUnits);
            nudSetpoint.Minimum = (decimal)PUnitConverter.ConvertP((double)nudSetpoint.Minimum, args.OldPUnits, MainForm.progState.CurrentPUnits);
            nudSetpoint.Value = (decimal)PUnitConverter.ConvertP(v, args.OldPUnits, MainForm.progState.CurrentPUnits);
            nudSetpoint.Increment = Math.Round((nudSetpoint.Maximum - nudSetpoint.Minimum) / 1000, 1);
            if (nudSetpoint.Increment < 0.1M) nudSetpoint.Increment = 0.1M;
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



        //private void SetPressureDrill()
        //{
        //    MainForm.UpdateStatusLabelCallback d = new MainForm.UpdateStatusLabelCallback(mainFormRef.UpdateStatusLabel);
        //    try
        //    {
        //        MainForm.CurrentDPI.SetPressure((double)nudSetpoint.Value, MainForm.progState.PIsAbsolute);
        //        Invoke(d, Color.Black, "");
        //    }
        //    catch (ThreadAbortException)
        //    {
        //        Invoke(d, Color.Black, "");
        //        return;
        //    }
        //    catch (Exception exp)
        //    {
        //        Invoke(d, Color.DarkRed, "ОШИБКА! " + exp.Message);
        //    }
        //}



        //private void DropPressureDrill()
        //{
        //    ChangeButtonStatesCallback dbtns = new ChangeButtonStatesCallback(ChangeButtonStates);
        //    MainForm.UpdateStatusLabelCallback d = new MainForm.UpdateStatusLabelCallback(mainFormRef.UpdateStatusLabel);
        //    try
        //    {
        //        MainForm.CurrentDPI.Ventilate();
        //        Invoke(d, Color.Black, "");
        //    }
        //    catch (Exception exp)
        //    {
        //        Invoke(d, Color.DarkRed, "ОШИБКА! " + exp.Message);
        //    }
        //    finally
        //    {
        //        Invoke(dbtns, true, true);
        //    }
        //}



        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            if (worker.CancellationPending == true)
            {
                e.Cancel = true;
                return;
            }

            MainForm.UpdateStatusLabelCallback d = new MainForm.UpdateStatusLabelCallback(mainFormRef.UpdateStatusLabel);
            Invoke(d, Color.Black, "");
        }



        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MainForm.CurrentDPI.SetPressure((double)nudSetpoint.Value, MainForm.progState.PIsAbsolute);
        }



        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ChangeButtonStatesCallback dbtns = new ChangeButtonStatesCallback(ChangeButtonStates);
            MainForm.UpdateStatusLabelCallback d = new MainForm.UpdateStatusLabelCallback(mainFormRef.UpdateStatusLabel);
            MainForm.CurrentDPI.Ventilate();
            
            if (e.Error != null) Invoke(d, Color.DarkRed, "ОШИБКА! " + e.Error.Message);
            else Invoke(d, Color.Black, "");
            Invoke(dbtns, true, true);
        }



        private void btnGo_Click(object sender, EventArgs e)
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

            //if (SetPThread != null && SetPThread.IsAlive)
            //{
            //    SetPThread.Abort();
            //    SetPThread.Join(100);
            //}
            //SetPThread = new Thread(SetPressureDrill);
            //SetPThread.Start();

            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
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

            ChangeButtonStates(false, false);
            //if (SetPThread != null && SetPThread.IsAlive)
            //{
            //    SetPThread.Abort();
            //    SetPThread.Join(100);
            //}
            //DropPThread = new Thread(DropPressureDrill);
            //DropPThread.Start();

            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                backgroundWorker1.CancelAsync();
            }
        }
    }
}
