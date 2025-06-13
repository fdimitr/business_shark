using System.ComponentModel;
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
            public int DevisionId { get; init; }
            public string DivisionName { get; init; }
            public string City { get; init; }
            public int ExistingQuantity { get; init; }
            public int RequestedQuantity { get; set; }
            public float DeliveryPrice { get; init; }
        }

        private readonly Market _market;
        private Enums.ItemType _requestedItemType;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Routes> Routes { get; set; }

        public FrmRouteEditor(Market market, List<Routes> routes)
        {
            InitializeComponent();
            _market = market;
            Routes = routes;

            BindRequestedItems();

            // Attach event handler for editing control showing
            dataGridViewRoutes.EditingControlShowing += dataGridViewRoutes_EditingControlShowing;
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
            SaveRoutes();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbRequestedItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            _requestedItemType = (Enums.ItemType)cmbRequestedItems.SelectedValue!;

            var routeViewModels = _market.Cities
                .SelectMany(city => city.Warehouses
                    .Where(wh => wh.WarehouseOutput.ContainsKey(_requestedItemType))
                    .Select(wh => new RouteViewModel
                    {
                        IsRoute = false,
                        DevisionId = wh.DivisionId,
                        DivisionName = wh.Name,
                        City = city.Name,
                        ExistingQuantity = wh.WarehouseOutput[_requestedItemType].Quantity,
                        RequestedQuantity = 0,
                        DeliveryPrice = 0f
                    }))
                .ToList();

            routeViewModels.AddRange(_market.Cities
                .SelectMany(city => city.Sources
                    .Where(wh => wh.WarehouseOutput.ContainsKey(_requestedItemType))
                    .Select(wh => new RouteViewModel
                    {
                        IsRoute = false,
                        DevisionId = wh.DivisionId,
                        DivisionName = wh.Name,
                        City = city.Name,
                        ExistingQuantity = wh.WarehouseOutput[_requestedItemType].Quantity,
                        RequestedQuantity = 0,
                        DeliveryPrice = 0f
                    }))
                .ToList());

            routeViewModels.AddRange(_market.Cities
                .SelectMany(city => city.Factories
                    .Where(fb => fb.WarehouseOutput.ContainsKey(_requestedItemType))
                    .Select(fb => new RouteViewModel
                    {
                        IsRoute = false,
                        DevisionId = fb.DivisionId,
                        DivisionName = fb.Name,
                        City = city.Name,
                        ExistingQuantity = fb.WarehouseOutput[_requestedItemType].Quantity,
                        RequestedQuantity = 0,
                        DeliveryPrice = 0f
                    }))
                .ToList());

            foreach (var route in Routes.Where(r => r.TransferringItemType == _requestedItemType))
            {
                var model = routeViewModels.FirstOrDefault(m => m.DevisionId == route.FromDivisionId);
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
            // Remove existing routes for the selected item type
            Routes.RemoveAll(r => r.TransferringItemType == _requestedItemType);

            // Iterate DataGridView rows and add new routes
            foreach (DataGridViewRow row in dataGridViewRoutes.Rows)
            {
                if (row.IsNewRow) continue;

                bool isRoute = (bool)row.Cells[0].Value!;
                int requestedQuantity = Convert.ToInt32(row.Cells[5].Value);

                if (!isRoute || requestedQuantity <= 0)
                    continue;

                int divisionId = Convert.ToInt32(row.Cells[6].Value);

                // Find the DeliveryDivision by divisionId
                DeliveryDivision? fromDivision = _market.Cities
                    .SelectMany(city => city.Warehouses
                        .Concat(city.Factories.Cast<DeliveryDivision>()))
                    .FirstOrDefault(div => div.DivisionId == divisionId);
                if (fromDivision == null)
                {
                    fromDivision = _market.Cities
                    .SelectMany(city => city.Warehouses
                        .Concat(city.Sources.Cast<DeliveryDivision>()))
                    .FirstOrDefault(div => div.DivisionId == divisionId);
                }
                if (fromDivision == null)
                    continue;

                // For this context, assume ToDivision is not set (or set to null)
                var route = new Routes(fromDivision.DivisionId, _requestedItemType, requestedQuantity);
                Routes.Add(route);
            }
        }

        private void cmbRequestedItems_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SaveRoutes();
        }

        private void dataGridViewRoutes_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }

        private void dataGridViewRoutes_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridViewRoutes.CurrentCell.ColumnIndex == 5 && e.Control is TextBox tb)
            {
                tb.KeyPress -= RequestedQuantity_KeyPress; // Avoid attaching multiple times
                tb.KeyPress += RequestedQuantity_KeyPress;
            }
            else if (e.Control is TextBox tb2)
            {
                tb2.KeyPress -= RequestedQuantity_KeyPress;
            }
        }

        private void RequestedQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits and control keys (like backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
