using BusinessShark.Core;
using BusinessShark.Core.Item;
using System.ComponentModel;
using System.Windows.Forms;

namespace BusinessSharkUI
{
    internal partial class FrmFactoryRedactor : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FactoryName
        {
            get => txtName.Text;
            set => txtName.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ProductType
        {
            get => cmbProductsList.Text;
            set => cmbProductsList.Text = value;
        }

        

        public FrmFactoryRedactor()
        {
            InitializeComponent();
            cmbProductsList.SelectedIndex = 0;

        }

        public FrmFactoryRedactor(Factory factory) : this()
        {
            FactoryName = factory.Name;
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
