using BusinessShark.Core;
using BusinessShark.Core.Item;
using System.ComponentModel;

namespace BusinessSharkUI
{
    internal partial class FrmSourceEditor : Form
    {

        private Market _market;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SourceName
        {
            get => txtName.Text;
            set => txtName.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Enums.ItemType ResourceType
        {
            get => cmbResourceList.SelectedValue == null ? throw new Exception("Production type wasn't specified") : (Enums.ItemType)cmbResourceList.SelectedValue;
            set => cmbResourceList.SelectedValue = value;
        }

        public FrmSourceEditor(Market market)
        {
            InitializeComponent();
            _market = market;
            cmbResourceList.DataSource = _market.ItemDefinitions.Values.Where(i => i.ProductionUnits.Count == 0).ToList();
            cmbResourceList.DisplayMember = "Name";
            cmbResourceList.ValueMember = "ItemDefinitionId";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SourceName))
            {
                MessageBox.Show("Name is required.");
                DialogResult = DialogResult.None;
                return;
            }


            DialogResult = DialogResult.OK;
        }
    }
}
