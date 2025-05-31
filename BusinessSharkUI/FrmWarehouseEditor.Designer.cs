namespace BusinessSharkUI
{
    partial class FrmWarehouseEditor
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtName;
        private NumericUpDown numVolume;
        private Label lblName;
        private Label lblVolume;
        private Button btnOK;
        private Button btnCancel;

        private void InitializeComponent()
        {
            txtName = new TextBox();
            numVolume = new NumericUpDown();
            lblName = new Label();
            lblVolume = new Label();
            btnOK = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numVolume).BeginInit();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(80, 12);
            txtName.Name = "txtName";
            txtName.Size = new Size(378, 27);
            txtName.TabIndex = 1;
            // 
            // numVolume
            // 
            numVolume.Location = new Point(80, 48);
            numVolume.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numVolume.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numVolume.Name = "numVolume";
            numVolume.Size = new Size(180, 27);
            numVolume.TabIndex = 3;
            numVolume.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(12, 15);
            lblName.Name = "lblName";
            lblName.Size = new Size(49, 20);
            lblName.TabIndex = 0;
            lblName.Text = "Name";
            // 
            // lblVolume
            // 
            lblVolume.AutoSize = true;
            lblVolume.Location = new Point(12, 50);
            lblVolume.Name = "lblVolume";
            lblVolume.Size = new Size(59, 20);
            lblVolume.TabIndex = 2;
            lblVolume.Text = "Volume";
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(255, 102);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(98, 31);
            btnOK.TabIndex = 4;
            btnOK.Text = "OK";
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(360, 102);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(98, 31);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            // 
            // FrmWarehouseEditor
            // 
            AcceptButton = btnOK;
            CancelButton = btnCancel;
            ClientSize = new Size(485, 149);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblVolume);
            Controls.Add(numVolume);
            Controls.Add(btnOK);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmWarehouseEditor";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Warehouse Editor";
            ((System.ComponentModel.ISupportInitialize)numVolume).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
