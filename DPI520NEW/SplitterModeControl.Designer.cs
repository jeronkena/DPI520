namespace DPI520NEW
{
    partial class SplitterModeControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.nudMinP = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudMaxP = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudPointCount = new System.Windows.Forms.NumericUpDown();
            this.lbCurrentSetpoint = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCurrentSetpoint = new System.Windows.Forms.TextBox();
            this.btnPrevP = new System.Windows.Forms.Button();
            this.btnNextP = new System.Windows.Forms.Button();
            this.btnVent = new System.Windows.Forms.Button();
            this.btnControllerOnOff = new System.Windows.Forms.Button();
            this.tbPrevPoint = new System.Windows.Forms.TextBox();
            this.tbNextPoint = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPointCount)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.nudMinP, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.nudMaxP, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.nudPointCount, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbCurrentSetpoint, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.tbCurrentSetpoint, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnPrevP, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.btnNextP, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.btnVent, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.btnControllerOnOff, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.tbPrevPoint, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbNextPoint, 1, 6);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(344, 556);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Мин. давления";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudMinP
            // 
            this.nudMinP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudMinP.DecimalPlaces = 3;
            this.nudMinP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudMinP.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudMinP.Location = new System.Drawing.Point(175, 5);
            this.nudMinP.Maximum = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.nudMinP.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudMinP.Name = "nudMinP";
            this.nudMinP.Size = new System.Drawing.Size(166, 29);
            this.nudMinP.TabIndex = 1;
            this.nudMinP.Value = new decimal(new int[] {
            1050,
            0,
            0,
            196608});
            this.nudMinP.ValueChanged += new System.EventHandler(this.nudMinP_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Макс. давления";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudMaxP
            // 
            this.nudMaxP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudMaxP.DecimalPlaces = 3;
            this.nudMaxP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudMaxP.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudMaxP.Location = new System.Drawing.Point(175, 45);
            this.nudMaxP.Maximum = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.nudMaxP.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudMaxP.Name = "nudMaxP";
            this.nudMaxP.Size = new System.Drawing.Size(166, 29);
            this.nudMaxP.TabIndex = 1;
            this.nudMaxP.Value = new decimal(new int[] {
            10050,
            0,
            0,
            196608});
            this.nudMaxP.ValueChanged += new System.EventHandler(this.nudMaxP_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Точек давления";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudPointCount
            // 
            this.nudPointCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudPointCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudPointCount.Location = new System.Drawing.Point(175, 85);
            this.nudPointCount.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudPointCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudPointCount.Name = "nudPointCount";
            this.nudPointCount.Size = new System.Drawing.Size(166, 29);
            this.nudPointCount.TabIndex = 1;
            this.nudPointCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudPointCount.ValueChanged += new System.EventHandler(this.nudPointCount_ValueChanged);
            // 
            // lbCurrentSetpoint
            // 
            this.lbCurrentSetpoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCurrentSetpoint.AutoSize = true;
            this.lbCurrentSetpoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbCurrentSetpoint.Location = new System.Drawing.Point(3, 228);
            this.lbCurrentSetpoint.Name = "lbCurrentSetpoint";
            this.lbCurrentSetpoint.Size = new System.Drawing.Size(166, 24);
            this.lbCurrentSetpoint.TabIndex = 0;
            this.lbCurrentSetpoint.Text = "Уставка 8/10";
            this.lbCurrentSetpoint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(3, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Предыдущая";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(3, 270);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Следующая";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbCurrentSetpoint
            // 
            this.tbCurrentSetpoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCurrentSetpoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbCurrentSetpoint.Location = new System.Drawing.Point(175, 223);
            this.tbCurrentSetpoint.Name = "tbCurrentSetpoint";
            this.tbCurrentSetpoint.ReadOnly = true;
            this.tbCurrentSetpoint.Size = new System.Drawing.Size(166, 35);
            this.tbCurrentSetpoint.TabIndex = 4;
            this.tbCurrentSetpoint.Text = "8,05";
            this.tbCurrentSetpoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnPrevP
            // 
            this.btnPrevP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPrevP.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnPrevP.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrevP.Location = new System.Drawing.Point(3, 363);
            this.btnPrevP.Name = "btnPrevP";
            this.btnPrevP.Size = new System.Drawing.Size(166, 92);
            this.btnPrevP.TabIndex = 3;
            this.btnPrevP.Text = "Предыдущая точка";
            this.btnPrevP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrevP.UseVisualStyleBackColor = true;
            this.btnPrevP.Click += new System.EventHandler(this.btnPrevP_Click);
            // 
            // btnNextP
            // 
            this.btnNextP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnNextP.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnNextP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNextP.Location = new System.Drawing.Point(175, 363);
            this.btnNextP.Name = "btnNextP";
            this.btnNextP.Size = new System.Drawing.Size(166, 92);
            this.btnNextP.TabIndex = 3;
            this.btnNextP.Text = "Следующая точка";
            this.btnNextP.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnNextP.UseVisualStyleBackColor = true;
            this.btnNextP.Click += new System.EventHandler(this.btnNextP_Click);
            // 
            // btnVent
            // 
            this.btnVent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnVent.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnVent.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVent.Location = new System.Drawing.Point(175, 461);
            this.btnVent.Name = "btnVent";
            this.btnVent.Size = new System.Drawing.Size(166, 92);
            this.btnVent.TabIndex = 3;
            this.btnVent.Text = "Сброс давления";
            this.btnVent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVent.UseVisualStyleBackColor = true;
            this.btnVent.Click += new System.EventHandler(this.btnVent_Click);
            // 
            // btnControllerOnOff
            // 
            this.btnControllerOnOff.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnControllerOnOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnControllerOnOff.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnControllerOnOff.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnControllerOnOff.Location = new System.Drawing.Point(3, 461);
            this.btnControllerOnOff.Name = "btnControllerOnOff";
            this.btnControllerOnOff.Size = new System.Drawing.Size(166, 92);
            this.btnControllerOnOff.TabIndex = 3;
            this.btnControllerOnOff.Text = "Включить контроллер";
            this.btnControllerOnOff.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnControllerOnOff.UseVisualStyleBackColor = true;
            this.btnControllerOnOff.Click += new System.EventHandler(this.btnControllerOnOff_Click);
            // 
            // tbPrevPoint
            // 
            this.tbPrevPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPrevPoint.BackColor = System.Drawing.SystemColors.Control;
            this.tbPrevPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPrevPoint.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbPrevPoint.Location = new System.Drawing.Point(175, 185);
            this.tbPrevPoint.Name = "tbPrevPoint";
            this.tbPrevPoint.ReadOnly = true;
            this.tbPrevPoint.Size = new System.Drawing.Size(166, 29);
            this.tbPrevPoint.TabIndex = 5;
            this.tbPrevPoint.Text = "7,05";
            this.tbPrevPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbNextPoint
            // 
            this.tbNextPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNextPoint.BackColor = System.Drawing.SystemColors.Control;
            this.tbNextPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbNextPoint.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbNextPoint.Location = new System.Drawing.Point(175, 265);
            this.tbNextPoint.Name = "tbNextPoint";
            this.tbNextPoint.ReadOnly = true;
            this.tbNextPoint.Size = new System.Drawing.Size(166, 29);
            this.tbNextPoint.TabIndex = 5;
            this.tbNextPoint.Text = "9,05";
            this.tbNextPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // SplitterModeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SplitterModeControl";
            this.Size = new System.Drawing.Size(350, 562);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPointCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudMinP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudMaxP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudPointCount;
        private System.Windows.Forms.Label lbCurrentSetpoint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbCurrentSetpoint;
        private System.Windows.Forms.Button btnControllerOnOff;
        private System.Windows.Forms.Button btnPrevP;
        private System.Windows.Forms.Button btnNextP;
        private System.Windows.Forms.Button btnVent;
        private System.Windows.Forms.TextBox tbPrevPoint;
        private System.Windows.Forms.TextBox tbNextPoint;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
