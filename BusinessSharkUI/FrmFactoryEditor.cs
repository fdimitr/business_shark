using BusinessShark.Core;
using BusinessShark.Core.Item;
using System.ComponentModel;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace BusinessSharkUI
{
    
    internal partial class FrmFactoryEditor : Form
    {
        private Market _market;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FactoryName
        {
            get => txtName.Text;
            set => txtName.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Enums.ItemType ProductType
        {
            get => cmbProductsList.SelectedValue == null ? throw new Exception("Production type wasn't specified") : (Enums.ItemType)cmbProductsList.SelectedValue;
            set => cmbProductsList.SelectedValue = value;
        }

        

        public FrmFactoryEditor(Market market)
        {
            InitializeComponent();
            _market = market;
            //foreach (var item in _market.ItemDefinitions.Values)
            //{
            //    if (item.ProductionUnits.Count > 0)
            //    {
            //        cmbProductsList.Items.Insert((int)item.ItemDefinitionId, item.Name);
            //    }
            //}
            cmbProductsList.DataSource = _market.ItemDefinitions.Values.Where(i=>i.ProductionUnits.Count > 0).ToList();
            cmbProductsList.DisplayMember = "Name";
            cmbProductsList.ValueMember = "ItemDefinitionId";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(FactoryName))
            {
                MessageBox.Show("Name is required.");
                DialogResult = DialogResult.None;
                return;
            }
            
           
            DialogResult = DialogResult.OK;
        }
    }
}
