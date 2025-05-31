using BusinessShark.Core;
using BusinessShark.Core.Item;

namespace BusinessSharkUI
{
    internal partial class FrmRouteEditor : Form
    {

        // Model to represent a route in the DataGridView
        private class RouteViewModel
        {
            public bool IsRoute { get; set; }
            public string DivisionName { get; set; }
            public string City { get; set; }
            public int ExistingQuantity { get; set; }
            public int RequestedQuantity { get; set; }
            public float DeliveryPrice { get; set; }
        }

        private readonly Market _market;
        public FrmRouteEditor(Market market)
        {
            InitializeComponent();
            _market = market;

            BindRequestedItems();
        }

        private void BindRequestedItems()
        {
            cmbRequestedItems.DisplayMember = "Name";
            cmbRequestedItems.ValueMember = "ItemDefinitionId";
            cmbRequestedItems.DataSource = _market.ItemDefinitions.Values.ToList();
        }

        private void BindDataGridViewRoutes(List<RouteViewModel> routeViewModels)
        {
            dataGridViewRoutes.Rows.Clear();
            foreach (var model in routeViewModels)
            {
                dataGridViewRoutes.Rows.Add(model.IsRoute, model.DivisionName, model.City, model.DeliveryPrice,
                    model.ExistingQuantity, model.RequestedQuantity);
            }

        }


        private void btnOK_Click(object sender, EventArgs e)
        {
        }

        private void cmbRequestedItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            var requestedItem = (Enums.ItemType)cmbRequestedItems.SelectedValue!;

            var routeViewModels = _market.Cities
                .SelectMany(city => city.Warehouses
                    .Where(wh => wh.WarehouseOutput.ContainsKey(requestedItem))
                    .Select(wh => new RouteViewModel
                    {
                        IsRoute = false,
                        DivisionName = wh.Name,
                        City = city.Name,
                        ExistingQuantity = wh.WarehouseOutput[requestedItem].Quantity,
                        RequestedQuantity = 0,
                        DeliveryPrice = 0f
                    }))
                .ToList();
            routeViewModels.AddRange(_market.Cities
                .SelectMany(city => city.Factories
                    .Where(wh => wh.WarehouseOutput.ContainsKey(requestedItem))
                    .Select(wh => new RouteViewModel
                    {
                        IsRoute = false,
                        DivisionName = wh.Name,
                        City = city.Name,
                        ExistingQuantity = wh.WarehouseOutput[requestedItem].Quantity,
                        RequestedQuantity = 0,
                        DeliveryPrice = 0f
                    }))
                .ToList());

            BindDataGridViewRoutes(routeViewModels);
        }
    }
}
