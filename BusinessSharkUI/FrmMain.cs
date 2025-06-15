using System.Globalization;
using BusinessShark.Core;
using BusinessShark.Core.CityClasses;
using BusinessShark.Core.Divisions;
using BusinessShark.Core.Item;
using BusinessShark.Core.ServiceClasses;
using MessagePack;
using MessagePack.Resolvers;


namespace BusinessSharkUI
{
    public partial class FrmMain : Form
    {
        private Market market { get; set; } = new Market();

        private City currentCity { get; set; }
        private Warehouse? currentWarehouse { get; set; }
        private Factory? currentFactory { get; set; }

        private ResourceExtractor? currentSource { get; set; }

        private readonly BindingSource _bindingSourceFactories = new BindingSource();
        private readonly BindingSource _bindingSourceSources = new BindingSource();
        private readonly BindingSource _bindingSourceWarehouse = new BindingSource();

        private Player currentPlayer;

        // Add these fields to FrmMain class
        private System.Threading.Timer? _calculationTimer;

        public FrmMain()
        {
            InitializeComponent();
            InitialData();

            SetDataSources();

            BindingPlayerInfo();
            BindWarehouseCombo();
            BindFactoryCombo();
            BindSourceCombo();
            BindingFactoryRoutesListView();
            BindingWarehouseListView();
            BindingWarehouseRoutesListView();
            BindingSourceProductionListView();
            BindingSourceOutputListView();
            listViewWarehouseItems.View = View.Details;
            listOfProduction.View = View.Details;
        }

        private void InitialData()
        {
            currentPlayer = new Player("Default Player");

            // This method can be used to initialize any additional data if needed.
            // For example, you can add some factories or warehouses here.
            currentCity = new City("Wroclaw", 100, 100);
            market.Cities.Add(currentCity);

            // Warehouse initialization
            var newWarehouse = new Warehouse(1, "Warehouse(Main)", new Location(), 222);
            newWarehouse.WarehouseOutput.Add(Enums.ItemType.Wood, new Item(market.ItemDefinitions[Enums.ItemType.Wood], 0, 0, 3456, 2.5f, 0.15f));
            newWarehouse.WarehouseOutput.Add(Enums.ItemType.Leather, new Item(market.ItemDefinitions[Enums.ItemType.Leather], 0, 0, 120, 1.2f, 22.6f));

            currentCity.Warehouses.Add(newWarehouse);

            // Factory initialization
            currentFactory = new Factory(2, "Factory(Main)", market.ItemDefinitions[Enums.ItemType.Bed], 2.3f, new Tools(), new Workers(), new Location())
                {
                    ProgressProduction = 0.75f,
                    ProgressQuality = 3.75f,
                    ProgressPrice = 233
                };

            currentFactory.WarehouseInput.Add(Enums.ItemType.Wood, new Item(market.ItemDefinitions[Enums.ItemType.Wood], 0, 0, 16, 2.5f, 0.15f));
            currentFactory.WarehouseInput.Add(Enums.ItemType.Leather, new Item(market.ItemDefinitions[Enums.ItemType.Leather], 0, 0, 6, 1.2f, 22.6f));

            currentFactory.WarehouseOutput.Add(Enums.ItemType.Bed, new Item(market.ItemDefinitions[Enums.ItemType.Bed], 0, 0, 2, 31.9f, 23.15f));
            currentCity.Factories.Add(currentFactory);

            currentSource =new ResourceExtractor(3, "Wood Source", market.ItemDefinitions[Enums.ItemType.Wood], 1.0f, new Tools(), new Workers(), new Location())
            {
                ProgressProduction = 0.5f,
                ProgressQuality = 2.5f
            };
            currentCity.Sources.Add(currentSource);
        }

        private void BindingPlayerInfo()
        {
            grpBox_PlayerName.Text = currentPlayer.Name;
            lblBudget.Text = currentPlayer.Wallet.ToString("C", CultureInfo.CurrentCulture);
        }

        private void BindingWarehouseListView()
        {
            if (currentWarehouse != null)
            {
                listViewWarehouseItems.SuspendLayout();
                listViewWarehouseItems.Items.Clear();

                var listViewItemCollection = currentWarehouse.WarehouseOutput.Select(i => new ListViewItem
                {
                    Text = i.Value.Definition.Name,
                    SubItems =
                    {
                        i.Value.Quantity.ToString(),
                        i.Value.Quality.ToString("F2"),
                        i.Value.Price.ToString("F2"),
                    }
                });

                listViewWarehouseItems.Items.AddRange(listViewItemCollection.ToArray());
                listViewWarehouseItems.ResumeLayout();
            }
        }

