namespace BusinessSharkUI
{
    partial class FrmSourceEditor
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
            cmbResourceList = new ComboBox();
            lblName = new Label();
            txtName = new TextBox();
            lblVolume = new Label();
            btnOK = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // cmbResourceList
            // 
            cmbResourceList.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbResourceList.FormattingEnabled = true;
            cmbResourceList.Location = new Point(137, 64);
            cmbResourceList.Name = "cmbResourceList";
            cmbResourceList.Size = new Size(326, 28);
            cmbResourceList.TabIndex = 18;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(17, 32);
            lblName.Name = "lblName";
            lblName.Size = new Size(49, 20);
            lblName.TabIndex = 13;
            lblName.Text = "Name";
            // 
            // txtName
            // 
            txtName.Location = new Point(85, 29);
            txtName.Name = "txtName";
            txtName.Size = new Size(378, 27);
            txtName.TabIndex = 14;
            // 
            // lblVolume
            // 
            lblVolume.AutoSize = true;
            lblVolume.Location = new Point(17, 67);
            lblVolume.Name = "lblVolume";
            lblVolume.Size = new Size(118, 20);
            lblVolume.TabIndex = 15;
            lblVolume.Text = "Type of resource";
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(260, 119);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(98, 31);
            btnOK.TabIndex = 16;
            btnOK.Text = "OK";
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(365, 119);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(98, 31);
            btnCancel.TabIndex = 17;
            btnCancel.Text = "Cancel";
            // 
            // FrmSourceEditor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(481, 167);
            Controls.Add(cmbResourceList);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblVolume);
            Controls.Add(btnOK);
            Controls.Add(btnCancel);
            Name = "FrmSourceEditor";
            Text = "Source Editor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbResourceList;
        private Label lblName;
        private TextBox txtName;
        private Label lblVolume;
        private Button btnOK;
        private Button btnCancel;
    }
}