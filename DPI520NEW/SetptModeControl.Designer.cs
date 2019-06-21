namespace DPI520NEW
{
    partial class SetptModeControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnPrevP = new System.Windows.Forms.Button();
            this.btnNextP = new System.Windows.Forms.Button();
            this.lbCurrentSetpoint = new System.Windows.Forms.Label();
            this.tbCurrentSetpoint = new System.Windows.Forms.TextBox();
            this.btnLoadProfile = new System.Windows.Forms.Button();
            this.btnSaveProfile = new System.Windows.Forms.Button();
            this.btnVent = new System.Windows.Forms.Button();
            this.btnControllerOnOff = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nudPointsCount = new System.Windows.Forms.NumericUpDown();
            this.dgvSetpoints = new System.Windows.Forms.DataGridView();
            this.ColumnSetpt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPointsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSetpoints)).BeginInit();
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
            this.tableLayoutPanel1.Controls.Add(this.btnPrevP, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnNextP, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.lbCurrentSetpoint, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbCurrentSetpoint, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnLoadProfile, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnSaveProfile, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnVent, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnControllerOnOff, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.nudPointsCount, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvSetpoints, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(344, 556);
            this.tableLayoutPanel1.TabIndex = 1;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // btnPrevP
            // 
            this.btnPrevP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPrevP.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnPrevP.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrevP.Location = new System.Drawing.Point(3, 439);
            this.btnPrevP.Name = "btnPrevP";
            this.btnPrevP.Size = new System.Drawing.Size(166, 54);
            this.btnPrevP.TabIndex = 3;
            this.btnPrevP.Text = "Предыдущая точка";
            this.btnPrevP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrevP.UseVisualStyleBackColor = true;
            // 
            // btnNextP
            // 
            this.btnNextP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnNextP.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnNextP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNextP.Location = new System.Drawing.Point(175, 439);
            this.btnNextP.Name = "btnNextP";
            this.btnNextP.Size = new System.Drawing.Size(166, 54);
            this.btnNextP.TabIndex = 3;
            this.btnNextP.Text = "Следующая точка";
            this.btnNextP.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnNextP.UseVisualStyleBackColor = true;
            this.btnNextP.Click += new System.EventHandler(this.btnNextP_Click);
            // 
            // lbCurrentSetpoint
            // 
            this.lbCurrentSetpoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCurrentSetpoint.AutoSize = true;
            this.lbCurrentSetpoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbCurrentSetpoint.Location = new System.Drawing.Point(3, 374);
            this.lbCurrentSetpoint.Name = "lbCurrentSetpoint";
            this.lbCurrentSetpoint.Size = new System.Drawing.Size(166, 24);
            this.lbCurrentSetpoint.TabIndex = 0;
            this.lbCurrentSetpoint.Text = "Уставка 8/10";
            this.lbCurrentSetpoint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbCurrentSetpoint
            // 
            this.tbCurrentSetpoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCurrentSetpoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbCurrentSetpoint.Location = new System.Drawing.Point(175, 369);
            this.tbCurrentSetpoint.Name = "tbCurrentSetpoint";
            this.tbCurrentSetpoint.ReadOnly = true;
            this.tbCurrentSetpoint.Size = new System.Drawing.Size(166, 35);
            this.tbCurrentSetpoint.TabIndex = 4;
            this.tbCurrentSetpoint.Text = "8,05";
            this.tbCurrentSetpoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnLoadProfile
            // 
            this.btnLoadProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLoadProfile.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnLoadProfile.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoadProfile.Location = new System.Drawing.Point(3, 279);
            this.btnLoadProfile.Name = "btnLoadProfile";
            this.btnLoadProfile.Size = new System.Drawing.Size(166, 54);
            this.btnLoadProfile.TabIndex = 3;
            this.btnLoadProfile.Text = "Загрузить набор";
            this.btnLoadProfile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLoadProfile.UseVisualStyleBackColor = true;
            this.btnLoadProfile.Click += new System.EventHandler(this.btnLoadProfile_Click);
            // 
            // btnSaveProfile
            // 
            this.btnSaveProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveProfile.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSaveProfile.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveProfile.Location = new System.Drawing.Point(175, 279);
            this.btnSaveProfile.Name = "btnSaveProfile";
            this.btnSaveProfile.Size = new System.Drawing.Size(166, 54);
            this.btnSaveProfile.TabIndex = 3;
            this.btnSaveProfile.Text = "Сохранить набор";
            this.btnSaveProfile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveProfile.UseVisualStyleBackColor = true;
            this.btnSaveProfile.Click += new System.EventHandler(this.btnSaveProfile_Click);
            // 
            // btnVent
            // 
            this.btnVent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnVent.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnVent.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVent.Location = new System.Drawing.Point(175, 499);
            this.btnVent.Name = "btnVent";
            this.btnVent.Size = new System.Drawing.Size(166, 54);
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
            this.btnControllerOnOff.Location = new System.Drawing.Point(3, 499);
            this.btnControllerOnOff.Name = "btnControllerOnOff";
            this.btnControllerOnOff.Size = new System.Drawing.Size(166, 54);
            this.btnControllerOnOff.TabIndex = 3;
            this.btnControllerOnOff.Text = "Включить контроллер";
            this.btnControllerOnOff.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnControllerOnOff.UseVisualStyleBackColor = true;
            this.btnControllerOnOff.Click += new System.EventHandler(this.btnControllerOnOff_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество точек";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudPointsCount
            // 
            this.nudPointsCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudPointsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudPointsCount.Location = new System.Drawing.Point(175, 3);
            this.nudPointsCount.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudPointsCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudPointsCount.Name = "nudPointsCount";
            this.nudPointsCount.Size = new System.Drawing.Size(166, 26);
            this.nudPointsCount.TabIndex = 5;
            this.nudPointsCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // dgvSetpoints
            // 
            this.dgvSetpoints.AllowUserToAddRows = false;
            this.dgvSetpoints.AllowUserToDeleteRows = false;
            this.dgvSetpoints.AllowUserToResizeColumns = false;
            this.dgvSetpoints.AllowUserToResizeRows = false;
            this.dgvSetpoints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSetpoints.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSetpoints.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSetpoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSetpoints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSetpt});
            this.tableLayoutPanel1.SetColumnSpan(this.dgvSetpoints, 2);
            this.dgvSetpoints.Location = new System.Drawing.Point(3, 33);
            this.dgvSetpoints.Name = "dgvSetpoints";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSetpoints.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSetpoints.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvSetpoints.ShowEditingIcon = false;
            this.dgvSetpoints.Size = new System.Drawing.Size(338, 240);
            this.dgvSetpoints.TabIndex = 6;
            this.dgvSetpoints.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSetpoints_CellValueChanged);
            // 
            // ColumnSetpt
            // 
            this.ColumnSetpt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ColumnSetpt.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnSetpt.HeaderText = "Точки уставки, кгс/см2";
            this.ColumnSetpt.Name = "ColumnSetpt";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // SetptModeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SetptModeControl";
            this.Size = new System.Drawing.Size(352, 563);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPointsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSetpoints)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnLoadProfile;
        private System.Windows.Forms.Button btnSaveProfile;
        private System.Windows.Forms.Label lbCurrentSetpoint;
        private System.Windows.Forms.TextBox tbCurrentSetpoint;
        private System.Windows.Forms.Button btnPrevP;
        private System.Windows.Forms.Button btnNextP;
        private System.Windows.Forms.Button btnControllerOnOff;
        private System.Windows.Forms.Button btnVent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudPointsCount;
        private System.Windows.Forms.DataGridView dgvSetpoints;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSetpt;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
