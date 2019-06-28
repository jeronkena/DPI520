using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSDevice;
using CSDevice.Data;
using CSDevice.Pressure;
using ZedGraph;

namespace DPI520NEW
{
    /// <summary>
    /// Состояние программы (настройки и ключевые параметры)
    /// </summary>
    public struct ProgramState
    {

        /// <summary>
        /// Режим управления контроллером: 0 - основной; 1 - разделитель; 2 - по точкам
        /// </summary>
        public int CurrentMode;

        /// <summary>
        /// Текущие единицы давления
        /// </summary>
        public PressureUnits CurrentPUnits;

        /// <summary>
        /// Текущая точность уставки, %
        /// </summary>
        public double CurrentSetptPrecision;

        /// <summary>
        /// Текущее атмосферное давление
        /// </summary>
        public double CurrentBarometricP;

        /// <summary>
        /// Текущее время выдержки после уставки давления, сек
        /// </summary>
        public int SetptDelay;

        /// <summary>
        /// Текущий интервал между чтениями с задатчика
        /// </summary>
        public int ReadPInterval;

        /// <summary>
        /// Текущая длина оси Х графика, сек
        /// </summary>
        public int TimeLength;

        /// <summary>
        /// Показатель, что выбран режим абсолютного давления
        /// </summary>
        public bool PIsAbsolute;

        /// <summary>
        /// До скольки знаков округлять
        /// </summary>
        public int RoundToDigits;

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="ps"></param>
        public ProgramState(ProgramState ps)
        {
            CurrentPUnits = ps.CurrentPUnits;
            CurrentBarometricP = ps.CurrentBarometricP;
            CurrentSetptPrecision = ps.CurrentSetptPrecision;
            SetptDelay = ps.SetptDelay;
            ReadPInterval = ps.ReadPInterval;
            CurrentMode = ps.CurrentMode;
            TimeLength = ps.TimeLength;
            PIsAbsolute = ps.PIsAbsolute;
            RoundToDigits = ps.RoundToDigits;
        }

        public void RoundDefine()
        {
            switch(CurrentPUnits)
            {
                case PressureUnits.KGM:
                case PressureUnits.MPA:
                    RoundToDigits = 5; break;
                case PressureUnits.ATM:
                case PressureUnits.BAR:
                case PressureUnits.KGS:
                case PressureUnits.KPA:
                case PressureUnits.MMHG:
                    RoundToDigits = 4; break;
                case PressureUnits.HPA:
                case PressureUnits.PSI:
                    RoundToDigits = 3; break;
                 case PressureUnits.MBAR:
                    RoundToDigits = 2; break;
                case PressureUnits.PA:
                    RoundToDigits = 1; break;
                default:
                    RoundToDigits = 0; break;
            }
        }
    }

    public partial class MainForm : Form
    {
        public class PUnitsChangedEventArgs : EventArgs
        {
            PressureUnits oldUnits;

            public PUnitsChangedEventArgs(PressureUnits pUnits)
            {
                oldUnits = pUnits;
            }

            public PressureUnits OldPUnits
            {
                get { return oldUnits; }
            }
        }

        /// <summary>
        /// Настройки программы
        /// </summary>
        static public ProgramState progState;

        /// <summary>
        /// Показатель, что доступные задатчики найдены
        /// </summary>
        static public bool FoundDPIs;

        /// <summary>
        /// Текущая точка установки
        /// </summary>
        static public double CurrentSetpt;

        /// <summary>
        /// Текущее давление (измеренное)
        /// </summary>
        static public double CurrentP;

        private DateTime currentTime;

        private SettingsForm settingsForm;
        private BasicModeControl basicModeControl;
        private SplitterModeControl splitterModeControl;
        private SetptModeControl setptModeControl;

        /// <summary>
        /// Список доступных контроллеров DPI
        /// </summary>
        public static DruckDPI CurrentDPI;

        /// <summary>
        /// Список точек графика давления
        /// </summary>
        public static RollingPointPairList GraphPoints;

