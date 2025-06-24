namespace BusinessShark.Core
{
    internal static class Enums
    {
        internal enum ItemType
        {
            Wood = 1,
            Leather = 2,
            Bed = 3
        }
        internal enum ResourceType
        {
            None,
            Forest,
            Agriculture
        }

        internal enum TechType
        {
            WoodProcessing = 1,
            FurnitureProduction = 2,
        }

        internal enum SizeType
        {
            OneByOne,    // 1x1
            TwoByTwo,    // 2x2
            TwoByOne,    // 2x1
            OneByTwo,    // 1x2
            OneByThree,  // 1x3
            ThreeByOne,  // 3x1
            ThreeByTwo,  // 3x2
            TwoByThree,  // 2x3
            ThreeByThree // 3x3
        }
    }
}
