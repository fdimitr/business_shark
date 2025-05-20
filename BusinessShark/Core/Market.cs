using BusinessShark.Core.Item;
using BusinessShark.Database;
using BusinessShark.Database.Models;
using Dapper;
using static BusinessShark.Core.Item.Enums;

namespace BusinessShark.Core
{
    internal class Market
    {
        public List<City> Cities = new();

        public Dictionary<Enums.ItemType, ItemDefinition> ItemDefinitions = new();

        public Market()
        {
            LoadItemDefinitions();
            // Initialize the market with some cities and factories if needed
        }

        public void CalculateDay()
        {
            foreach (var city in Cities)
            {
                foreach (var factory in city.Factories)
                {
                    factory.Production();
                } 
            }
        }

        public void LoadItemDefinitions()
        {
            using var con = DatabaseHelper.GetSqlConnection();
            var sql =
                @"SELECT i.ItemDefinitionId, i.ItemGroupId, i.Name, i.Volume, i.ProductionCount, i.TechImpactQuality, i.ToolImpactQuality, i.WorkerImpactQuality,
                            i.TechImpactQuantity, i.ToolImpactQuantity, i.WorkerImpactQuantity, i.SourceImpactQuality,
                            p.ItemDefinitionId, p.ComponentDefinitionId, p.ProductionQuantity, p.QualityImpact
                        FROM ItemDefinition i LEFT OUTER JOIN ProductionUnit p ON i.ItemDefinitionId = p.ItemDefinitionId";

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
                            definitionDto.ItemDefinitionId,
                            definitionDto.Name,
                            definitionDto.Volume,
                            definitionDto.ProductionCount,
                            definitionDto.TechImpactQuality,
                            definitionDto.ToolImpactQuality,
                            definitionDto.WorkerImpactQuality,
                            definitionDto.SourceImpactQuality,
                            definitionDto.TechImpactQuantity,
                            definitionDto.ToolImpactQuantity,
                            definitionDto.WorkerImpactQuantity);

                        ItemDefinitions.Add((ItemType)definitionDto.ItemDefinitionId, definition);
                    }

                    if (productionDto != null)
                    {
                        definition.ProductionUnits.Add(new ProductionUnit(
                            productionDto.ComponentDefinitionId,
                            productionDto.ItemDefinitionId,
                            productionDto.ProductionQuantity,
                            productionDto.QualityImpact));
                    }

                    return definition;
                }, splitOn: "ItemDefinitionId");
        }
    }
}
