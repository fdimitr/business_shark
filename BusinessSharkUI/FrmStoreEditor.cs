using BusinessShark.Core;
using System.ComponentModel;

namespace BusinessSharkUI
{
    internal partial class FrmStoreEditor : Form
    {
        private Market _market;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string StoreName
        {
            get => txtName.Text;
            set => txtName.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int StoreXCoordinate
        {
            get => Convert.ToInt32(txtXCoordinate.Text);
            set => Convert.ToInt32(txtXCoordinate.Text);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int StoreYCoordinate
        {
            get => Convert.ToInt32(txtYCoordinate.Text);
            set => Convert.ToInt32(txtYCoordinate.Text);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int StoreRange
        {
            get => Convert.ToInt32(txtRange.Text);
            set => Convert.ToInt32(txtRange.Text);
        }


        public FrmStoreEditor(Market market)
        {
            InitializeComponent();
            _market = market;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(StoreName))
            {
                MessageBox.Show("Name is required.");
                DialogResult = DialogResult.None;
                return;
            }

            DialogResult = DialogResult.OK;
        }
    }
}
