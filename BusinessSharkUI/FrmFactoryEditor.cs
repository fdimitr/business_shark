using System.ComponentModel;
using System.Globalization;
using BusinessShark.Core;
using BusinessShark.Core.Divisions;
using BusinessShark.Core.Item;
using BusinessShark.Core.ServiceClasses;

namespace BusinessSharkUI
{

    internal partial class FrmFactoryEditor : Form
    {
        private readonly Market _market;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Factory? Factory { get; set; }


        public FrmFactoryEditor(Market market, Factory? factory)
        {
            InitializeComponent();
            _market = market;
            Factory = factory;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name is required.");
                DialogResult = DialogResult.None;
                return;
            }

            SaveFactory();

            DialogResult = DialogResult.OK;
        }

        private void FrmFactoryEditor_Load(object sender, EventArgs e)
        {
            cmbProductsList.DataSource = _market.ItemDefinitions.Values.Where(i => i.ProductionUnits.Count > 0).ToList();
            cmbProductsList.DisplayMember = "Name";
            cmbProductsList.ValueMember = "ItemDefinitionId";

            if (Factory != null)
            {
                txtName.Text = Factory.Name;
                cmbProductsList.SelectedValue = Factory.ProductDefinition.ItemDefinitionId;
                txtBoxRentalCost.Text = Factory.RentalCost.ToString("F2");

                // Location
                UpDownLocationX.Value = Factory.Location.X;
                UpDownLocationY.Value = Factory.Location.Y;

                // Workers
                upDownWorkersQuantity.Value = Factory.Workers.TotalQuantity;
                txtBoxWorkersTechLevel.Text = Factory.Workers.TechLevel.ToString(CultureInfo.InvariantCulture);

                // Tool Park
                upDownToolsQuantity.Value = Factory.ToolPark.TotalQuantity;
                txtBoxToolsTechLevel.Text = Factory.ToolPark.TechLevel.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void SaveFactory()
        {
            var location = new Location((int)UpDownLocationX.Value, (int)UpDownLocationY.Value);
            var workers = new Workers
            {
                TotalQuantity = (int)upDownWorkersQuantity.Value,
                TechLevel = float.Parse(txtBoxWorkersTechLevel.Text, CultureInfo.InvariantCulture)
            };
            var tools = new Tools
            {
                TotalQuantity = (int)upDownToolsQuantity.Value,
                TechLevel = float.Parse(txtBoxToolsTechLevel.Text, CultureInfo.InvariantCulture)
            };

            if (Factory == null)
            {
                int newDivisionId = _market.GetNewDivisionId();
                Factory = new Factory(newDivisionId, txtName.Text.Trim(), null, 1, tools, workers, location);
            }
            else
            {
                Factory.Workers = workers;
                Factory.ToolPark = tools;
                Factory.Location = location;
            }

            Factory.ProductDefinition = _market.ItemDefinitions[(Enums.ItemType)cmbProductsList.SelectedValue];
            Factory.RentalCost = float.Parse(txtBoxRentalCost.Text, CultureInfo.InvariantCulture);
        }

        public bool isNumber(char ch, string text)
        {
            bool res = true;
            char decimalChar = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            //check if it´s a decimal separator and if doesn´t already have one in the text string
            if (ch == decimalChar && text.IndexOf(decimalChar) != -1)
            {
                res = false;
                return res;
            }

            //check if it´s a digit, decimal separator and backspace
            if (!Char.IsDigit(ch) && ch != decimalChar && ch != (char)Keys.Back)
                res = false;

            return res;
        }

        private void txtBoxWorkersTechLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!isNumber(e.KeyChar, txtBoxWorkersTechLevel.Text))
                e.Handled = true;
        }

        private void txtBoxRentalCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!isNumber(e.KeyChar, txtBoxRentalCost.Text))
                e.Handled = true;
        }

        private void txtBoxToolsTechLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!isNumber(e.KeyChar, txtBoxToolsTechLevel.Text))
                e.Handled = true;
        }
    }
}
