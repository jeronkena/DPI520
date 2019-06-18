namespace DPI520NEW
{
    partial class SettingsForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.nudMeasurementInterval = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudTimeToSetpoint = new System.Windows.Forms.NumericUpDown();
            this.nudSetpointPrecision = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudBarometricP = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudGraphTScale = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMeasurementInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeToSetpoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSetpointPrecision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBarometricP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGraphTScale)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.nudMeasurementInterval, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.nudTimeToSetpoint, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.nudSetpointPrecision, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.nudBarometricP, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.nudGraphTScale, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(388, 203);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(285, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Время между измерениями, с";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudMeasurementInterval
            // 
            this.nudMeasurementInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudMeasurementInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudMeasurementInterval.Location = new System.Drawing.Point(294, 87);
            this.nudMeasurementInterval.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudMeasurementInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMeasurementInterval.Name = "nudMeasurementInterval";
            this.nudMeasurementInterval.Size = new System.Drawing.Size(91, 26);
            this.nudMeasurementInterval.TabIndex = 1;
            this.nudMeasurementInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudMeasurementInterval.ValueChanged += new System.EventHandler(this.nudMeasurementInterval_ValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(3, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(285, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Точность уставки, %";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Время до установления, с";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudTimeToSetpoint
            // 
            this.nudTimeToSetpoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudTimeToSetpoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudTimeToSetpoint.Location = new System.Drawing.Point(294, 47);
            this.nudTimeToSetpoint.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudTimeToSetpoint.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudTimeToSetpoint.Name = "nudTimeToSetpoint";
            this.nudTimeToSetpoint.Size = new System.Drawing.Size(91, 26);
            this.nudTimeToSetpoint.TabIndex = 1;
            this.nudTimeToSetpoint.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudTimeToSetpoint.ValueChanged += new System.EventHandler(this.nudTimeToSetpoint_ValueChanged);
            // 
            // nudSetpointPrecision
            // 
            this.nudSetpointPrecision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudSetpointPrecision.DecimalPlaces = 2;
            this.nudSetpointPrecision.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudSetpointPrecision.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudSetpointPrecision.Location = new System.Drawing.Point(294, 7);
            this.nudSetpointPrecision.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudSetpointPrecision.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudSetpointPrecision.Name = "nudSetpointPrecision";
            this.nudSetpointPrecision.Size = new System.Drawing.Size(91, 26);
            this.nudSetpointPrecision.TabIndex = 1;
            this.nudSetpointPrecision.Value = new decimal(new int[] {
            2,
            0,
            0,
            131072});
            this.nudSetpointPrecision.ValueChanged += new System.EventHandler(this.nudSetpointPrecision_ValueChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(285, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Атмосферное давление, кгс/см2";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudBarometricP
            // 
            this.nudBarometricP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudBarometricP.DecimalPlaces = 3;
            this.nudBarometricP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudBarometricP.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudBarometricP.Location = new System.Drawing.Point(294, 168);
            this.nudBarometricP.Maximum = new decimal(new int[] {
            11,
            0,
            0,
            65536});
            this.nudBarometricP.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            65536});
            this.nudBarometricP.Name = "nudBarometricP";
            this.nudBarometricP.Size = new System.Drawing.Size(91, 26);
            this.nudBarometricP.TabIndex = 1;
            this.nudBarometricP.Value = new decimal(new int[] {
            1000,
            0,
            0,
            196608});
            this.nudBarometricP.ValueChanged += new System.EventHandler(this.nudBarometricP_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(285, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Длина времени по оси X графика, с";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudGraphTScale
            // 
            this.nudGraphTScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudGraphTScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudGraphTScale.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudGraphTScale.Location = new System.Drawing.Point(294, 127);
            this.nudGraphTScale.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudGraphTScale.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudGraphTScale.Name = "nudGraphTScale";
            this.nudGraphTScale.Size = new System.Drawing.Size(91, 26);
            this.nudGraphTScale.TabIndex = 1;
            this.nudGraphTScale.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudGraphTScale.ValueChanged += new System.EventHandler(this.nudGraphTScale_ValueChanged);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOK.Location = new System.Drawing.Point(12, 232);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(189, 58);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "Готово";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.Location = new System.Drawing.Point(211, 232);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(189, 58);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 302);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMeasurementInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeToSetpoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSetpointPrecision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBarometricP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGraphTScale)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudTimeToSetpoint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudMeasurementInterval;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudSetpointPrecision;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.NumericUpDown nudBarometricP;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudGraphTScale;
    }
}