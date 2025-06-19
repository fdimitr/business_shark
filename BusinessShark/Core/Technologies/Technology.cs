using MessagePack;

namespace BusinessShark.Core.Technologies
{
    /// <summary>
    /// Represents a technology with an exponentially growing difficulty value.
    /// </summary>
    [MessagePackObject(keyAsPropertyName: true)]
    internal class Technology(Enums.TechType techType, string name, string description, float exponentBase)
    {
        public Enums.TechType TechType { get; } = techType;
        public string Name { get; } = name;
        private float ExponentBase { get; } = exponentBase;
        public string Description { get; } = description;

        /// <summary>
        /// Initializes a new instance of the Technology class.
        /// </summary>
        /// <param name="level">The level of the technology.</param>
        /// <param name="exponentBase">The base of the exponent (default: 2).</param>
        public int GetDifficultyValue (int level, double exponentBase = 1.5)
        {
            if (level < 1)
                throw new ArgumentOutOfRangeException(nameof(level), "Level must be at least 1.");

            int baseValue = 10; // The base value for exponential calculation

            // DifficultyValue grows exponentially: baseValue * (exponentBase ^ (level - 1))
            return (int)Math.Truncate(baseValue * Math.Pow(exponentBase, level - 1));
        }
    }
}