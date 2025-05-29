namespace BusinessSharkUI
{
    partial class FrmFactoryRedactor
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
            lblName = new Label();
            txtName = new TextBox();
            lblVolume = new Label();
            btnOK = new Button();
            btnCancel = new Button();
            cmbProductsList = new ComboBox();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(15, 16);
            lblName.Name = "lblName";
            lblName.Size = new Size(49, 20);
            lblName.TabIndex = 6;
            lblName.Text = "Name";
            // 
            // txtName
            // 
            txtName.Location = new Point(83, 13);
            txtName.Name = "txtName";
            txtName.Size = new Size(378, 27);
            txtName.TabIndex = 7;
            // 
            // lblVolume
            // 
            lblVolume.AutoSize = true;
            lblVolume.Location = new Point(15, 51);
            lblVolume.Name = "lblVolume";
            lblVolume.Size = new Size(114, 20);
            lblVolume.TabIndex = 8;
            lblVolume.Text = "Type of product";
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(258, 103);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(98, 31);
            btnOK.TabIndex = 10;
            btnOK.Text = "OK";
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(363, 103);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(98, 31);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel";
            // 
            // cmbProductsList
            // 
            cmbProductsList.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProductsList.FormattingEnabled = true;
            cmbProductsList.Location = new Point(135, 48);
            cmbProductsList.Name = "cmbProductsList";
            cmbProductsList.Size = new Size(326, 28);
            cmbProductsList.TabIndex = 12;
            // 
            // FrmFactoryRedactor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(548, 177);
            Controls.Add(cmbProductsList);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblVolume);
            Controls.Add(btnOK);
            Controls.Add(btnCancel);
            Name = "FrmFactoryRedactor";
            Text = "Factory Redactor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private TextBox txtName;
        private Label lblVolume;
        private Button btnOK;
        private Button btnCancel;
        private ComboBox cmbProductsList;
    }
}