        public delegate void PUnitsChangedEventHandler(object source, PUnitsChangedEventArgs args);
        public delegate void PTypeChangedEventHandler(object source);
        public delegate void SelectedControllerChangedEventHandler(object source);
        public delegate void UpdateStatusLabelCallback(Color col, string txt);
        public delegate void UpdateText(string text);
        public delegate void UpdateColor(int i);
        public delegate void CurrentBPChangedEventHandler(object source);
        /// <summary>
        /// Событие об изменении значения атмосферного давления
        /// </summary>
        public event CurrentBPChangedEventHandler CurrentBarometricPChanged;

        /// <summary>
        /// Событие об изменении единиц давления
        /// </summary>
        public event PUnitsChangedEventHandler OnPUnitsChanged;
       
        /// <summary>
        /// Событие об изменении типа давления
        /// </summary>
        public event PTypeChangedEventHandler OnPTypeChanged;

        /// <summary>
        /// Событие об изменении выбранного контроллера
        /// </summary>
        public event SelectedControllerChangedEventHandler OnNewControllerSelected;



        public MainForm()
        {
            InitializeComponent();
            CurrentBarometricPChanged += new MainForm.CurrentBPChangedEventHandler(CurrentBPChanged);
            progState = new ProgramState();
            progState.CurrentPUnits = PressureUnits.KGS;
            progState.CurrentBarometricP = 1.0;
            progState.CurrentSetptPrecision = 0.02 / 100;
            progState.ReadPInterval = 1;
            progState.SetptDelay = 10;
            progState.TimeLength = 60;
            progState.PIsAbsolute = true;
            progState.RoundDefine();

            FoundDPIs = false;
            CurrentP = 1.00;
            CurrentSetpt = 1.00;

            CurrentDPI = null;

            GraphPoints = new RollingPointPairList(progState.TimeLength / progState.ReadPInterval);

            var myPane = zgGraph.GraphPane;
            myPane.XAxis.Scale.MaxAuto = true;
            ticker.Interval = progState.ReadPInterval * 1000;
        }
        private void CurrentBPChanged(object source)
        {
            MessageBox.Show("gdgfdfghfdg");
        }


        private void tsbtnSettings_Click(object sender, EventArgs e)
        {
            settingsForm = new SettingsForm();
            DialogResult dr = settingsForm.ShowDialog();
            if (dr != DialogResult.OK) return;
            if (CurrentBarometricPChanged != null)
                CurrentBarometricPChanged(this);
            // обновить параметры графика
            if (GraphPoints.Count != progState.TimeLength / progState.ReadPInterval)
            {
                PointPairList tmp = new PointPairList(GraphPoints);
                GraphPoints = new RollingPointPairList(progState.TimeLength / progState.ReadPInterval);
                GraphPoints.Add(tmp);
                zgGraph.GraphPane.CurveList.Clear();
                zgGraph.GraphPane.AddCurve("", GraphPoints, Color.DarkBlue, SymbolType.None);
            }
            // обновить параметры таймера
            ticker.Interval = progState.ReadPInterval * 1000;
        }



        private void основнойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progState.CurrentMode = 0;

            // если режим уже выбран
            if (!tsbtnGeneralMode.Checked)
            {
                tsbtnGeneralMode.Checked = true;
                tsbtnSetpointMode.Checked = false;
                tsbtnSplitterMode.Checked = false;
                return;
            }
            else
            {
                // оставляем отмеченным только его
                tsbtnSetpointMode.Checked = false;
                tsbtnSplitterMode.Checked = false;

                // уничтожаем контрол
                Control tmp = tblpControl.GetControlFromPosition(0, 0);
                if (tmp != null)
                {
                    if (tmp != basicModeControl) tblpControl.Controls.Remove(tmp);
                    else return;
                }

                // создаём контрол
                basicModeControl = new BasicModeControl(this);
                tblpControl.Controls.Add(basicModeControl);
                basicModeControl.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                basicModeControl.Location = new Point(3, 3);
            }
        }



