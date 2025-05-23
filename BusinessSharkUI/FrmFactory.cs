using System.ComponentModel;
using BusinessShark.Core;

namespace BusinessSharkUI
{
    public partial class FrmFactory : Form
    {
        private class FactoryView
        {
            [Category("General")]
            public string Name { get; set; }
            [Category("General")]
            public string City { get; set; }
            [Category("Production")]
            public string ProductionItem { get; set; }
            [Category("Production")]
            public float TechLevel { get; set; }
            [Category("Environment")]
            public Tools Tools { get; set; }
            [Category("Environment")]
            public Workers Workers { get; set; }

        }

        public FrmFactory()
        {
            InitializeComponent();
            factoryPropertyGrid.SelectedObject = new FactoryView
            {
                Name = "Factory 1",
                City = "New York",
                ProductionItem = "Widget",
                TechLevel = 1.0f,
                Tools = new Tools { TotalQuantity = 100, TechLevel = 1.0f, Deprecation = 0.8f },
                Workers = new Workers { TotalQuantity = 50, TechLevel = 1.0f }
            };
        }
    }
}
