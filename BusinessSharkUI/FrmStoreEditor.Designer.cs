namespace BusinessSharkUI
{
    partial class FrmStoreEditor
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
            btnOK = new Button();
            btnCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            txtXCoordinate = new TextBox();
            txtYCoordinate = new TextBox();
            label3 = new Label();
            txtRange = new TextBox();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(14, 21);
            lblName.Name = "lblName";
            lblName.Size = new Size(49, 20);
            lblName.TabIndex = 19;
            lblName.Text = "Name";
            // 
            // txtName
            // 
            txtName.Location = new Point(82, 18);
            txtName.Name = "txtName";
            txtName.Size = new Size(378, 27);
            txtName.TabIndex = 20;
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(319, 222);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(98, 31);
            btnOK.TabIndex = 22;
            btnOK.Text = "OK";
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(424, 222);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(98, 31);
            btnCancel.TabIndex = 23;
            btnCancel.Text = "Cancel";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 63);
            label1.Name = "label1";
            label1.Size = new Size(94, 20);
            label1.TabIndex = 24;
            label1.Text = "X coordinate";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(213, 63);
            label2.Name = "label2";
            label2.Size = new Size(93, 20);
            label2.TabIndex = 25;
            label2.Text = "Y coordinate";
            // 
            // txtXCoordinate
            // 
            txtXCoordinate.Location = new Point(128, 60);
            txtXCoordinate.Name = "txtXCoordinate";
            txtXCoordinate.Size = new Size(62, 27);
            txtXCoordinate.TabIndex = 26;
            // 
            // txtYCoordinate
            // 
            txtYCoordinate.Location = new Point(328, 60);
            txtYCoordinate.Name = "txtYCoordinate";
            txtYCoordinate.Size = new Size(62, 27);
            txtYCoordinate.TabIndex = 27;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 120);
            label3.Name = "label3";
            label3.Size = new Size(51, 20);
            label3.TabIndex = 28;
            label3.Text = "Range";
            // 
            // txtRange
            // 
            txtRange.Location = new Point(82, 117);
            txtRange.Name = "txtRange";
            txtRange.Size = new Size(124, 27);
            txtRange.TabIndex = 29;
            // 
            // FrmStoreEditor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(540, 267);
            Controls.Add(txtRange);
            Controls.Add(label3);
            Controls.Add(txtYCoordinate);
            Controls.Add(txtXCoordinate);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(btnOK);
            Controls.Add(btnCancel);
            Name = "FrmStoreEditor";
            Text = "FrmStoreEditor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private TextBox txtName;
        private Button btnOK;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private TextBox txtXCoordinate;
        private TextBox txtYCoordinate;
        private Label label3;
        private TextBox txtRange;
    }
}