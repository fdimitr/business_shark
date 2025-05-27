namespace BusinessSharkUI
{
    partial class FrmRouteRedactor
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
            cmbStartPoint = new ComboBox();
            cmbFinishPoint = new ComboBox();
            comboBox3 = new ComboBox();
            numVolume = new NumericUpDown();
            lblName = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnCancel = new Button();
            btnOK = new Button();
            ((System.ComponentModel.ISupportInitialize)numVolume).BeginInit();
            SuspendLayout();
            // 
            // cmbStartPoint
            // 
            cmbStartPoint.FormattingEnabled = true;
            cmbStartPoint.Location = new Point(183, 92);
            cmbStartPoint.Name = "cmbStartPoint";
            cmbStartPoint.Size = new Size(151, 28);
            cmbStartPoint.TabIndex = 0;
            // 
            // cmbFinishPoint
            // 
            cmbFinishPoint.FormattingEnabled = true;
            cmbFinishPoint.Location = new Point(576, 92);
            cmbFinishPoint.Name = "cmbFinishPoint";
            cmbFinishPoint.Size = new Size(151, 28);
            cmbFinishPoint.TabIndex = 1;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(345, 151);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(151, 28);
            comboBox3.TabIndex = 2;
            // 
            // numVolume
            // 
            numVolume.Location = new Point(345, 221);
            numVolume.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numVolume.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numVolume.Name = "numVolume";
            numVolume.Size = new Size(151, 27);
            numVolume.TabIndex = 4;
            numVolume.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(50, 95);
            lblName.Name = "lblName";
            lblName.Size = new Size(100, 20);
            lblName.TabIndex = 6;
            lblName.Text = "Starting point";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(205, 154);
            label1.Name = "label1";
            label1.Size = new Size(118, 20);
            label1.TabIndex = 7;
            label1.Text = "Type of resource";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(229, 221);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 8;
            label2.Text = "Quantity";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(451, 95);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 9;
            label3.Text = "End point";
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(646, 294);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(98, 31);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel";
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(518, 294);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(98, 31);
            btnOK.TabIndex = 12;
            btnOK.Text = "OK";
            btnOK.Click += btnOK_Click;
            // 
            // FrmRouteRedactor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 337);
            Controls.Add(btnOK);
            Controls.Add(btnCancel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblName);
            Controls.Add(numVolume);
            Controls.Add(comboBox3);
            Controls.Add(cmbFinishPoint);
            Controls.Add(cmbStartPoint);
            Name = "FrmRouteRedactor";
            Text = "FrmRouteRedactor";
            ((System.ComponentModel.ISupportInitialize)numVolume).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbStartPoint;
        private ComboBox cmbFinishPoint;
        private ComboBox comboBox3;
        private NumericUpDown numVolume;
        private Label lblName;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnCancel;
        private Button btnOK;
    }
}