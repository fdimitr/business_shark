namespace BusinessSharkUI
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCalculateStep = new Button();
            btnStartCalculation = new Button();
            btnStopCalculation = new Button();
            groupBox1 = new GroupBox();
            btnEditFactory = new Button();
            listViewFactoryRoutes = new ListView();
            columnHeader5 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            btnAddRouteToFactory = new Button();
            label6 = new Label();
            label5 = new Label();
            listViewFactoryOutput = new ListView();
            columnHeader13 = new ColumnHeader();
            columnHeader14 = new ColumnHeader();
            columnHeader15 = new ColumnHeader();
            columnHeader16 = new ColumnHeader();
            label4 = new Label();
            listOfProduction = new ListView();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            columnHeader11 = new ColumnHeader();
            columnHeader12 = new ColumnHeader();
            label3 = new Label();
            button6 = new Button();
            btnAddFactory = new Button();
            cmbFactories = new ComboBox();
            listViewFactoryInput = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            listViewWarehouseItems = new ListView();
            columnName = new ColumnHeader();
            columnQuantity = new ColumnHeader();
            columnQuality = new ColumnHeader();
            columnPrice = new ColumnHeader();
            cmbWarehouses = new ComboBox();
            brnAddWarehouse = new Button();
            btnDelWarehouse = new Button();
            label1 = new Label();
            listViewWarehouseRoutes = new ListView();
            ItemName = new ColumnHeader();
            RouteSource = new ColumnHeader();
            ItemQuality = new ColumnHeader();
            ItemQuantity = new ColumnHeader();
            label2 = new Label();
            WarehousesGroup = new GroupBox();
            btnAddRouteToWarehouse = new Button();
            btnEditWarehouse = new Button();
            groupBox2 = new GroupBox();
            label8 = new Label();
            listViewSourceOutput = new ListView();
            columnHeader25 = new ColumnHeader();
            columnHeader26 = new ColumnHeader();
            columnHeader27 = new ColumnHeader();
            columnHeader28 = new ColumnHeader();
            label10 = new Label();
            button9 = new Button();
            brnAddSource = new Button();
            cmbSources = new ComboBox();
            listOfExtraction = new ListView();
            columnHeader33 = new ColumnHeader();
            columnHeader34 = new ColumnHeader();
            columnHeader35 = new ColumnHeader();
            columnHeader36 = new ColumnHeader();
            groupBox3 = new GroupBox();
            btnAddRouteToStore = new Button();
            label9 = new Label();
            listView9 = new ListView();
            columnHeader29 = new ColumnHeader();
            columnHeader30 = new ColumnHeader();
            columnHeader31 = new ColumnHeader();
            columnHeader32 = new ColumnHeader();
            label11 = new Label();
            listView11 = new ListView();
            columnHeader37 = new ColumnHeader();
            columnHeader38 = new ColumnHeader();
            columnHeader39 = new ColumnHeader();
            columnHeader40 = new ColumnHeader();
            label12 = new Label();
            button12 = new Button();
            button13 = new Button();
            comboBox2 = new ComboBox();
            listView12 = new ListView();
            columnHeader41 = new ColumnHeader();
            columnHeader42 = new ColumnHeader();
            columnHeader43 = new ColumnHeader();
            columnHeader44 = new ColumnHeader();
            btnLoadGame = new Button();
            btnSaveGame = new Button();
            lblCurrentDate = new Label();
            grpBox_PlayerName = new GroupBox();
            label7 = new Label();
            lblBudget = new Label();
            groupBox1.SuspendLayout();
            WarehousesGroup.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            grpBox_PlayerName.SuspendLayout();
            SuspendLayout();
            // 
            // btnCalculateStep
            // 
            btnCalculateStep.BackColor = Color.GhostWhite;
            btnCalculateStep.Location = new Point(17, 12);
            btnCalculateStep.Name = "btnCalculateStep";
            btnCalculateStep.Size = new Size(157, 55);
            btnCalculateStep.TabIndex = 1;
            btnCalculateStep.Text = "Calculate one Cycle";
            btnCalculateStep.UseVisualStyleBackColor = false;
            btnCalculateStep.Click += btnCalculateStep_Click;
            // 
            // btnStartCalculation
            // 
            btnStartCalculation.BackColor = Color.GhostWhite;
            btnStartCalculation.Location = new Point(180, 12);
            btnStartCalculation.Name = "btnStartCalculation";
            btnStartCalculation.Size = new Size(220, 55);
            btnStartCalculation.TabIndex = 2;
            btnStartCalculation.Text = "Run calculation each 5 sec";
            btnStartCalculation.UseVisualStyleBackColor = false;
            btnStartCalculation.Click += btnStartCalculation_Click;
            // 
            // btnStopCalculation
            // 
            btnStopCalculation.BackColor = Color.GhostWhite;
            btnStopCalculation.Location = new Point(406, 12);
            btnStopCalculation.Name = "btnStopCalculation";
            btnStopCalculation.Size = new Size(197, 55);
            btnStopCalculation.TabIndex = 3;
            btnStopCalculation.Text = "Stop calculation";
            btnStopCalculation.UseVisualStyleBackColor = false;
            btnStopCalculation.Click += btnStopCalculation_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Gainsboro;
            groupBox1.Controls.Add(btnEditFactory);
            groupBox1.Controls.Add(listViewFactoryRoutes);
            groupBox1.Controls.Add(btnAddRouteToFactory);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(listViewFactoryOutput);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(listOfProduction);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(button6);
            groupBox1.Controls.Add(btnAddFactory);
            groupBox1.Controls.Add(cmbFactories);
            groupBox1.Controls.Add(listViewFactoryInput);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(829, 107);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(400, 690);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Factories";
            // 
            // btnEditFactory
            // 
            btnEditFactory.Font = new Font("Segoe UI", 9F);
            btnEditFactory.Location = new Point(122, 48);
            btnEditFactory.Name = "btnEditFactory";
            btnEditFactory.Size = new Size(94, 29);
            btnEditFactory.TabIndex = 32;
            btnEditFactory.Text = "Edit";
            btnEditFactory.UseVisualStyleBackColor = true;
            btnEditFactory.Click += btnEditFactory_Click;
            // 
            // listViewFactoryRoutes
            // 
            listViewFactoryRoutes.AllowColumnReorder = true;
            listViewFactoryRoutes.AllowDrop = true;
            listViewFactoryRoutes.Columns.AddRange(new ColumnHeader[] { columnHeader5, columnHeader8, columnHeader7, columnHeader6 });
            listViewFactoryRoutes.Font = new Font("Segoe UI", 9F);
            listViewFactoryRoutes.Location = new Point(26, 529);
            listViewFactoryRoutes.Name = "listViewFactoryRoutes";
            listViewFactoryRoutes.Size = new Size(358, 145);
            listViewFactoryRoutes.TabIndex = 31;
            listViewFactoryRoutes.UseCompatibleStateImageBehavior = false;
            listViewFactoryRoutes.View = View.Details;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Наименование товара";
            columnHeader5.Width = 100;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Откуда";
            columnHeader8.Width = 90;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Качество";
            columnHeader7.Width = 80;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Количество";
            columnHeader6.Width = 80;
            // 
            // btnAddRouteToFactory
            // 
            btnAddRouteToFactory.BackColor = Color.GhostWhite;
            btnAddRouteToFactory.Location = new Point(86, 491);
            btnAddRouteToFactory.Name = "btnAddRouteToFactory";
            btnAddRouteToFactory.Size = new Size(153, 32);
            btnAddRouteToFactory.TabIndex = 30;
            btnAddRouteToFactory.Text = "Add Route";
            btnAddRouteToFactory.UseVisualStyleBackColor = false;
            btnAddRouteToFactory.Click += btnAddRouteToFactory_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(22, 498);
            label6.Name = "label6";
            label6.Size = new Size(58, 20);
            label6.TabIndex = 25;
            label6.Text = "Routes";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 357);
            label5.Name = "label5";
            label5.Size = new Size(102, 20);
            label5.TabIndex = 23;
            label5.Text = "Output items";
            // 
            // listViewFactoryOutput
            // 
            listViewFactoryOutput.Columns.AddRange(new ColumnHeader[] { columnHeader13, columnHeader14, columnHeader15, columnHeader16 });
            listViewFactoryOutput.Font = new Font("Segoe UI", 9F);
            listViewFactoryOutput.Location = new Point(21, 380);
            listViewFactoryOutput.Name = "listViewFactoryOutput";
            listViewFactoryOutput.Size = new Size(363, 108);
            listViewFactoryOutput.TabIndex = 22;
            listViewFactoryOutput.UseCompatibleStateImageBehavior = false;
            listViewFactoryOutput.View = View.Details;
            // 
            // columnHeader13
            // 
            columnHeader13.Text = "Наименование товара";
            columnHeader13.Width = 115;
            // 
            // columnHeader14
            // 
            columnHeader14.Text = "Количество";
            columnHeader14.Width = 100;
            // 
            // columnHeader15
            // 
            columnHeader15.Text = "Качество";
            columnHeader15.Width = 80;
            // 
            // columnHeader16
            // 
            columnHeader16.Text = "Цена";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 256);
            label4.Name = "label4";
            label4.Size = new Size(86, 20);
            label4.TabIndex = 21;
            label4.Text = "Production";
            // 
            // listOfProduction
            // 
            listOfProduction.Columns.AddRange(new ColumnHeader[] { columnHeader9, columnHeader10, columnHeader11, columnHeader12 });
            listOfProduction.Font = new Font("Segoe UI", 9F);
            listOfProduction.Location = new Point(22, 279);
            listOfProduction.Name = "listOfProduction";
            listOfProduction.Size = new Size(363, 78);
            listOfProduction.TabIndex = 20;
            listOfProduction.UseCompatibleStateImageBehavior = false;
            listOfProduction.View = View.Details;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Наименование товара";
            columnHeader9.Width = 105;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Остаток";
            columnHeader10.Width = 100;
            // 
            // columnHeader11
            // 
            columnHeader11.Text = "Качество";
            columnHeader11.Width = 80;
            // 
            // columnHeader12
            // 
            columnHeader12.Text = "Цена";
            columnHeader12.Width = 70;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 122);
            label3.Name = "label3";
            label3.Size = new Size(90, 20);
            label3.TabIndex = 19;
            label3.Text = "Input items";
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 9F);
            button6.Location = new Point(290, 48);
            button6.Name = "button6";
            button6.Size = new Size(94, 29);
            button6.TabIndex = 13;
            button6.Text = "Delete";
            button6.UseVisualStyleBackColor = true;
            // 
            // btnAddFactory
            // 
            btnAddFactory.Font = new Font("Segoe UI", 9F);
            btnAddFactory.Location = new Point(22, 48);
            btnAddFactory.Name = "btnAddFactory";
            btnAddFactory.Size = new Size(94, 29);
            btnAddFactory.TabIndex = 12;
            btnAddFactory.Text = "Add";
            btnAddFactory.UseVisualStyleBackColor = true;
            btnAddFactory.Click += btnAddFactory_Click;
            // 
            // cmbFactories
            // 
            cmbFactories.FormattingEnabled = true;
            cmbFactories.Location = new Point(22, 93);
            cmbFactories.Name = "cmbFactories";
            cmbFactories.Size = new Size(362, 28);
            cmbFactories.TabIndex = 11;
            cmbFactories.SelectedIndexChanged += cmbFactories_SelectedIndexChanged;
            // 
            // listViewFactoryInput
            // 
            listViewFactoryInput.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            listViewFactoryInput.Font = new Font("Segoe UI", 9F);
            listViewFactoryInput.Location = new Point(21, 145);
            listViewFactoryInput.Name = "listViewFactoryInput";
            listViewFactoryInput.Size = new Size(363, 108);
            listViewFactoryInput.TabIndex = 10;
            listViewFactoryInput.UseCompatibleStateImageBehavior = false;
            listViewFactoryInput.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Наименование товара";
            columnHeader1.Width = 115;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Количество";
            columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Качество";
            columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Цена";
            // 
            // listViewWarehouseItems
            // 
            listViewWarehouseItems.AllowColumnReorder = true;
            listViewWarehouseItems.AllowDrop = true;
            listViewWarehouseItems.BackColor = SystemColors.Control;
            listViewWarehouseItems.Columns.AddRange(new ColumnHeader[] { columnName, columnQuantity, columnQuality, columnPrice });
            listViewWarehouseItems.Font = new Font("Segoe UI", 9F);
            listViewWarehouseItems.FullRowSelect = true;
            listViewWarehouseItems.GridLines = true;
            listViewWarehouseItems.Location = new Point(21, 145);
            listViewWarehouseItems.Name = "listViewWarehouseItems";
            listViewWarehouseItems.Size = new Size(358, 268);
            listViewWarehouseItems.Sorting = SortOrder.Ascending;
            listViewWarehouseItems.TabIndex = 10;
            listViewWarehouseItems.UseCompatibleStateImageBehavior = false;
            listViewWarehouseItems.View = View.Details;
            // 
            // columnName
            // 
            columnName.Text = "Наименование товара";
            columnName.Width = 130;
            // 
            // columnQuantity
            // 
            columnQuantity.Text = "Количество";
            columnQuantity.Width = 80;
            // 
            // columnQuality
            // 
            columnQuality.Text = "Качество";
            columnQuality.Width = 80;
            // 
            // columnPrice
            // 
            columnPrice.Text = "Цена";
            // 
            // cmbWarehouses
            // 
            cmbWarehouses.FormattingEnabled = true;
            cmbWarehouses.Location = new Point(22, 93);
            cmbWarehouses.Name = "cmbWarehouses";
            cmbWarehouses.Size = new Size(358, 28);
            cmbWarehouses.TabIndex = 11;
            cmbWarehouses.SelectedIndexChanged += cmbWarehouses_SelectedIndexChanged;
            // 
            // brnAddWarehouse
            // 
            brnAddWarehouse.Font = new Font("Segoe UI", 9F);
            brnAddWarehouse.Location = new Point(22, 48);
            brnAddWarehouse.Name = "brnAddWarehouse";
            brnAddWarehouse.Size = new Size(94, 29);
            brnAddWarehouse.TabIndex = 12;
            brnAddWarehouse.Text = "Add";
            brnAddWarehouse.UseVisualStyleBackColor = true;
            brnAddWarehouse.Click += brnAddWarehouse_Click;
            // 
            // btnDelWarehouse
            // 
            btnDelWarehouse.Font = new Font("Segoe UI", 9F);
            btnDelWarehouse.Location = new Point(285, 48);
            btnDelWarehouse.Name = "btnDelWarehouse";
            btnDelWarehouse.Size = new Size(94, 29);
            btnDelWarehouse.TabIndex = 13;
            btnDelWarehouse.Text = "Delete";
            btnDelWarehouse.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 122);
            label1.Name = "label1";
            label1.Size = new Size(153, 20);
            label1.TabIndex = 16;
            label1.Text = "Input(Output) Items";
            // 
            // listViewWarehouseRoutes
            // 
            listViewWarehouseRoutes.AllowColumnReorder = true;
            listViewWarehouseRoutes.AllowDrop = true;
            listViewWarehouseRoutes.Columns.AddRange(new ColumnHeader[] { ItemName, RouteSource, ItemQuality, ItemQuantity });
            listViewWarehouseRoutes.Font = new Font("Segoe UI", 9F);
            listViewWarehouseRoutes.Location = new Point(21, 453);
            listViewWarehouseRoutes.Name = "listViewWarehouseRoutes";
            listViewWarehouseRoutes.Size = new Size(358, 221);
            listViewWarehouseRoutes.TabIndex = 17;
            listViewWarehouseRoutes.UseCompatibleStateImageBehavior = false;
            listViewWarehouseRoutes.View = View.Details;
            // 
            // ItemName
            // 
            ItemName.Text = "Наименование товара";
            ItemName.Width = 100;
            // 
            // RouteSource
            // 
            RouteSource.Text = "Откуда";
            RouteSource.Width = 90;
            // 
            // ItemQuality
            // 
            ItemQuality.Text = "Качество";
            ItemQuality.Width = 80;
            // 
            // ItemQuantity
            // 
            ItemQuantity.Text = "Количество";
            ItemQuantity.Width = 80;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 423);
            label2.Name = "label2";
            label2.Size = new Size(58, 20);
            label2.TabIndex = 18;
            label2.Text = "Routes";
            // 
            // WarehousesGroup
            // 
            WarehousesGroup.BackColor = Color.Cornsilk;
            WarehousesGroup.Controls.Add(btnAddRouteToWarehouse);
            WarehousesGroup.Controls.Add(btnEditWarehouse);
            WarehousesGroup.Controls.Add(label2);
            WarehousesGroup.Controls.Add(listViewWarehouseRoutes);
            WarehousesGroup.Controls.Add(label1);
            WarehousesGroup.Controls.Add(btnDelWarehouse);
            WarehousesGroup.Controls.Add(brnAddWarehouse);
            WarehousesGroup.Controls.Add(cmbWarehouses);
            WarehousesGroup.Controls.Add(listViewWarehouseItems);
            WarehousesGroup.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            WarehousesGroup.ForeColor = Color.Goldenrod;
            WarehousesGroup.Location = new Point(423, 107);
            WarehousesGroup.Name = "WarehousesGroup";
            WarehousesGroup.Size = new Size(400, 690);
            WarehousesGroup.TabIndex = 10;
            WarehousesGroup.TabStop = false;
            WarehousesGroup.Text = "Warehouses";
            // 
            // btnAddRouteToWarehouse
            // 
            btnAddRouteToWarehouse.BackColor = Color.GhostWhite;
            btnAddRouteToWarehouse.Location = new Point(88, 417);
            btnAddRouteToWarehouse.Name = "btnAddRouteToWarehouse";
            btnAddRouteToWarehouse.Size = new Size(153, 32);
            btnAddRouteToWarehouse.TabIndex = 30;
            btnAddRouteToWarehouse.Text = "Add Route";
            btnAddRouteToWarehouse.UseVisualStyleBackColor = false;
            btnAddRouteToWarehouse.Click += btnAddRouteToWarehouse_Click;
            // 
            // btnEditWarehouse
            // 
            btnEditWarehouse.Font = new Font("Segoe UI", 9F);
            btnEditWarehouse.Location = new Point(122, 48);
            btnEditWarehouse.Name = "btnEditWarehouse";
            btnEditWarehouse.Size = new Size(94, 29);
            btnEditWarehouse.TabIndex = 19;
            btnEditWarehouse.Text = "Edit";
            btnEditWarehouse.UseVisualStyleBackColor = true;
            btnEditWarehouse.Click += btnEditWarehouse_Click;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Honeydew;
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(listViewSourceOutput);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(button9);
            groupBox2.Controls.Add(brnAddSource);
            groupBox2.Controls.Add(cmbSources);
            groupBox2.Controls.Add(listOfExtraction);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.ForeColor = Color.ForestGreen;
            groupBox2.Location = new Point(17, 107);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(400, 690);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "Sources";
            groupBox2.UseCompatibleTextRendering = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(21, 316);
            label8.Name = "label8";
            label8.Size = new Size(102, 20);
            label8.TabIndex = 23;
            label8.Text = "Output items";
            // 
            // listViewSourceOutput
            // 
            listViewSourceOutput.Columns.AddRange(new ColumnHeader[] { columnHeader25, columnHeader26, columnHeader27, columnHeader28 });
            listViewSourceOutput.Font = new Font("Segoe UI", 9F);
            listViewSourceOutput.Location = new Point(21, 339);
            listViewSourceOutput.Name = "listViewSourceOutput";
            listViewSourceOutput.Size = new Size(366, 335);
            listViewSourceOutput.TabIndex = 22;
            listViewSourceOutput.UseCompatibleStateImageBehavior = false;
            listViewSourceOutput.View = View.Details;
            // 
            // columnHeader25
            // 
            columnHeader25.Text = "Наименование товара";
            columnHeader25.Width = 140;
            // 
            // columnHeader26
            // 
            columnHeader26.Text = "Количество";
            columnHeader26.Width = 80;
            // 
            // columnHeader27
            // 
            columnHeader27.Text = "Качество";
            columnHeader27.Width = 80;
            // 
            // columnHeader28
            // 
            columnHeader28.Text = "Цена";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(21, 122);
            label10.Name = "label10";
            label10.Size = new Size(123, 20);
            label10.TabIndex = 19;
            label10.Text = "Extracting items";
            // 
            // button9
            // 
            button9.Font = new Font("Segoe UI", 9F);
            button9.Location = new Point(134, 48);
            button9.Name = "button9";
            button9.Size = new Size(94, 29);
            button9.TabIndex = 13;
            button9.Text = "Delete";
            button9.UseVisualStyleBackColor = true;
            // 
            // brnAddSource
            // 
            brnAddSource.Font = new Font("Segoe UI", 9F);
            brnAddSource.Location = new Point(22, 48);
            brnAddSource.Name = "brnAddSource";
            brnAddSource.Size = new Size(94, 29);
            brnAddSource.TabIndex = 12;
            brnAddSource.Text = "Add";
            brnAddSource.UseVisualStyleBackColor = true;
            brnAddSource.Click += brnAddSource_Click;
            // 
            // cmbSources
            // 
            cmbSources.FormattingEnabled = true;
            cmbSources.Location = new Point(22, 93);
            cmbSources.Name = "cmbSources";
            cmbSources.Size = new Size(365, 28);
            cmbSources.TabIndex = 11;
            cmbSources.SelectedIndexChanged += cmbSources_SelectedIndexChanged;
            // 
            // listOfExtraction
            // 
            listOfExtraction.BackColor = SystemColors.Control;
            listOfExtraction.Columns.AddRange(new ColumnHeader[] { columnHeader33, columnHeader34, columnHeader35, columnHeader36 });
            listOfExtraction.Font = new Font("Segoe UI", 9F);
            listOfExtraction.Location = new Point(21, 145);
            listOfExtraction.Name = "listOfExtraction";
            listOfExtraction.Size = new Size(366, 168);
            listOfExtraction.TabIndex = 10;
            listOfExtraction.UseCompatibleStateImageBehavior = false;
            listOfExtraction.View = View.Details;
            // 
            // columnHeader33
            // 
            columnHeader33.Text = "Наименование товара";
            columnHeader33.Width = 140;
            // 
            // columnHeader34
            // 
            columnHeader34.Text = "Количество";
            columnHeader34.Width = 80;
            // 
            // columnHeader35
            // 
            columnHeader35.Text = "Качество";
            columnHeader35.Width = 80;
            // 
            // columnHeader36
            // 
            columnHeader36.Text = "Цена";
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.AliceBlue;
            groupBox3.Controls.Add(btnAddRouteToStore);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(listView9);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(listView11);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(button12);
            groupBox3.Controls.Add(button13);
            groupBox3.Controls.Add(comboBox2);
            groupBox3.Controls.Add(listView12);
            groupBox3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox3.ForeColor = Color.SteelBlue;
            groupBox3.Location = new Point(1245, 107);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(400, 690);
            groupBox3.TabIndex = 26;
            groupBox3.TabStop = false;
            groupBox3.Text = "Stores";
            // 
            // btnAddRouteToStore
            // 
            btnAddRouteToStore.BackColor = Color.GhostWhite;
            btnAddRouteToStore.Location = new Point(86, 491);
            btnAddRouteToStore.Name = "btnAddRouteToStore";
            btnAddRouteToStore.Size = new Size(153, 32);
            btnAddRouteToStore.TabIndex = 30;
            btnAddRouteToStore.Text = "Add Route";
            btnAddRouteToStore.UseVisualStyleBackColor = false;
            btnAddRouteToStore.Click += btnAddRouteToStore_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(22, 498);
            label9.Name = "label9";
            label9.Size = new Size(58, 20);
            label9.TabIndex = 25;
            label9.Text = "Routes";
            // 
            // listView9
            // 
            listView9.Columns.AddRange(new ColumnHeader[] { columnHeader29, columnHeader30, columnHeader31, columnHeader32 });
            listView9.Location = new Point(22, 529);
            listView9.Name = "listView9";
            listView9.Size = new Size(366, 145);
            listView9.TabIndex = 24;
            listView9.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader29
            // 
            columnHeader29.Text = "Наименование товара";
            // 
            // columnHeader30
            // 
            columnHeader30.Text = "Количество";
            // 
            // columnHeader31
            // 
            columnHeader31.Text = "Качество";
            // 
            // columnHeader32
            // 
            columnHeader32.Text = "Цена";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(21, 316);
            label11.Name = "label11";
            label11.Size = new Size(62, 20);
            label11.TabIndex = 23;
            label11.Text = "Trading";
            // 
            // listView11
            // 
            listView11.Columns.AddRange(new ColumnHeader[] { columnHeader37, columnHeader38, columnHeader39, columnHeader40 });
            listView11.Location = new Point(21, 339);
            listView11.Name = "listView11";
            listView11.Size = new Size(366, 149);
            listView11.TabIndex = 22;
            listView11.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader37
            // 
            columnHeader37.Text = "Наименование товара";
            // 
            // columnHeader38
            // 
            columnHeader38.Text = "Количество";
            // 
            // columnHeader39
            // 
            columnHeader39.Text = "Качество";
            // 
            // columnHeader40
            // 
            columnHeader40.Text = "Цена";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(21, 122);
            label12.Name = "label12";
            label12.Size = new Size(90, 20);
            label12.TabIndex = 19;
            label12.Text = "Input items";
            // 
            // button12
            // 
            button12.Font = new Font("Segoe UI", 9F);
            button12.Location = new Point(134, 48);
            button12.Name = "button12";
            button12.Size = new Size(94, 29);
            button12.TabIndex = 13;
            button12.Text = "Delete";
            button12.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            button13.Font = new Font("Segoe UI", 9F);
            button13.Location = new Point(22, 48);
            button13.Name = "button13";
            button13.Size = new Size(94, 29);
            button13.TabIndex = 12;
            button13.Text = "Add";
            button13.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(22, 93);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(365, 28);
            comboBox2.TabIndex = 11;
            // 
            // listView12
            // 
            listView12.Columns.AddRange(new ColumnHeader[] { columnHeader41, columnHeader42, columnHeader43, columnHeader44 });
            listView12.Location = new Point(21, 145);
            listView12.Name = "listView12";
            listView12.Size = new Size(366, 168);
            listView12.TabIndex = 10;
            listView12.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader41
            // 
            columnHeader41.Text = "Наименование товара";
            // 
            // columnHeader42
            // 
            columnHeader42.Text = "Количество";
            // 
            // columnHeader43
            // 
            columnHeader43.Text = "Качество";
            // 
            // columnHeader44
            // 
            columnHeader44.Text = "Цена";
            // 
            // btnLoadGame
            // 
            btnLoadGame.BackColor = Color.GhostWhite;
            btnLoadGame.Location = new Point(1339, 12);
            btnLoadGame.Name = "btnLoadGame";
            btnLoadGame.Size = new Size(145, 55);
            btnLoadGame.TabIndex = 27;
            btnLoadGame.Text = "Load game";
            btnLoadGame.UseVisualStyleBackColor = false;
            btnLoadGame.Click += btnLoadGame_Click;
            // 
            // btnSaveGame
            // 
            btnSaveGame.BackColor = Color.GhostWhite;
            btnSaveGame.Location = new Point(1500, 12);
            btnSaveGame.Name = "btnSaveGame";
            btnSaveGame.Size = new Size(145, 55);
            btnSaveGame.TabIndex = 28;
            btnSaveGame.Text = "Save game";
            btnSaveGame.UseVisualStyleBackColor = false;
            btnSaveGame.Click += btnSaveGame_Click;
            // 
            // lblCurrentDate
            // 
            lblCurrentDate.AutoSize = true;
            lblCurrentDate.Location = new Point(635, 30);
            lblCurrentDate.Name = "lblCurrentDate";
            lblCurrentDate.Size = new Size(50, 20);
            lblCurrentDate.TabIndex = 29;
            lblCurrentDate.Text = "label7";
            // 
            // grpBox_PlayerName
            // 
            grpBox_PlayerName.Controls.Add(lblBudget);
            grpBox_PlayerName.Controls.Add(label7);
            grpBox_PlayerName.Location = new Point(881, 13);
            grpBox_PlayerName.Name = "grpBox_PlayerName";
            grpBox_PlayerName.Size = new Size(444, 78);
            grpBox_PlayerName.TabIndex = 30;
            grpBox_PlayerName.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(160, 32);
            label7.Name = "label7";
            label7.Size = new Size(63, 20);
            label7.TabIndex = 0;
            label7.Text = "Бюджет";
            // 
            // lblBudget
            // 
            lblBudget.BorderStyle = BorderStyle.Fixed3D;
            lblBudget.Font = new Font("Segoe UI", 10F);
            lblBudget.Location = new Point(238, 23);
            lblBudget.Name = "lblBudget";
            lblBudget.Size = new Size(184, 37);
            lblBudget.TabIndex = 1;
            lblBudget.TextAlign = ContentAlignment.MiddleRight;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1672, 821);
            Controls.Add(grpBox_PlayerName);
            Controls.Add(lblCurrentDate);
            Controls.Add(btnSaveGame);
            Controls.Add(btnLoadGame);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(WarehousesGroup);
            Controls.Add(btnStopCalculation);
            Controls.Add(btnStartCalculation);
            Controls.Add(btnCalculateStep);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FrmMain";
            Text = "Business Shark";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            WarehousesGroup.ResumeLayout(false);
            WarehousesGroup.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            grpBox_PlayerName.ResumeLayout(false);
            grpBox_PlayerName.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCalculateStep;
        private Button btnStartCalculation;
        private Button btnStopCalculation;
        private GroupBox groupBox1;
        private Button button6;
        private Button btnAddFactory;
        private ComboBox cmbFactories;
        private ListView listViewFactoryInput;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private Label label3;
        private Label label5;
        private ListView listViewFactoryOutput;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader14;
        private ColumnHeader columnHeader15;
        private ColumnHeader columnHeader16;
        private Label label4;
        private ListView listOfProduction;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private Label label6;
        private ListView listViewWarehouseItems;
        private ColumnHeader columnName;
        private ColumnHeader columnQuantity;
        private ColumnHeader columnQuality;
        private ColumnHeader columnPrice;
        private ComboBox cmbWarehouses;
        private Button brnAddWarehouse;
        private Button btnDelWarehouse;
        private Label label1;
        private ListView listViewWarehouseRoutes;
        private ColumnHeader ItemName;
        private ColumnHeader ItemQuantity;
        private ColumnHeader ItemQuality;
        private ColumnHeader RouteSource;
        private Label label2;
        private GroupBox WarehousesGroup;
        private GroupBox groupBox2;
        private Label label8;
        private ListView listViewSourceOutput;
        private ColumnHeader columnHeader25;
        private ColumnHeader columnHeader26;
        private ColumnHeader columnHeader27;
        private ColumnHeader columnHeader28;
        private Label label10;
        private Button button9;
        private Button brnAddSource;
        private ComboBox cmbSources;
        private ListView listOfExtraction;
        private ColumnHeader columnHeader33;
        private ColumnHeader columnHeader34;
        private ColumnHeader columnHeader35;
        private ColumnHeader columnHeader36;
        private GroupBox groupBox3;
        private Label label9;
        private ListView listView9;
        private ColumnHeader columnHeader29;
        private ColumnHeader columnHeader30;
        private ColumnHeader columnHeader31;
        private ColumnHeader columnHeader32;
        private Label label11;
        private ListView listView11;
        private ColumnHeader columnHeader37;
        private ColumnHeader columnHeader38;
        private ColumnHeader columnHeader39;
        private ColumnHeader columnHeader40;
        private Label label12;
        private Button button12;
        private Button button13;
        private ComboBox comboBox2;
        private ListView listView12;
        private ColumnHeader columnHeader41;
        private ColumnHeader columnHeader42;
        private ColumnHeader columnHeader43;
        private ColumnHeader columnHeader44;
        private Button btnLoadGame;
        private Button btnSaveGame;
        private Button btnEditWarehouse;
        private Button btnAddRouteToFactory;
        private Button btnAddRouteToWarehouse;
        private Button btnAddRouteToStore;
        private ListView listViewFactoryRoutes;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private Button btnEditFactory;
        private Label lblCurrentDate;
        private GroupBox grpBox_PlayerName;
        private Label lblBudget;
        private Label label7;
    }
}
