namespace BusinessSharkUI
{
    partial class FrmFactoryEditor
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
            lblRentInfo = new Label();
            groupBox1 = new GroupBox();
            txtBoxWorkersTechLevel = new TextBox();
            upDownWorkersQuantity = new NumericUpDown();
            lblWorkerTechLevel = new Label();
            lblWorkersQuantity = new Label();
            groupBox2 = new GroupBox();
            txtBoxToolsTechLevel = new TextBox();
            upDownToolsQuantity = new NumericUpDown();
            label3 = new Label();
            label4 = new Label();
            groupBox3 = new GroupBox();
            label6 = new Label();
            UpDownLocationY = new NumericUpDown();
            label5 = new Label();
            UpDownLocationX = new NumericUpDown();
            txtBoxRentalCost = new TextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)upDownWorkersQuantity).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)upDownToolsQuantity).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UpDownLocationY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UpDownLocationX).BeginInit();
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
            txtName.Location = new Point(135, 13);
            txtName.Name = "txtName";
            txtName.Size = new Size(225, 27);
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
            btnOK.Location = new Point(513, 270);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(98, 31);
            btnOK.TabIndex = 10;
            btnOK.Text = "OK";
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(618, 270);
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
            cmbProductsList.Size = new Size(225, 28);
            cmbProductsList.TabIndex = 12;
            // 
            // lblRentInfo
            // 
            lblRentInfo.AutoSize = true;
            lblRentInfo.Location = new Point(378, 16);
            lblRentInfo.Name = "lblRentInfo";
            lblRentInfo.Size = new Size(113, 20);
            lblRentInfo.TabIndex = 13;
            lblRentInfo.Text = "Payment of rent";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtBoxWorkersTechLevel);
            groupBox1.Controls.Add(upDownWorkersQuantity);
            groupBox1.Controls.Add(lblWorkerTechLevel);
            groupBox1.Controls.Add(lblWorkersQuantity);
            groupBox1.Location = new Point(12, 99);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(305, 150);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "Workers";
            // 
            // txtBoxWorkersTechLevel
            // 
            txtBoxWorkersTechLevel.Location = new Point(147, 91);
            txtBoxWorkersTechLevel.Name = "txtBoxWorkersTechLevel";
            txtBoxWorkersTechLevel.Size = new Size(104, 27);
            txtBoxWorkersTechLevel.TabIndex = 25;
            txtBoxWorkersTechLevel.KeyPress += txtBoxWorkersTechLevel_KeyPress;
            // 
            // upDownWorkersQuantity
            // 
            upDownWorkersQuantity.Location = new Point(28, 91);
            upDownWorkersQuantity.Name = "upDownWorkersQuantity";
            upDownWorkersQuantity.Size = new Size(98, 27);
            upDownWorkersQuantity.TabIndex = 24;
            // 
            // lblWorkerTechLevel
            // 
            lblWorkerTechLevel.Location = new Point(143, 42);
            lblWorkerTechLevel.Name = "lblWorkerTechLevel";
            lblWorkerTechLevel.Size = new Size(103, 46);
            lblWorkerTechLevel.TabIndex = 21;
            lblWorkerTechLevel.Text = "Qualification level";
            // 
            // lblWorkersQuantity
            // 
            lblWorkersQuantity.Location = new Point(30, 42);
            lblWorkersQuantity.Name = "lblWorkersQuantity";
            lblWorkersQuantity.Size = new Size(96, 46);
            lblWorkersQuantity.TabIndex = 19;
            lblWorkersQuantity.Text = "Number of workers";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtBoxToolsTechLevel);
            groupBox2.Controls.Add(upDownToolsQuantity);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(411, 99);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(305, 150);
            groupBox2.TabIndex = 23;
            groupBox2.TabStop = false;
            groupBox2.Text = "Equipment";
            // 
            // txtBoxToolsTechLevel
            // 
            txtBoxToolsTechLevel.Location = new Point(159, 91);
            txtBoxToolsTechLevel.Name = "txtBoxToolsTechLevel";
            txtBoxToolsTechLevel.Size = new Size(104, 27);
            txtBoxToolsTechLevel.TabIndex = 26;
            txtBoxToolsTechLevel.KeyPress += txtBoxToolsTechLevel_KeyPress;
            // 
            // upDownToolsQuantity
            // 
            upDownToolsQuantity.Location = new Point(39, 91);
            upDownToolsQuantity.Name = "upDownToolsQuantity";
            upDownToolsQuantity.Size = new Size(98, 27);
            upDownToolsQuantity.TabIndex = 25;
            // 
            // label3
            // 
            label3.Location = new Point(159, 42);
            label3.Name = "label3";
            label3.Size = new Size(103, 46);
            label3.TabIndex = 21;
            label3.Text = "Technical level";
            // 
            // label4
            // 
            label4.Location = new Point(39, 42);
            label4.Name = "label4";
            label4.Size = new Size(96, 46);
            label4.TabIndex = 19;
            label4.Text = "Number of tools";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(UpDownLocationY);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(UpDownLocationX);
            groupBox3.Location = new Point(497, 16);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(219, 69);
            groupBox3.TabIndex = 26;
            groupBox3.TabStop = false;
            groupBox3.Text = "Location";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(115, 30);
            label6.Name = "label6";
            label6.Size = new Size(17, 20);
            label6.TabIndex = 29;
            label6.Text = "Y";
            // 
            // UpDownLocationY
            // 
            UpDownLocationY.Location = new Point(139, 28);
            UpDownLocationY.Name = "UpDownLocationY";
            UpDownLocationY.Size = new Size(65, 27);
            UpDownLocationY.TabIndex = 28;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 28);
            label5.Name = "label5";
            label5.Size = new Size(18, 20);
            label5.TabIndex = 27;
            label5.Text = "X";
            // 
            // UpDownLocationX
            // 
            UpDownLocationX.Location = new Point(35, 26);
            UpDownLocationX.Name = "UpDownLocationX";
            UpDownLocationX.Size = new Size(65, 27);
            UpDownLocationX.TabIndex = 26;
            // 
            // txtBoxRentalCost
            // 
            txtBoxRentalCost.Location = new Point(378, 49);
            txtBoxRentalCost.Name = "txtBoxRentalCost";
            txtBoxRentalCost.Size = new Size(104, 27);
            txtBoxRentalCost.TabIndex = 27;
            txtBoxRentalCost.KeyPress += txtBoxRentalCost_KeyPress;
            // 
            // FrmFactoryEditor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(732, 320);
            Controls.Add(txtBoxRentalCost);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(lblRentInfo);
            Controls.Add(cmbProductsList);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblVolume);
            Controls.Add(btnOK);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmFactoryEditor";
            Text = "Factory Editor";
            Load += FrmFactoryEditor_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)upDownWorkersQuantity).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)upDownToolsQuantity).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)UpDownLocationY).EndInit();
            ((System.ComponentModel.ISupportInitialize)UpDownLocationX).EndInit();
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
        private Label lblRentInfo;
        private GroupBox groupBox1;
        private Label lblWorkerTechLevel;
        private Label lblWorkersQuantity;
        private GroupBox groupBox2;
        private Label label3;
        private Label label4;
        private NumericUpDown upDownWorkersQuantity;
        private NumericUpDown upDownToolsQuantity;
        private GroupBox groupBox3;
        private Label label6;
        private NumericUpDown UpDownLocationY;
        private Label label5;
        private NumericUpDown UpDownLocationX;
        private TextBox txtBoxWorkersTechLevel;
        private TextBox txtBoxToolsTechLevel;
        private TextBox txtBoxRentalCost;
    }
}