        private void BindingWarehouseRoutesListView()
        {
            if (currentWarehouse != null)
            {
                listViewWarehouseRoutes.SuspendLayout();
                listViewWarehouseRoutes.Items.Clear();

                var listViewItemCollection = currentWarehouse.Routes.Select(i => new ListViewItem
                {
                    Text = market.ItemDefinitions[i.TransferringItemType].Name,
                    SubItems =
                    {
                        market.GetDeliveryDivisionById(i.FromDivisionId).Name,
                        market.GetDeliveryDivisionById(i.FromDivisionId).WarehouseOutput[i.TransferringItemType].Quality.ToString(),
                        i.TransferringCount.ToString(),
                    }
                });

                listViewWarehouseRoutes.Items.AddRange(listViewItemCollection.ToArray());
                listViewWarehouseRoutes.ResumeLayout();
            }
        }

        private void BindingFactoryInputListView()
        {
            if (currentFactory != null)
            {
                listViewFactoryInput.SuspendLayout();
                listViewFactoryInput.Items.Clear();

                var listViewItemCollection = currentFactory.WarehouseInput.Select(i => new ListViewItem
                {
                    Text = i.Value.Definition.Name,
                    SubItems =
                    {
                        i.Value.Quantity.ToString(),
                        i.Value.Quality.ToString("F2"),
                        i.Value.Definition.BaseProductionPrice.ToString("F2"),
                    }
                });

                listViewFactoryInput.Items.AddRange(listViewItemCollection.ToArray());
                listViewFactoryInput.ResumeLayout();
            }
        }

        private void BindingFactoryOutputListView()
        {
            if (currentFactory != null)
            {
                listViewFactoryOutput.SuspendLayout();
                listViewFactoryOutput.Items.Clear();

                var listViewItemCollection = currentFactory.WarehouseOutput.Select(i => new ListViewItem
                {
                    Text = i.Value.Definition.Name,
                    SubItems =
                    {
                        i.Value.Quantity.ToString(),
                        i.Value.Quality.ToString("F2"),
                        i.Value.Definition.BaseProductionPrice.ToString("F2"),
                    }
                });

                listViewFactoryOutput.Items.AddRange(listViewItemCollection.ToArray());
                listViewFactoryOutput.ResumeLayout();
            }
        }

        private void BindingFactoryRoutesListView()
        {
            if (currentFactory != null)
            {
                listViewFactoryRoutes.SuspendLayout();
                listViewFactoryRoutes.Items.Clear();

                var listViewItemCollection = currentFactory.Routes.Select(i =>
                {
                    var division = market.GetDeliveryDivisionById(i.FromDivisionId);
                    var quality = division.WarehouseOutput.ContainsKey(i.TransferringItemType)
                        ? division.WarehouseOutput[i.TransferringItemType].Quality.ToString()
                        : "N/A";

                    return new ListViewItem
                    {
                        Text = market.ItemDefinitions[i.TransferringItemType].Name,
                        SubItems =
                        {
                            division.Name,
                            quality,
                            i.TransferringCount.ToString(),
                        }
                    };
                }
                );

                listViewFactoryRoutes.Items.AddRange(listViewItemCollection.ToArray());
                listViewFactoryRoutes.ResumeLayout();
            }
        }

        private void SetDataSources()
        {
            _bindingSourceFactories.DataSource = currentCity.Factories;
            _bindingSourceSources.DataSource = currentCity.Sources;
            _bindingSourceWarehouse.DataSource = currentCity.Warehouses;

            currentWarehouse = cmbWarehouses.SelectedItem as Warehouse;
            currentFactory = cmbFactories.SelectedItem as Factory;
            currentSource = cmbSources.SelectedItem as ResourceExtractor;
            BindingWarehouseListView();
            BindingFactoryProductionListView();
            BindingFactoryInputListView();
            BindingFactoryOutputListView();
            BindingFactoryRoutesListView();
            BindingSourceProductionListView();
            BindingSourceOutputListView();

            lblCurrentDate.Text = market.CurrentDate.ToLongDateString();
        }

        private void brnAddWarehouse_Click(object sender, EventArgs e)
        {

            FrmWarehouseEditor warehouseEditor = new FrmWarehouseEditor();
            if (warehouseEditor.ShowDialog() == DialogResult.OK)
            {
                var name = warehouseEditor.WarehouseName;
                var volume = warehouseEditor.Volume;
                int newId = currentCity.Warehouses.Max(w => w.DivisionId) + 1;
                currentWarehouse = new Warehouse(newId, name, new Location(), volume);
                currentCity.Warehouses.Add(currentWarehouse);
                _bindingSourceWarehouse.ResetBindings(false);

                cmbWarehouses.SelectedItem = currentWarehouse;
                BindingWarehouseListView();
            }
        }

