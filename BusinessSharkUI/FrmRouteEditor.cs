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
            public int DevisionId { get; set; }
            public string DivisionName { get; set; }
            public string City { get; set; }
            public int ExistingQuantity { get; set; }
            public int RequestedQuantity { get; set; }
            public float DeliveryPrice { get; set; }
        }

        private readonly Market _market;
        private readonly List<Routes> _routes;

        public FrmRouteEditor(Market market, List<Routes> routes)
        {
            InitializeComponent();
            _market = market;
            _routes = routes;

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
                    model.ExistingQuantity, model.RequestedQuantity, model.DevisionId);
            }

        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbRequestedItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            var requestedItemType = (Enums.ItemType)cmbRequestedItems.SelectedValue!;

            var routeViewModels = _market.Cities
                .SelectMany(city => city.Warehouses
                    .Where(wh => wh.WarehouseOutput.ContainsKey(requestedItemType))
                    .Select(wh => new RouteViewModel
                    {
                        IsRoute = false,
                        DevisionId = wh.DivisionId,
                        DivisionName = wh.Name,
                        City = city.Name,
                        ExistingQuantity = wh.WarehouseOutput[requestedItemType].Quantity,
                        RequestedQuantity = 0,
                        DeliveryPrice = 0f
                    }))
                .ToList();

            routeViewModels.AddRange(_market.Cities
                .SelectMany(city => city.Factories
                    .Where(fb => fb.WarehouseOutput.ContainsKey(requestedItemType))
                    .Select(fb => new RouteViewModel
                    {
                        IsRoute = false,
                        DevisionId = fb.DivisionId,
                        DivisionName = fb.Name,
                        City = city.Name,
                        ExistingQuantity = fb.WarehouseOutput[requestedItemType].Quantity,
                        RequestedQuantity = 0,
                        DeliveryPrice = 0f
                    }))
                .ToList());

            foreach (var route in _routes.Where(r => r.TransferringItemType == requestedItemType))
            {
                var model = routeViewModels.FirstOrDefault(m => m.DevisionId == route.FromDivision.DivisionId);
                if (model != null)
                {
                    model.IsRoute = true;
                    model.RequestedQuantity = route.TransferringCount;
                }
            }

            BindDataGridViewRoutes(routeViewModels);
        }

        private void SaveRoutes()
        {
            foreach (var row in dataGridViewRoutes.Rows)
            {

            }
        }
    }
}
