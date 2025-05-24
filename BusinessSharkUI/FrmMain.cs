using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using BusinessShark.Core;
using Microsoft.VisualBasic;


namespace BusinessSharkUI
{
    public partial class FrmMain : Form
    {
        private Market market { get; set; } = new Market();
        private City currentCity { get; set; }

        private readonly BindingSource _bindingSourceWarehouse = new BindingSource();
        private readonly BindingSource _bindingSourceFactories = new BindingSource();

        public FrmMain()
        {
            InitializeComponent();

            currentCity = new City("Wroclaw");
            market.Cities.Add(currentCity);

            var newWarehouse = new Warehouse(1, "2334334", Point.Empty, 222);
            currentCity.Warehouses.Add(newWarehouse);


            _bindingSourceWarehouse.DataSource = currentCity.Warehouses;
            BindWarehouseCombo();
            _bindingSourceFactories.DataSource = currentCity.Factories;
            BindFactoryCombo();
        }

        private void brnAddWarehouse_Click(object sender, EventArgs e)
        {

            FrmWarehouseEditor warehouseEditor = new FrmWarehouseEditor();
            if (warehouseEditor.ShowDialog() == DialogResult.OK)
            {
                var name = warehouseEditor.WarehouseName;
                var volume = warehouseEditor.Volume;
                int newId = currentCity.Warehouses.Max(w => w.DivisionId) + 1;
                var newWarehouse = new Warehouse(newId, name, Point.Empty, volume);
                currentCity.Warehouses.Add(newWarehouse);
                _bindingSourceWarehouse.ResetBindings(false);
            }
        }

        private void btnAddFactory_Click(object sender, EventArgs e)
        {
            var name = Interaction.InputBox("New Factory name", "Factory", "");
            var newFactory = new Factory(1, name, null, 1, new Tools(), new Workers(), Point.Empty);
            currentCity.Factories.Add(newFactory);
            _bindingSourceFactories.ResetBindings(false);
        }

        private void BindWarehouseCombo()
        {
            cmbWarehouses.DataSource = _bindingSourceWarehouse;
            cmbWarehouses.DisplayMember = "Name";
            cmbWarehouses.ValueMember = "DivisionId";
        }

        private void BindFactoryCombo()
        {
            cmbFactories.DataSource = currentCity.Factories;
            cmbFactories.DisplayMember = "Name";
            cmbFactories.ValueMember = "DivisionId";
        }

        private void btnSaveGame_Click(object sender, EventArgs e)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };

            string datetime = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string saveDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Save");
            if (!Directory.Exists(saveDir))
            {
                Directory.CreateDirectory(saveDir);
            }
            string fileName = Path.Combine(saveDir, $"market_{datetime}.dat");

            string json = JsonSerializer.Serialize(market, options);
            File.WriteAllText(fileName, json);
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
                    var options = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve
                    };
                    string json = File.ReadAllText(openFileDialog.FileName);
                    var loadedMarket = JsonSerializer.Deserialize<Market>(json, options);
                    if (loadedMarket != null)
                    {
                        market = loadedMarket;
                        currentCity = market.Cities.FirstOrDefault() ?? new City("Wroclaw");
                        _bindingSourceWarehouse.DataSource = currentCity.Warehouses;
                        BindWarehouseCombo();
                        _bindingSourceFactories.DataSource = currentCity.Factories;
                        BindFactoryCombo();
                        MessageBox.Show("Game loaded successfully!", "Load", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to load game data.", "Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading game: {ex.Message}", "Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