        private void tsbtnSplitterMode_Click(object sender, EventArgs e)
        {
            progState.CurrentMode = 1;

            // если режим уже выбран
            if (!tsbtnSplitterMode.Checked)
            {
                tsbtnSplitterMode.Checked = true;
                tsbtnSetpointMode.Checked = false;
                tsbtnGeneralMode.Checked = false;
                return;
            }
            else
            {
                // оставляем отмеченным только его
                tsbtnSetpointMode.Checked = false;
                tsbtnGeneralMode.Checked = false;

                // уничтожаем контрол
                Control tmp = tblpControl.GetControlFromPosition(0, 0);
                if (tmp != null)
                {
                    if (tmp != splitterModeControl) tblpControl.Controls.Remove(tmp);
                    else return;
                }

                // создаём контрол
                splitterModeControl = new SplitterModeControl(this);
                tblpControl.Controls.Add(splitterModeControl);
                splitterModeControl.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                splitterModeControl.Location = new Point(3, 3);
            }
        }



        private void tsbtnSetpointMode_Click(object sender, EventArgs e)
        {
            progState.CurrentMode = 2;

            // если режим уже выбран
            if (!tsbtnSetpointMode.Checked)
            {
                tsbtnSplitterMode.Checked = false;
                tsbtnSetpointMode.Checked = true;
                tsbtnGeneralMode.Checked = false;
                return;
            }
            else
            {
                // оставляем отмеченным только его
                tsbtnSplitterMode.Checked = false;
                tsbtnGeneralMode.Checked = false;

                // уничтожаем контрол
                Control tmp = tblpControl.GetControlFromPosition(0, 0);
                if (tmp != null)
                {
                    if (tmp != setptModeControl) tblpControl.Controls.Remove(tmp);
                    else return;
                }

                // создаём контрол
                setptModeControl = new SetptModeControl(this);
                tblpControl.Controls.Add(setptModeControl);
                setptModeControl.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                setptModeControl.Location = new Point(3, 3);
            }
        }



        private void MainForm_Load(object sender, EventArgs e)
        {
            // добавляем список единиц
            tscombUnits.Items.Clear();
            int[] enumP = (int[])Enum.GetValues(typeof(PressureUnits));
            for (int i = 0; i < enumP.Length; i++)
            {
                if ((PressureUnits)enumP[i] == PressureUnits.NA) continue;
                tscombUnits.Items.Add(PUnitConverter.PUnitToString((PressureUnits)enumP[i]));
            }


            FindDPIInstruments();

            progState.CurrentMode = 0;
            tsbtnGeneralMode.Checked = true;

            basicModeControl = new BasicModeControl(this);
            tblpControl.Controls.Add(basicModeControl);
            basicModeControl.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            basicModeControl.Location = new Point(3, 3);

            // график
            zgGraph.GraphPane.Title.Text = "P(t)";
            zgGraph.GraphPane.XAxis.Title.Text = "t, сек";
            zgGraph.GraphPane.YAxis.Title.Text = string.Format("P, {0}", PUnitConverter.PUnitToString(progState.CurrentPUnits));

        }



