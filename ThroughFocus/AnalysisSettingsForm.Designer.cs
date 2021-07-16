namespace CSharpUserAnalysisApplication4
{
    partial class AnalysisSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalysisSettingsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.comboAlgorithm = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboPupilSampling = new System.Windows.Forms.ComboBox();
            this.comboImageSampling = new System.Windows.Forms.ComboBox();
            this.cbUsePolarization = new System.Windows.Forms.CheckBox();
            this.cbUseCentroid = new System.Windows.Forms.CheckBox();
            this.cbNormalize = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboField = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboWavelength = new System.Windows.Forms.ComboBox();
            this.cbDisplayTextOutput = new System.Windows.Forms.CheckBox();
            this.bOK = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.lNumberOfSteps = new System.Windows.Forms.Label();
            this.numNumberOfSteps = new System.Windows.Forms.NumericUpDown();
            this.lMinFocus = new System.Windows.Forms.Label();
            this.lMaxFocus = new System.Windows.Forms.Label();
            this.numMinFocus = new System.Windows.Forms.NumericUpDown();
            this.numMaxFocus = new System.Windows.Forms.NumericUpDown();
            this.lPsfWidth = new System.Windows.Forms.Label();
            this.numPsfWidth = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.comboHuygensMethod = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberOfSteps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinFocus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxFocus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPsfWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Algorithm";
            // 
            // comboAlgorithm
            // 
            this.comboAlgorithm.FormattingEnabled = true;
            this.comboAlgorithm.Location = new System.Drawing.Point(158, 27);
            this.comboAlgorithm.Name = "comboAlgorithm";
            this.comboAlgorithm.Size = new System.Drawing.Size(121, 21);
            this.comboAlgorithm.TabIndex = 1;
            this.comboAlgorithm.SelectedIndexChanged += new System.EventHandler(this.comboAlgorithm_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Pupil Sampling";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Image Sampling";
            // 
            // comboPupilSampling
            // 
            this.comboPupilSampling.FormattingEnabled = true;
            this.comboPupilSampling.Location = new System.Drawing.Point(158, 68);
            this.comboPupilSampling.Name = "comboPupilSampling";
            this.comboPupilSampling.Size = new System.Drawing.Size(121, 21);
            this.comboPupilSampling.TabIndex = 2;
            this.comboPupilSampling.SelectedIndexChanged += new System.EventHandler(this.comboPupilSampling_SelectedIndexChanged);
            // 
            // comboImageSampling
            // 
            this.comboImageSampling.FormattingEnabled = true;
            this.comboImageSampling.Location = new System.Drawing.Point(158, 114);
            this.comboImageSampling.Name = "comboImageSampling";
            this.comboImageSampling.Size = new System.Drawing.Size(121, 21);
            this.comboImageSampling.TabIndex = 3;
            this.comboImageSampling.SelectedIndexChanged += new System.EventHandler(this.comboImageSampling_SelectedIndexChanged);
            // 
            // cbUsePolarization
            // 
            this.cbUsePolarization.AutoSize = true;
            this.cbUsePolarization.Location = new System.Drawing.Point(100, 267);
            this.cbUsePolarization.Name = "cbUsePolarization";
            this.cbUsePolarization.Size = new System.Drawing.Size(102, 17);
            this.cbUsePolarization.TabIndex = 11;
            this.cbUsePolarization.Text = "Use Polarization";
            this.cbUsePolarization.UseVisualStyleBackColor = true;
            this.cbUsePolarization.CheckedChanged += new System.EventHandler(this.cbUsePolarization_CheckedChanged);
            // 
            // cbUseCentroid
            // 
            this.cbUseCentroid.AutoSize = true;
            this.cbUseCentroid.Location = new System.Drawing.Point(100, 300);
            this.cbUseCentroid.Name = "cbUseCentroid";
            this.cbUseCentroid.Size = new System.Drawing.Size(87, 17);
            this.cbUseCentroid.TabIndex = 13;
            this.cbUseCentroid.Text = "Use Centroid";
            this.cbUseCentroid.UseVisualStyleBackColor = true;
            this.cbUseCentroid.CheckedChanged += new System.EventHandler(this.cbUseCentroid_CheckedChanged);
            // 
            // cbNormalize
            // 
            this.cbNormalize.AutoSize = true;
            this.cbNormalize.Location = new System.Drawing.Point(240, 267);
            this.cbNormalize.Name = "cbNormalize";
            this.cbNormalize.Size = new System.Drawing.Size(72, 17);
            this.cbNormalize.TabIndex = 12;
            this.cbNormalize.Text = "Normalize";
            this.cbNormalize.UseVisualStyleBackColor = true;
            this.cbNormalize.CheckedChanged += new System.EventHandler(this.cbNormalize_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(314, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Type";
            // 
            // comboType
            // 
            this.comboType.FormattingEnabled = true;
            this.comboType.Location = new System.Drawing.Point(471, 107);
            this.comboType.Name = "comboType";
            this.comboType.Size = new System.Drawing.Size(121, 21);
            this.comboType.TabIndex = 8;
            this.comboType.SelectedIndexChanged += new System.EventHandler(this.comboType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(314, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Field";
            // 
            // comboField
            // 
            this.comboField.FormattingEnabled = true;
            this.comboField.Location = new System.Drawing.Point(471, 69);
            this.comboField.Name = "comboField";
            this.comboField.Size = new System.Drawing.Size(121, 21);
            this.comboField.TabIndex = 7;
            this.comboField.SelectedIndexChanged += new System.EventHandler(this.comboField_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(314, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Wavelength";
            // 
            // comboWavelength
            // 
            this.comboWavelength.FormattingEnabled = true;
            this.comboWavelength.Location = new System.Drawing.Point(471, 28);
            this.comboWavelength.Name = "comboWavelength";
            this.comboWavelength.Size = new System.Drawing.Size(121, 21);
            this.comboWavelength.TabIndex = 6;
            this.comboWavelength.SelectedIndexChanged += new System.EventHandler(this.comboWavelength_SelectedIndexChanged);
            // 
            // cbDisplayTextOutput
            // 
            this.cbDisplayTextOutput.AutoSize = true;
            this.cbDisplayTextOutput.Location = new System.Drawing.Point(240, 300);
            this.cbDisplayTextOutput.Name = "cbDisplayTextOutput";
            this.cbDisplayTextOutput.Size = new System.Drawing.Size(119, 17);
            this.cbDisplayTextOutput.TabIndex = 14;
            this.cbDisplayTextOutput.Text = "Display Text Output";
            this.cbDisplayTextOutput.UseVisualStyleBackColor = true;
            this.cbDisplayTextOutput.CheckedChanged += new System.EventHandler(this.cbDisplayTextOutput_CheckedChanged);
            // 
            // bOK
            // 
            this.bOK.Location = new System.Drawing.Point(225, 342);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(75, 23);
            this.bOK.TabIndex = 15;
            this.bOK.Text = "OK";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(357, 342);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 16;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // lNumberOfSteps
            // 
            this.lNumberOfSteps.AutoSize = true;
            this.lNumberOfSteps.Location = new System.Drawing.Point(42, 197);
            this.lNumberOfSteps.Name = "lNumberOfSteps";
            this.lNumberOfSteps.Size = new System.Drawing.Size(86, 13);
            this.lNumberOfSteps.TabIndex = 0;
            this.lNumberOfSteps.Text = "Number of Steps";
            // 
            // numNumberOfSteps
            // 
            this.numNumberOfSteps.Location = new System.Drawing.Point(158, 193);
            this.numNumberOfSteps.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numNumberOfSteps.Name = "numNumberOfSteps";
            this.numNumberOfSteps.Size = new System.Drawing.Size(120, 20);
            this.numNumberOfSteps.TabIndex = 4;
            this.numNumberOfSteps.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numNumberOfSteps.ValueChanged += new System.EventHandler(this.numNumberOfSteps_ValueChanged);
            // 
            // lMinFocus
            // 
            this.lMinFocus.AutoSize = true;
            this.lMinFocus.Location = new System.Drawing.Point(314, 156);
            this.lMinFocus.Name = "lMinFocus";
            this.lMinFocus.Size = new System.Drawing.Size(79, 13);
            this.lMinFocus.TabIndex = 6;
            this.lMinFocus.Text = "Min Focus (um)";
            // 
            // lMaxFocus
            // 
            this.lMaxFocus.AutoSize = true;
            this.lMaxFocus.Location = new System.Drawing.Point(314, 197);
            this.lMaxFocus.Name = "lMaxFocus";
            this.lMaxFocus.Size = new System.Drawing.Size(82, 13);
            this.lMaxFocus.TabIndex = 0;
            this.lMaxFocus.Text = "Max Focus (um)";
            // 
            // numMinFocus
            // 
            this.numMinFocus.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numMinFocus.Location = new System.Drawing.Point(471, 152);
            this.numMinFocus.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numMinFocus.Name = "numMinFocus";
            this.numMinFocus.Size = new System.Drawing.Size(120, 20);
            this.numMinFocus.TabIndex = 9;
            this.numMinFocus.ValueChanged += new System.EventHandler(this.numMinFocus_ValueChanged);
            // 
            // numMaxFocus
            // 
            this.numMaxFocus.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numMaxFocus.Location = new System.Drawing.Point(471, 193);
            this.numMaxFocus.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numMaxFocus.Name = "numMaxFocus";
            this.numMaxFocus.Size = new System.Drawing.Size(120, 20);
            this.numMaxFocus.TabIndex = 10;
            this.numMaxFocus.ValueChanged += new System.EventHandler(this.numMaxFocus_ValueChanged);
            // 
            // lPsfWidth
            // 
            this.lPsfWidth.AutoSize = true;
            this.lPsfWidth.Location = new System.Drawing.Point(42, 235);
            this.lPsfWidth.Name = "lPsfWidth";
            this.lPsfWidth.Size = new System.Drawing.Size(81, 13);
            this.lPsfWidth.TabIndex = 0;
            this.lPsfWidth.Text = "PSF Width (um)";
            // 
            // numPsfWidth
            // 
            this.numPsfWidth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numPsfWidth.Location = new System.Drawing.Point(158, 233);
            this.numPsfWidth.Name = "numPsfWidth";
            this.numPsfWidth.Size = new System.Drawing.Size(120, 20);
            this.numPsfWidth.TabIndex = 5;
            this.numPsfWidth.ValueChanged += new System.EventHandler(this.numPsfWidth_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Huygens Method";
            // 
            // comboHuygensMethod
            // 
            this.comboHuygensMethod.FormattingEnabled = true;
            this.comboHuygensMethod.Location = new System.Drawing.Point(158, 153);
            this.comboHuygensMethod.Name = "comboHuygensMethod";
            this.comboHuygensMethod.Size = new System.Drawing.Size(121, 21);
            this.comboHuygensMethod.TabIndex = 3;
            this.comboHuygensMethod.SelectedIndexChanged += new System.EventHandler(this.comboHuygensMethod_SelectedIndexChanged);
            // 
            // AnalysisSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(634, 386);
            this.Controls.Add(this.lPsfWidth);
            this.Controls.Add(this.numPsfWidth);
            this.Controls.Add(this.lMaxFocus);
            this.Controls.Add(this.lMinFocus);
            this.Controls.Add(this.numMaxFocus);
            this.Controls.Add(this.numMinFocus);
            this.Controls.Add(this.numNumberOfSteps);
            this.Controls.Add(this.lNumberOfSteps);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.cbDisplayTextOutput);
            this.Controls.Add(this.cbNormalize);
            this.Controls.Add(this.cbUseCentroid);
            this.Controls.Add(this.cbUsePolarization);
            this.Controls.Add(this.comboWavelength);
            this.Controls.Add(this.comboField);
            this.Controls.Add(this.comboType);
            this.Controls.Add(this.comboHuygensMethod);
            this.Controls.Add(this.comboImageSampling);
            this.Controls.Add(this.comboPupilSampling);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboAlgorithm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AnalysisSettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.AnalysisSettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numNumberOfSteps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinFocus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxFocus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPsfWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboAlgorithm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboPupilSampling;
        private System.Windows.Forms.ComboBox comboImageSampling;
        private System.Windows.Forms.CheckBox cbUsePolarization;
        private System.Windows.Forms.CheckBox cbUseCentroid;
        private System.Windows.Forms.CheckBox cbNormalize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboField;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboWavelength;
        private System.Windows.Forms.CheckBox cbDisplayTextOutput;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Label lNumberOfSteps;
        private System.Windows.Forms.NumericUpDown numNumberOfSteps;
        private System.Windows.Forms.Label lMinFocus;
        private System.Windows.Forms.Label lMaxFocus;
        private System.Windows.Forms.NumericUpDown numMinFocus;
        internal System.Windows.Forms.NumericUpDown numMaxFocus;
        private System.Windows.Forms.Label lPsfWidth;
        internal System.Windows.Forms.NumericUpDown numPsfWidth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboHuygensMethod;
    }
}

