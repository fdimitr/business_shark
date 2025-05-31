using BusinessShark.Core;
using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BusinessSharkUI
{
    internal partial class FrmRouteEditor : Form
    {
        private Dictionary <string, City> data = new Dictionary <string, City>();
        private Market _market;
        public FrmRouteEditor(Market market)
        {
            InitializeComponent();
            _market = market;
            foreach (var city in _market.Cities)
            {
                cmbStartCity.Items.Add(city.Name);
                cmbEndCity.Items.Add(city.Name);
                data[city.Name] = city;
            }

        }
        

        private void cmbStartCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = cmbStartCity.SelectedItem.ToString();

        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            
        }
    }
}
