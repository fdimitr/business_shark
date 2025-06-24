using MessagePack;

namespace BusinessShark.Core.Divisions
{
    [MessagePackObject(keyAsPropertyName: true)]
    internal class DivisionSize
    {
        public int Width { get; }
        public int Height { get; }

        public DivisionSize(Enums.SizeType sizeType)
        {
            switch (sizeType)
            {
                case Enums.SizeType.OneByOne:
                    Width = 1;
                    Height = 1;
                    break;
                case Enums.SizeType.TwoByTwo:
                    Width = 2;
                    Height = 2;
                    break;
                case Enums.SizeType.TwoByOne:
                    Width = 2;
                    Height = 1;
                    break;
                case Enums.SizeType.OneByTwo:
                    Width = 1;
                    Height = 2;
                    break;
                case Enums.SizeType.OneByThree:
                    Width = 1;
                    Height = 3;
                    break;
                case Enums.SizeType.ThreeByOne:
                    Width = 3;
                    Height = 1;
                    break;
                case Enums.SizeType.ThreeByTwo:
                    Width = 3;
                    Height = 2;
                    break;
                case Enums.SizeType.TwoByThree:
                    Width = 2;
                    Height = 3;
                    break;
                case Enums.SizeType.ThreeByThree:
                    Width = 3;
                    Height = 3;
                    break;
            }
        }

        public override string ToString()
        {
            return $"{Width}x{Height}";
        }
    }
}
