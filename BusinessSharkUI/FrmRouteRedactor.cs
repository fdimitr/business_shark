using System.ComponentModel;
using BusinessShark.Core;

namespace BusinessSharkUI
{
    internal partial class FrmRouteRedactor : Form
    {
        private Market _market;
        public FrmRouteRedactor(Market market)
        {
            InitializeComponent();
            _market = market;
            foreach (var city in _market.Cities)
            {
                
            }

        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            
        }
    }
}
