namespace BusinessSharkUI
{
    partial class FrmRouteEditor
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
            cmbRequestedItems = new ComboBox();
            label1 = new Label();
            btnCancel = new Button();
            btnOK = new Button();
            dataGridViewRoutes = new DataGridView();
            IsRoute = new DataGridViewCheckBoxColumn();
            NameDivision = new DataGridViewTextBoxColumn();
            City = new DataGridViewTextBoxColumn();
            DeliveryPrice = new DataGridViewTextBoxColumn();
            ExistingQuantity = new DataGridViewTextBoxColumn();
            ReqestedQuantity = new DataGridViewTextBoxColumn();
            DivisionId = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRoutes).BeginInit();
            SuspendLayout();
            // 
            // cmbRequestedItems
            // 
            cmbRequestedItems.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRequestedItems.FormattingEnabled = true;
            cmbRequestedItems.Location = new Point(720, 37);
            cmbRequestedItems.Name = "cmbRequestedItems";
            cmbRequestedItems.Size = new Size(174, 28);
            cmbRequestedItems.TabIndex = 2;
            cmbRequestedItems.SelectedIndexChanged += cmbRequestedItems_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(720, 14);
            label1.Name = "label1";
            label1.Size = new Size(118, 20);
            label1.TabIndex = 7;
            label1.Text = "Type of resource";
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(796, 294);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(98, 31);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(796, 234);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(98, 31);
            btnOK.TabIndex = 12;
            btnOK.Text = "OK";
            btnOK.Click += btnOK_Click;
            // 
            // dataGridViewRoutes
            // 
            dataGridViewRoutes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRoutes.Columns.AddRange(new DataGridViewColumn[] { IsRoute, NameDivision, City, DeliveryPrice, ExistingQuantity, ReqestedQuantity, DivisionId });
            dataGridViewRoutes.Location = new Point(12, 12);
            dataGridViewRoutes.Name = "dataGridViewRoutes";
            dataGridViewRoutes.RowHeadersWidth = 51;
            dataGridViewRoutes.Size = new Size(698, 313);
            dataGridViewRoutes.TabIndex = 13;
            // 
            // IsRoute
            // 
            IsRoute.DataPropertyName = "IsRoute";
            IsRoute.HeaderText = "Route";
            IsRoute.MinimumWidth = 6;
            IsRoute.Name = "IsRoute";
            IsRoute.Width = 55;
            // 
            // NameDivision
            // 
            NameDivision.DataPropertyName = "Name";
            NameDivision.HeaderText = "Name of division";
            NameDivision.MinimumWidth = 6;
            NameDivision.Name = "NameDivision";
            NameDivision.ReadOnly = true;
            NameDivision.Width = 155;
            // 
            // City
            // 
            City.DataPropertyName = "City";
            City.HeaderText = "City";
            City.MinimumWidth = 6;
            City.Name = "City";
            City.ReadOnly = true;
            City.Width = 125;
            // 
            // DeliveryPrice
            // 
            DeliveryPrice.HeaderText = "Delivery Price";
            DeliveryPrice.MinimumWidth = 6;
            DeliveryPrice.Name = "DeliveryPrice";
            DeliveryPrice.ReadOnly = true;
            DeliveryPrice.Width = 80;
            // 
            // ExistingQuantity
            // 
            ExistingQuantity.DataPropertyName = "ExistingQuantity";
            ExistingQuantity.HeaderText = "Existing quantity";
            ExistingQuantity.MinimumWidth = 6;
            ExistingQuantity.Name = "ExistingQuantity";
            ExistingQuantity.ReadOnly = true;
            ExistingQuantity.Width = 90;
            // 
            // ReqestedQuantity
            // 
            ReqestedQuantity.DataPropertyName = "ReqestedQuantity";
            ReqestedQuantity.HeaderText = "Requested quantity";
            ReqestedQuantity.MinimumWidth = 6;
            ReqestedQuantity.Name = "ReqestedQuantity";
            ReqestedQuantity.Width = 125;
            // 
            // DivisionId
            // 
            DivisionId.HeaderText = "DevisionId";
            DivisionId.MinimumWidth = 6;
            DivisionId.Name = "DivisionId";
            DivisionId.Visible = false;
            DivisionId.Width = 125;
            // 
            // FrmRouteEditor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(906, 337);
            Controls.Add(dataGridViewRoutes);
            Controls.Add(btnOK);
            Controls.Add(btnCancel);
            Controls.Add(label1);
            Controls.Add(cmbRequestedItems);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmRouteEditor";
            Text = "Routers";
            ((System.ComponentModel.ISupportInitialize)dataGridViewRoutes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox cmbRequestedItems;
        private Label label1;
        private Button btnCancel;
        private Button btnOK;
        private DataGridView dataGridViewRoutes;
        private DataGridViewCheckBoxColumn IsRoute;
        private DataGridViewTextBoxColumn NameDivision;
        private DataGridViewTextBoxColumn City;
        private DataGridViewTextBoxColumn DeliveryPrice;
        private DataGridViewTextBoxColumn ExistingQuantity;
        private DataGridViewTextBoxColumn ReqestedQuantity;
        private DataGridViewTextBoxColumn DivisionId;
    }
}