namespace DPI520
{
    partial class MainForm : System.Windows.Forms.Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.контроллерToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gPIB8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbtnSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbtnGeneralMode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbtnSplitterMode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbtnSetpointMode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tscombUnits = new System.Windows.Forms.ToolStripComboBox();
            this.tscombAG = new System.Windows.Forms.ToolStripComboBox();
            this.tstbControllerParameters = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sslbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tblpControl = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCurrentP = new System.Windows.Forms.TextBox();
            this.tbSetP = new System.Windows.Forms.TextBox();
            this.zgGraph = new ZedGraph.ZedGraphControl();
            this.ticker = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.tscombUnits,
            this.tscombAG,
            this.tstbControllerParameters,
            this.toolStripLabel3,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1018, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.контроллерToolStripMenuItem,
            this.tsbtnSettings,
            this.toolStripSeparator3,
            this.tsbtnExit});
            this.toolStripDropDownButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(105, 22);
            this.toolStripDropDownButton1.Text = "Параметры";
            // 
            // контроллерToolStripMenuItem
            // 
            this.контроллерToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gPIB8ToolStripMenuItem});
            this.контроллерToolStripMenuItem.Name = "контроллерToolStripMenuItem";
            this.контроллерToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.контроллерToolStripMenuItem.Text = "Контроллер";
            this.контроллерToolStripMenuItem.Click += new System.EventHandler(this.контроллерToolStripMenuItem_Click);
            // 
            // gPIB8ToolStripMenuItem
            // 
            this.gPIB8ToolStripMenuItem.Name = "gPIB8ToolStripMenuItem";
            this.gPIB8ToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.gPIB8ToolStripMenuItem.Text = "GPIB::8";
            // 
            // tsbtnSettings
            // 
            this.tsbtnSettings.Name = "tsbtnSettings";
            this.tsbtnSettings.Size = new System.Drawing.Size(168, 22);
            this.tsbtnSettings.Text = "Настройки...";
            this.tsbtnSettings.Click += new System.EventHandler(this.tsbtnSettings_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(165, 6);
            // 
            // tsbtnExit
            // 
            this.tsbtnExit.Name = "tsbtnExit";
            this.tsbtnExit.Size = new System.Drawing.Size(168, 22);
            this.tsbtnExit.Text = "Выход";
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnGeneralMode,
            this.tsbtnSplitterMode,
            this.tsbtnSetpointMode});
            this.toolStripDropDownButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(69, 22);
            this.toolStripDropDownButton2.Text = "Режим";
            // 
            // tsbtnGeneralMode
            // 
            this.tsbtnGeneralMode.CheckOnClick = true;
            this.tsbtnGeneralMode.Name = "tsbtnGeneralMode";
            this.tsbtnGeneralMode.Size = new System.Drawing.Size(197, 22);
            this.tsbtnGeneralMode.Text = "Основной";
            this.tsbtnGeneralMode.Click += new System.EventHandler(this.основнойToolStripMenuItem_Click);
            // 
            // tsbtnSplitterMode
            // 
            this.tsbtnSplitterMode.CheckOnClick = true;
            this.tsbtnSplitterMode.Name = "tsbtnSplitterMode";
            this.tsbtnSplitterMode.Size = new System.Drawing.Size(197, 22);
            this.tsbtnSplitterMode.Text = "Разделитель";
            this.tsbtnSplitterMode.Click += new System.EventHandler(this.tsbtnSplitterMode_Click);
            // 
            // tsbtnSetpointMode
            // 
            this.tsbtnSetpointMode.CheckOnClick = true;
            this.tsbtnSetpointMode.Name = "tsbtnSetpointMode";
            this.tsbtnSetpointMode.Size = new System.Drawing.Size(197, 22);
            this.tsbtnSetpointMode.Text = "Заданные точки";
            this.tsbtnSetpointMode.Click += new System.EventHandler(this.tsbtnSetpointMode_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(75, 22);
            this.toolStripLabel1.Text = "Единицы";
            // 
            // tscombUnits
            // 
            this.tscombUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tscombUnits.Items.AddRange(new object[] {
            "Абс.",
            "Изб."});
            this.tscombUnits.Name = "tscombUnits";
            this.tscombUnits.Size = new System.Drawing.Size(85, 25);
            this.tscombUnits.Text = "кгс/см2";
            this.tscombUnits.TextChanged += new System.EventHandler(this.tscombUnits_TextChanged);
            // 
            // tscombAG
            // 
            this.tscombAG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tscombAG.Items.AddRange(new object[] {
            "Абс.",
            "Изб."});
            this.tscombAG.Name = "tscombAG";
            this.tscombAG.Size = new System.Drawing.Size(75, 25);
            this.tscombAG.Text = "Абс.";
            this.tscombAG.TextChanged += new System.EventHandler(this.tscombAG_TextChanged);
            // 
            // tstbControllerParameters
            // 
            this.tstbControllerParameters.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tstbControllerParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tstbControllerParameters.Name = "tstbControllerParameters";
            this.tstbControllerParameters.ReadOnly = true;
            this.tstbControllerParameters.Size = new System.Drawing.Size(300, 25);
            this.tstbControllerParameters.Text = "12...35 кгс/см2";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(97, 22);
            this.toolStripLabel3.Text = "Контроллер";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslbStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 529);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1018, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sslbStatus
            // 
            this.sslbStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sslbStatus.Name = "sslbStatus";
            this.sslbStatus.Size = new System.Drawing.Size(80, 21);
            this.sslbStatus.Text = "sslbStatus";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tblpControl);
            this.splitContainer1.Panel1MinSize = 350;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel2MinSize = 600;
            this.splitContainer1.Size = new System.Drawing.Size(1018, 504);
            this.splitContainer1.SplitterDistance = 386;
            this.splitContainer1.TabIndex = 3;
            // 
            // tblpControl
            // 
            this.tblpControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblpControl.ColumnCount = 1;
            this.tblpControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblpControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblpControl.Location = new System.Drawing.Point(3, 3);
            this.tblpControl.Name = "tblpControl";
            this.tblpControl.RowCount = 1;
            this.tblpControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblpControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblpControl.Size = new System.Drawing.Size(378, 496);
            this.tblpControl.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbCurrentP, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbSetP, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.zgGraph, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(620, 496);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Текущее давление";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(313, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 48);
            this.label2.TabIndex = 0;
            this.label2.Text = "Заданное давление";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbCurrentP
            // 
            this.tbCurrentP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCurrentP.BackColor = System.Drawing.SystemColors.Control;
            this.tbCurrentP.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbCurrentP.ForeColor = System.Drawing.Color.Blue;
            this.tbCurrentP.Location = new System.Drawing.Point(158, 11);
            this.tbCurrentP.Name = "tbCurrentP";
            this.tbCurrentP.ReadOnly = true;
            this.tbCurrentP.Size = new System.Drawing.Size(149, 38);
            this.tbCurrentP.TabIndex = 1;
            this.tbCurrentP.Text = "1,235";
            this.tbCurrentP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbSetP
            // 
            this.tbSetP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSetP.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSetP.ForeColor = System.Drawing.Color.Blue;
            this.tbSetP.Location = new System.Drawing.Point(468, 11);
            this.tbSetP.Name = "tbSetP";
            this.tbSetP.ReadOnly = true;
            this.tbSetP.Size = new System.Drawing.Size(149, 38);
            this.tbSetP.TabIndex = 1;
            this.tbSetP.Text = "1,235";
            this.tbSetP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // zgGraph
            // 
            this.zgGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.zgGraph, 4);
            this.zgGraph.Location = new System.Drawing.Point(3, 63);
            this.zgGraph.Name = "zgGraph";
            this.zgGraph.ScrollGrace = 0D;
            this.zgGraph.ScrollMaxX = 0D;
            this.zgGraph.ScrollMaxY = 0D;
            this.zgGraph.ScrollMaxY2 = 0D;
            this.zgGraph.ScrollMinX = 0D;
            this.zgGraph.ScrollMinY = 0D;
            this.zgGraph.ScrollMinY2 = 0D;
            this.zgGraph.Size = new System.Drawing.Size(614, 430);
            this.zgGraph.TabIndex = 2;
            // 
            // ticker
            // 
            this.ticker.Tick += new System.EventHandler(this.Timer_OnTick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 555);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = "Программа управления контроллером DPI520";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem tsbtnGeneralMode;
        private System.Windows.Forms.ToolStripMenuItem tsbtnSplitterMode;
        private System.Windows.Forms.ToolStripMenuItem tsbtnSetpointMode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox tscombUnits;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox tstbControllerParameters;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripMenuItem контроллерToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gPIB8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsbtnSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsbtnExit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sslbStatus;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCurrentP;
        private System.Windows.Forms.TextBox tbSetP;
        private ZedGraph.ZedGraphControl zgGraph;
        private System.Windows.Forms.TableLayoutPanel tblpControl;
        private System.Windows.Forms.ToolStripComboBox tscombAG;
        private System.Windows.Forms.Timer ticker;
    }
}

