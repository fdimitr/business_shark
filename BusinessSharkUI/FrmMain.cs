using System.Drawing;
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
    }
}
