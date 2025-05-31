using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using BusinessShark.Core;
using BusinessShark.Core.Item;
using BusinessShark.Core.ServiceClasses;
using MessagePack;
using MessagePack.Resolvers;
using Microsoft.VisualBasic;


namespace BusinessSharkUI
{
    public partial class FrmMain : Form
    {
        private Market market { get; set; } = new Market();

        private City currentCity { get; set; }
        private Warehouse? currentWarehouse { get; set; }
        private Factory? currentFactory { get; set; }

        private readonly BindingSource _bindingSourceFactories = new BindingSource();
        private readonly BindingSource _bindingSourceWarehouse = new BindingSource();

        public FrmMain()
        {
            InitializeComponent();
            InitialData();

            SetDataSources();

            BindWarehouseCombo();
            BindFactoryCombo();
            BindingWarehouseListView();

            listViewWarehouseItems.View = View.Details;
            listOfProduction.View = View.Details;
        }

        private void InitialData()
        {
            // This method can be used to initialize any additional data if needed.
            // For example, you can add some factories or warehouses here.
            currentCity = new City("Wroclaw");
            market.Cities.Add(currentCity);

            // Warehouse initialization
            var newWarehouse = new Warehouse(1, "Warehouse(Main)", new Location(), 222);
            newWarehouse.WarehouseOutput.Add(Enums.ItemType.Wood, new Item(market.ItemDefinitions[Enums.ItemType.Wood], 0, 0, 3456, 2.5f, 0.15f));
            newWarehouse.WarehouseOutput.Add(Enums.ItemType.Leather, new Item(market.ItemDefinitions[Enums.ItemType.Leather], 0, 0, 120, 1.2f, 22.6f));

            currentCity.Warehouses.Add(newWarehouse);

            // Factory initialization
            var newFactory = new Factory(2, "Factory(Main)", market.ItemDefinitions[Enums.ItemType.Bed], 2.3f, new Tools(), new Workers(), new Location());

            newFactory.ProgressProduction = 0.75f;
            newFactory.ProgressQuality = 3.75f;
            newFactory.ProgressPrice = 233;

            newFactory.WarehouseInput.Add(Enums.ItemType.Wood, new Item(market.ItemDefinitions[Enums.ItemType.Wood], 0, 0, 16, 2.5f, 0.15f));
            newFactory.WarehouseInput.Add(Enums.ItemType.Leather, new Item(market.ItemDefinitions[Enums.ItemType.Leather], 0, 0, 6, 1.2f, 22.6f));

            newFactory.WarehouseOutput.Add(Enums.ItemType.Bed, new Item(market.ItemDefinitions[Enums.ItemType.Bed], 0, 0, 2, 31.9f, 23.15f));
            currentCity.Factories.Add(newFactory);
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
                        i.Value.Price.ToString("F2"),
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
                        i.Value.Price.ToString("F2"),
                    }
                });

                listViewFactoryOutput.Items.AddRange(listViewItemCollection.ToArray());
                listViewFactoryOutput.ResumeLayout();
            }
        }

        private void SetDataSources()
        {
            _bindingSourceFactories.DataSource = currentCity.Factories;
            _bindingSourceWarehouse.DataSource = currentCity.Warehouses;
            BindingWarehouseListView();
            BindingFactoryProductionListView();
            BindingFactoryInputListView();
            BindingFactoryOutputListView();
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
            FrmFactoryEditor factoryRedactor = new FrmFactoryEditor(market);
            if (factoryRedactor.ShowDialog() == DialogResult.OK)
            {
                var name = factoryRedactor.FactoryName;
                var newId = currentCity.Factories.Count == 0
                    ? 1
                    : currentCity.Factories.Max(w => w.DivisionId) + 1;
                ItemDefinition product;

                switch (factoryRedactor.ProductType)
                {
                    case (Enums.ItemType.Bed):
                        {
                            product = market.ItemDefinitions[Enums.ItemType.Bed];
                            break;
                        }
                    default:
                        {
                            product = market.ItemDefinitions[Enums.ItemType.Bed];
                            break;
                        }

                }
                var newFactory = new Factory(newId, name, product, 1, new Tools(), new Workers(), new Location());
                currentCity.Factories.Add(newFactory);

                currentFactory = newFactory;

            }
        }

        private void BindingFactoryProductionListView()
        {
            if (currentFactory != null)
            {
                listOfProduction.SuspendLayout();
                listOfProduction.Items.Clear();

                ListViewItem productView = new ListViewItem(currentFactory.ProductDefinition.Name);
                productView.SubItems.Add(currentFactory.ProgressProduction.ToString());
                productView.SubItems.Add(currentFactory.ProgressQuality.ToString());
                productView.SubItems.Add(currentFactory.ProgressPrice.ToString());

                listOfProduction.Items.Add(productView);
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

        private void btnSaveGame_Click(object sender, EventArgs e)
        {

            string datetime = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string saveDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Save");
            if (!Directory.Exists(saveDir))
            {
                Directory.CreateDirectory(saveDir);
            }
            string fileName = Path.Combine(saveDir, $"market_{datetime}.dat");

            var options = MessagePackSerializer.DefaultOptions.WithResolver(StandardResolverAllowPrivate.Instance);
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
                    currentCity = market.Cities.FirstOrDefault() ?? new City("Wroclaw");
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
        }

        private void cmbFactories_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentFactory = cmbFactories.SelectedItem as Factory;
            BindingFactoryProductionListView();
            BindingFactoryInputListView();
            BindingFactoryOutputListView();
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
            }

        }

        private void btnAddRouteToStore_Click(object sender, EventArgs e)
        {
            //var routeEditor = new FrmRouteEditor(market);
            //routeEditor.ShowDialog();
        }
    }
}