        private void контроллерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindDPIInstruments();
        }



        // поиск контроллеров DPI
        private void FindDPIInstruments()
        {
            контроллерToolStripMenuItem.DropDownItems.Clear();

            // создаём элемент списка, отвечающий за текущий контроллер
            if (CurrentDPI != null)
            {
                ToolStripMenuItem tsItem = new ToolStripMenuItem(CurrentDPI.ConnectString);
                tsItem.CheckOnClick = true;
                tsItem.Click += new EventHandler(tsbtnSelectController_Click);
                tsItem.Checked = true;
                контроллерToolStripMenuItem.DropDownItems.Add(tsItem);
            }

            // находим другие инструменты
            string[] foundInstr = CSDeviceBase.SearchInstruments();

            for (int i = 0; i<foundInstr.Length; i++)
            {
                // пропускаем активный задатчик 
                if (CurrentDPI != null && CurrentDPI.ConnectString == foundInstr[i]) continue;

                // проверяем тип задатчика
                CSDeviceBase currentDev = CSDeviceBase.SetInstrumentType(foundInstr[i]);
                if (currentDev.TypeOfDevice != DeviceType.PRESSURE_CONTROLLER_DPI)
                {
                    currentDev.Close();
                    continue;
                }
                else
                {
                    currentDev.Close();

                    // добавляем элемент
                    ToolStripMenuItem tsItem = new ToolStripMenuItem(foundInstr[i]);
                    tsItem.CheckOnClick = true;
                    tsItem.Click += new EventHandler(tsbtnSelectController_Click);
                    tsItem.Checked = false;
                    контроллерToolStripMenuItem.DropDownItems.Add(tsItem);
                }
            }

            if (контроллерToolStripMenuItem.DropDownItems.Count < 1)
            {
                MessageBox.Show("Системе не удалось найти подключенных контроллеров DPI 520!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FoundDPIs = false;
                CurrentDPI = null;
            }
            else FoundDPIs = true;
        }



        private void tsbtnSelectController_Click(object sender, EventArgs e)
        {
            // если выбран тот же контроллер
            if (!((ToolStripMenuItem)sender).Checked)
            {
                foreach (ToolStripMenuItem t in контроллерToolStripMenuItem.DropDownItems) t.Checked = false;
                ((ToolStripMenuItem)sender).Checked = true;
                if (CurrentDPI == null)
                {
                    ticker.Stop();
                    NewPCSelected(((ToolStripMenuItem)sender).Text);
                }
                return;
            }
            else
            {
                ticker.Stop();
                foreach (ToolStripMenuItem t in контроллерToolStripMenuItem.DropDownItems) t.Checked = false;
                ((ToolStripMenuItem)sender).Checked = true;
                if (CurrentDPI == null)
                {
                    NewPCSelected(((ToolStripMenuItem)sender).Text);
                    return;
                }
                if (CurrentDPI != null && CurrentDPI.ConnectString != ((ToolStripMenuItem)sender).Text)
                {
                    DialogResult dr = MessageBox.Show("Уверены, что хотите сменить задатчик?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr != DialogResult.Yes) return;
                    CurrentDPI.Close();
                    NewPCSelected(((ToolStripMenuItem)sender).Text);
                };
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void MonitorPressure(object source, PressureChangedEventArgs args)
        {
            CurrentP = args.PValue;
            Invoke(new UpdateText((s) => tbCurrentP.Text = s), Math.Round(CurrentP, progState.RoundToDigits).ToString());

            CurrentSetpt = args.SetptValue;
            Invoke(new UpdateText((s) => tbSetP.Text = s), Math.Round(CurrentSetpt, progState.RoundToDigits).ToString());

            TimeSpan tt = DateTime.Now - currentTime;
            
            GraphPoints.Add(new PointPair(tt.TotalSeconds, CurrentP));
            zgGraph.AxisChange();
            zgGraph.Invalidate();
        }





        private void Timer_OnTick(object sender, EventArgs args)
        {
            if (CurrentDPI != null) CurrentDPI.GetPressure(progState.PIsAbsolute);
        }



        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ticker.Stop();
            if (CurrentDPI != null) CurrentDPI.Close();
        }



        private void NewPCSelected(string conStr)
        {
            CurrentDPI = new DruckDPI(conStr, progState.CurrentSetptPrecision, progState.SetptDelay);
            CurrentDPI.PressureUpdated += new DruckDPI.PressureChangedEventHandler(MonitorPressure);
            CurrentDPI.SelectUnits(progState.CurrentPUnits);
            tstbControllerParameters.Text = CurrentDPI.GetParameterString();

            // вызываем событие
            OnNewControllerSelected?.Invoke(this);

            zgGraph.GraphPane.CurveList.Clear();
            zgGraph.GraphPane.AddCurve(conStr, GraphPoints, Color.DarkBlue, SymbolType.None);

            // сбрасываем записи об ошибках (если они были)
            UpdateStatusLabel(Color.Black, "");

            // Уставнавливаем в DPI атмосферное давление
            CurrentDPI.BarometricP = progState.CurrentBarometricP;

            // запускаем таймер
            ticker.Start();

            currentTime = DateTime.Now;
        }



        private void tscombAG_TextChanged(object sender, EventArgs e)
        {
            // меняем режим
            progState.PIsAbsolute = !progState.PIsAbsolute;

            // 
            if (progState.PIsAbsolute)
            {
                CurrentP += progState.CurrentBarometricP;
                tbCurrentP.Text = Math.Round(CurrentP, progState.RoundToDigits).ToString();
                CurrentSetpt += progState.CurrentBarometricP;
                tbSetP.Text = Math.Round(CurrentSetpt, progState.RoundToDigits).ToString();

                // преобразуем точки графика в новую систему отсчёта давления
                for (int i = 0; i < GraphPoints.Count; i++)
                    GraphPoints[i].Y += progState.CurrentBarometricP;
            }
            else
            {
                CurrentP -= progState.CurrentBarometricP;
                tbCurrentP.Text = Math.Round(CurrentP, progState.RoundToDigits).ToString();
                CurrentSetpt -= progState.CurrentBarometricP;
                tbSetP.Text = Math.Round(CurrentSetpt, progState.RoundToDigits).ToString();

                // преобразуем точки графика в новую систему отсчёта давления
                for (int i = 0; i < GraphPoints.Count; i++)
                    GraphPoints[i].Y -= progState.CurrentBarometricP;
            }

            zgGraph.AxisChange();
            zgGraph.Invalidate();

            OnPTypeChanged?.Invoke(this);
        }

        private void tscombUnits_TextChanged(object sender, EventArgs e)
        {
            // останавливаем таймер для предотвращения скачков на графике из-за смены едениц давления
            ticker.Stop();

            Cursor.Current = Cursors.WaitCursor;

            PressureUnits oldUnits = progState.CurrentPUnits;
            // меняем текущие единицы давления
            progState.CurrentPUnits = PUnitConverter.StringToPUnit(tscombUnits.Text);
            // обновляем количество знаков для округления
            progState.RoundDefine();

            // меняем единицы давления на форме
            CurrentP = PUnitConverter.ConvertP(CurrentP, oldUnits, progState.CurrentPUnits);
            tbCurrentP.Text = Math.Round(CurrentP, progState.RoundToDigits).ToString();
            CurrentSetpt = PUnitConverter.ConvertP(CurrentSetpt, oldUnits, progState.CurrentPUnits);
            tbSetP.Text = Math.Round(CurrentSetpt, progState.RoundToDigits).ToString();
            progState.CurrentBarometricP = PUnitConverter.ConvertP(progState.CurrentBarometricP, oldUnits, progState.CurrentPUnits);

            try
            {
                // меняем единицы задатчика давления
                if (CurrentDPI != null)
                {
                    CurrentDPI.SelectUnits(progState.CurrentPUnits);
                    // перечитываем строку параметров
                    tstbControllerParameters.Text = CurrentDPI.GetParameterString();
                }

                // меняем параметры графика
                zgGraph.GraphPane.YAxis.Title.Text = string.Format("P, {0}", PUnitConverter.PUnitToString(progState.CurrentPUnits));

                // преобразуем точки графика к новым единицам давления
                for (int i = 0; i < GraphPoints.Count; i++)
                    GraphPoints[i].Y = PUnitConverter.ConvertP(GraphPoints[i].Y, oldUnits, progState.CurrentPUnits);

                zgGraph.AxisChange();
                zgGraph.Invalidate();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // вызываем событие для других классов
            PUnitsChangedEventArgs pArgs = new PUnitsChangedEventArgs(oldUnits);
            OnPUnitsChanged?.Invoke(this, pArgs);
            
            Cursor.Current = Cursors.Default;

            ticker.Start();
        }


        public void UpdateStatusLabel(Color col, string txt)
        {
            sslbStatus.ForeColor = col;
            sslbStatus.Text = txt;
        }

        public void ChangeCurrentPColor(int i)
        {
            switch (i)
            {
                case 0: tbCurrentP.ForeColor = Color.Black; break;
                case 1: tbCurrentP.ForeColor = Color.Blue; break;
                case 2: tbCurrentP.ForeColor = Color.Green; break;
                default: tbCurrentP.ForeColor = Color.Black; break;
            }
        }

        private void tscombAG_Click(object sender, EventArgs e)
        {

        }
    }
}
