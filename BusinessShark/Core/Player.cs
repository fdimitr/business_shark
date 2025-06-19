using BusinessShark.Exceptions;
using MessagePack;

namespace BusinessShark.Core
{
    [MessagePackObject(keyAsPropertyName: true)]
    internal class Player
    {
        public string Name { get; set; }
        public double Wallet { get; set; }
        public int Reputation { get; set; }

        // Dictionary to hold technology types and their levels
        public Dictionary<Enums.TechType, int> TechnologyLevels { get; set; } = new();

        public Player(string name)
        {
            Name = name;
            Wallet = 10000; // Starting money
            Reputation = 0;

            // Fill Technologies with all TechType values, each with value 1
            foreach (Enums.TechType tech in Enum.GetValues(typeof(Enums.TechType)))
            {
                TechnologyLevels[tech] = 1;
            }
        }
        public void EarnMoney(int amount)
        {
            Wallet += amount;
        }

        public void SpendMoney(int amount)
        {
            if (Wallet >= amount)
                Wallet -= amount;
            else
                throw new NotEnoughMoneyException("Not enough money.");
        }
    }
}