        private void btnAddFactory_Click(object sender, EventArgs e)
        {
            AddFactory();
            _bindingSourceFactories.ResetBindings(false);
            cmbFactories.SelectedItem = currentFactory;

            BindingFactoryProductionListView();
            BindingFactoryInputListView();
            BindingFactoryOutputListView();
        }

        private void AddFactory()
        {
            FrmFactoryEditor factoryEditor = new FrmFactoryEditor(market, null);
            if (factoryEditor.ShowDialog() == DialogResult.OK)
            {
                currentCity.Factories.Add(factoryEditor.Factory!);
                currentFactory = factoryEditor.Factory;
            }
        }

        private void EditFactory()
        {
            FrmFactoryEditor factoryEditor = new FrmFactoryEditor(market, currentFactory);
            if (factoryEditor.ShowDialog() == DialogResult.OK)
            {
                currentFactory = factoryEditor.Factory;
            }
        }

        private void BindingFactoryProductionListView()
        {
            if (currentFactory != null)
            {
                listOfProduction.SuspendLayout();
                listOfProduction.Items.Clear();

                var productView = new ListViewItem
                {
                    Text = currentFactory.ProductDefinition.Name,
                    SubItems =
                    {
                        currentFactory.ProgressProduction.ToString("F2"),
                        currentFactory.ProgressQuality.ToString("F2"),
                        currentFactory.ProgressPrice.ToString("F2"),
                    }
                };

                listOfProduction.Items.AddRange(productView);
                listOfProduction.ResumeLayout();
            }
        }

        private void BindWarehouseCombo()
        {
            cmbWarehouses.DataSource = _bindingSourceWarehouse;
            cmbWarehouses.DisplayMember = "Name";
            cmbWarehouses.ValueMember = "DivisionId";
        }

        private void BindFactoryCombo()
        {
            cmbFactories.DataSource = _bindingSourceFactories;
            cmbFactories.DisplayMember = "Name";
            cmbFactories.ValueMember = "DivisionId";
        }

        private void BindSourceCombo()
        {
            cmbSources.DataSource = _bindingSourceSources;
            cmbSources.DisplayMember = "Name";
            cmbSources.ValueMember = "DivisionId";
        }

        private void btnSaveGame_Click(object sender, EventArgs e)
        {

            string datetime = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string saveDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Save");
            if (!Directory.Exists(saveDir))
            {
                Directory.CreateDirectory(saveDir);
            }
            string fileName = Path.Combine(saveDir, $"market_{datetime}.dat");

            var resolver = CompositeResolver.Create(StandardResolverAllowPrivate.Instance, ContractlessStandardResolver.Instance);
            var options = MessagePackSerializer.DefaultOptions.WithResolver(resolver);
            options.WithCompression(MessagePackCompression.Lz4Block);

            byte[] bytes = MessagePackSerializer.Serialize(market, options);


            File.WriteAllBytes(fileName, bytes);
            MessageBox.Show("Saving completed!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLoadGame_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Save"),
                Filter = "Market Save Files (*.dat)|*.dat|All Files (*.*)|*.*",
                Title = "Open Saved Game"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    byte[] bytes = File.ReadAllBytes(openFileDialog.FileName);

                    var options = MessagePackSerializer.DefaultOptions.WithResolver(StandardResolverAllowPrivate.Instance);
                    options.WithCompression(MessagePackCompression.Lz4Block);

                    market = MessagePackSerializer.Deserialize<Market>(bytes, options);
                    currentCity = market.Cities.FirstOrDefault() ?? new City("Wroclaw", 100, 100);
                    SetDataSources();
                    MessageBox.Show("Game loaded successfully!", "Load", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading game: {ex.Message}", "Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbWarehouses_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentWarehouse = cmbWarehouses.SelectedItem as Warehouse;
            BindingWarehouseListView();
            BindingWarehouseRoutesListView();
        }

        private void cmbFactories_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentFactory = cmbFactories.SelectedItem as Factory;
            BindingFactoryProductionListView();
            BindingFactoryInputListView();
            BindingFactoryOutputListView();
            BindingFactoryRoutesListView();
        }

        private void cmbSources_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentSource = cmbSources.SelectedItem as ResourceExtractor;
            BindingSourceProductionListView();
            BindingSourceOutputListView();
        }

        private void btnEditWarehouse_Click(object sender, EventArgs e)
        {
            FrmWarehouseEditor warehouseEditor = new FrmWarehouseEditor();
            if (warehouseEditor.ShowDialog() == DialogResult.OK)
            {
                var name = warehouseEditor.WarehouseName;
                var volume = warehouseEditor.Volume;
                int id = cmbWarehouses.SelectedIndex;
                Location location = currentCity.Warehouses[id].Location;
                currentCity.Warehouses[id] = new Warehouse(id, name, location, volume);
                _bindingSourceWarehouse.ResetBindings(false);
            }
        }

