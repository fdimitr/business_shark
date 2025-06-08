using BusinessShark.Core.Item;
using BusinessShark.Database;
using BusinessShark.Database.Models;
using Dapper;
using MessagePack;
using static BusinessShark.Core.Item.Enums;

namespace BusinessShark.Core
{
    [MessagePackObject(keyAsPropertyName: true)]
    internal class Market
    {
        public DateTime CurrentDate { get; set; } = new DateTime(1970, 1, 1);
        public List<City> Cities { get; set; } = new();

        [NonSerialized]
        public Dictionary<ItemType, ItemDefinition> ItemDefinitions = new();


        public Market()
        {
            LoadItemDefinitions();
            // Initialize the market with some cities and factories if needed
        }

        public void CalculateDay()
        {
            StartCalculation();

            CompleteCalculation();

            UpdatePrices();

            CurrentDate = CurrentDate.AddDays(1);
        }

        private void UpdatePrices()
        {
            foreach (var city in Cities)
            {
                
                foreach (var factory in city.Factories)
                {
                    factory.ProgressPrice += city.LandTax;
                }
            }
        }
        private void CompleteCalculation()
        {
            // Complete the calculation for each city and its factories
            foreach (var city in Cities)
            {
                foreach (var warehouse in city.Warehouses)
                {
                    warehouse.CompleteTransferItems();
                }
                foreach (var factory in city.Factories)
                {
                    factory.CompleteTransferItems();
                    factory.CompleteCalculation();
                }
                foreach (var source in city.Sources)
                {
                    source.CompleteCalculation();
                }
            }
        }

        private void StartCalculation()
        {
            // Start the calculation for each city and its factories
            foreach (var city in Cities)
            {
                foreach (var warehouse in city.Warehouses)
                {
                    warehouse.StartTransferItems(this);
                }

                foreach (var factory in city.Factories)
                {
                    factory.StartTransferItems(this);
                    factory.StartCalculation();
                }
                foreach (var source in city.Sources)
                {
                    source.StartCalculation();
                }
            }
        }

        public DeliveryDivision GetDeliveryDivisionById(int divisionId)
        {
            foreach (var city in Cities)
            {
                foreach (var warehouse in city.Warehouses)
                {
                    if (warehouse.DivisionId == divisionId)
                    {
                        return warehouse;
                    }
                }
                foreach (var factory in city.Factories)
                {
                    if (factory.DivisionId == divisionId)
                    {
                        return factory;
                    }
                }
            }
            return null!; // Return null if no division found with the given ID
        }

        public int GetNewDivisionId()
        {
            int maxId = 0;
            foreach (var city in Cities)
            {
                if (city.Warehouses.Count > 0)
                {
                    int cityWarehouseMax = city.Warehouses.Max(w => w.DivisionId);
                    if (cityWarehouseMax > maxId)
                        maxId = cityWarehouseMax;
                }
                if (city.Factories.Count > 0)
                {
                    int cityFactoryMax = city.Factories.Max(f => f.DivisionId);
                    if (cityFactoryMax > maxId)
                        maxId = cityFactoryMax;
                }
            }
            return maxId + 1;
        }

        public void LoadItemDefinitions()
        {
            using var con = DatabaseHelper.GetSqlConnection();
            var sql =
                @"SELECT i.ItemDefinitionId, i.ItemGroupId, i.Name, i.Volume, i.ProductionCount, i.TechImpactQuality, i.ToolImpactQuality, i.WorkerImpactQuality,
                            i.TechImpactQuantity, i.ToolImpactQuantity, i.WorkerImpactQuantity, i.SourceImpactQuality, i.ProductionPrice,
                            p.ProductDefinitionId, p.ComponentDefinitionId, p.ProductionQuantity, p.QualityImpact
                        FROM ItemDefinition i LEFT OUTER JOIN ProductionUnit p ON i.ItemDefinitionId = p.ProductDefinitionId";

            con.Query<ItemDefinitionDto, ProductionUnitDto?, ItemDefinition>(sql,
                (definitionDto, productionDto) =>
                {
                    ItemDefinition definition;
                    if (ItemDefinitions.TryGetValue((ItemType)definitionDto.ItemDefinitionId, out var existingDefinition))
                    {
                        definition = existingDefinition;
                    }
                    else
                    {
                        definition = new ItemDefinition(
                            (ItemType)definitionDto.ItemDefinitionId,
                            definitionDto.Name,
                            definitionDto.Volume,
                            definitionDto.ProductionCount,
                            definitionDto.TechImpactQuality,
                            definitionDto.ToolImpactQuality,
                            definitionDto.WorkerImpactQuality,
                            definitionDto.SourceImpactQuality,
                            definitionDto.TechImpactQuantity,
                            definitionDto.ToolImpactQuantity,
                            definitionDto.WorkerImpactQuantity,
                            definitionDto.ProductionPrice);

                        ItemDefinitions.Add((ItemType)definitionDto.ItemDefinitionId, definition);
                    }

                    if (productionDto != null)
                    {
                        definition.ProductionUnits.Add(new ProductionUnit(
                            (ItemType)productionDto.ProductDefinitionId,
                            (ItemType)productionDto.ComponentDefinitionId,
                            productionDto.ProductionQuantity,
                            productionDto.QualityImpact));
                    }

                    return definition;
                }, splitOn: "ProductDefinitionId");

            foreach (var kvp in ItemDefinitions)
            {
                kvp.Value.CheckTotalImpact();
            }
        }
    }
}
