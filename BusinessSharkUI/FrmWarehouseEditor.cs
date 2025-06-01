using System.ComponentModel;
using BusinessShark.Core;

namespace BusinessSharkUI
{
    internal partial class FrmWarehouseEditor : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string WarehouseName
        {
            get => txtName.Text;
            set => txtName.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Volume
        {
            get => (int)numVolume.Value;
            set => numVolume.Value = value;
        }

        public FrmWarehouseEditor()
        {
            InitializeComponent();
        }

        public FrmWarehouseEditor(Warehouse warehouse) : this()
        {
            WarehouseName = warehouse.Name;
            Volume = warehouse.Volume;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(WarehouseName))
            {
                MessageBox.Show("Name is required.");
                DialogResult = DialogResult.None;
                return;
            }
            DialogResult = DialogResult.OK;
        }
    }
}