        private void btnAddRouteToWarehouse_Click(object sender, EventArgs e)
        {
            if (currentWarehouse == null)
            {
                MessageBox.Show("Please select a warehouse first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var frmRouteEditor = new FrmRouteEditor(market, currentWarehouse.Routes);
            frmRouteEditor.ShowDialog();
            if (frmRouteEditor.DialogResult == DialogResult.OK)
            {
                currentWarehouse.Routes = frmRouteEditor.Routes;
                BindingWarehouseRoutesListView();
            }
        }

        private void btnAddRouteToFactory_Click(object sender, EventArgs e)
        {
            if (currentFactory == null)
            {
                MessageBox.Show("Please select a factory first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var frmRouteEditor = new FrmRouteEditor(market, currentFactory.Routes);
            frmRouteEditor.ShowDialog();
            if (frmRouteEditor.DialogResult == DialogResult.OK)
            {
                currentFactory.Routes = frmRouteEditor.Routes;
                BindingFactoryRoutesListView();
            }

        }

        private void btnAddRouteToStore_Click(object sender, EventArgs e)
        {
            //var routeEditor = new FrmRouteEditor(market);
            //routeEditor.ShowDialog();
        }

        private void btnCalculateStep_Click(object sender, EventArgs e)
        {
            market.CalculateDay();
            SetDataSources();
        }

        private void brnAddSource_Click(object sender, EventArgs e)
        {
            AddSource();
            _bindingSourceSources.ResetBindings(false);
            cmbSources.SelectedItem = currentSource;

            BindingSourceProductionListView();
            BindingSourceOutputListView();
        }

        private void AddSource()
        {
            FrmSourceEditor sourceEditor = new FrmSourceEditor(market);
            if (sourceEditor.ShowDialog() == DialogResult.OK)
            {
                var name = sourceEditor.SourceName;
                var newId = currentCity.Sources.Count == 0
                    ? 1
                    : currentCity.Sources.Max(w => w.DivisionId) + 1;
                ItemDefinition resource;

                resource = market.ItemDefinitions[sourceEditor.ResourceType];

                var newSource = new ResourceExtractor(newId, name, resource, 1, new Tools(), new Workers(), new Location());
                currentCity.Sources.Add(newSource);

                currentSource = newSource;

            }
        }

        private void BindingSourceOutputListView()
        {
            if (currentSource != null)
            {
                listViewSourceOutput.SuspendLayout();
                listViewSourceOutput.Items.Clear();

                var listViewItemCollection = currentSource.WarehouseOutput.Select(i => new ListViewItem
                {
                    Text = i.Value.Definition.Name,
                    SubItems =
                    {
                        i.Value.Quantity.ToString(),
                        i.Value.Quality.ToString("F2"),
                        i.Value.Price.ToString("F2"),
                    }
                });

                listViewSourceOutput.Items.AddRange(listViewItemCollection.ToArray());
                listViewSourceOutput.ResumeLayout();
            }
        }

        private void BindingSourceProductionListView()
        {
            if (currentSource != null)
            {
                listOfExtraction.SuspendLayout();
                listOfExtraction.Items.Clear();

                var productView = new ListViewItem
                {
                    Text = currentSource.ResourceDefinition.Name,
                    SubItems =
                    {
                        currentSource.ProgressProduction.ToString("F2"),
                        currentSource.ProgressQuality.ToString("F2"),
                        "500",
                        //currentSource.ProgressPrice.ToString("F2"),
                    }
                };

                listOfExtraction.Items.AddRange(productView);
                listOfExtraction.ResumeLayout();
            }
        }


        private void btnEditFactory_Click(object sender, EventArgs e)
        {
            EditFactory();
            _bindingSourceFactories.ResetBindings(false);
            cmbFactories.SelectedItem = currentFactory;

            BindingFactoryProductionListView();
            BindingFactoryInputListView();
            BindingFactoryOutputListView();
        }

        // Add this method to FrmMain class
        private void btnStartCalculation_Click(object sender, EventArgs e)
        {
            if (_calculationTimer == null)
            {
                _calculationTimer = new System.Threading.Timer(_ =>
                {
                    // Run CalculateDay in a background thread
                    market.CalculateDay();
                    // Update UI on the main thread
                    if (this.IsHandleCreated)
                    {
                        this.BeginInvoke(new Action(SetDataSources));
                    }
                }, null, 0, 2000);

                btnStartCalculation.Enabled = false; // Disable the button to prevent multiple timers
            }
        }

        // Add this method to FrmMain class
        private void btnStopCalculation_Click(object sender, EventArgs e)
        {
            _calculationTimer?.Dispose();
            _calculationTimer = null;
            btnStartCalculation.Enabled = true; // Re-enable the button
        }
    }
}
