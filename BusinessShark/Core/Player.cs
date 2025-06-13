namespace BusinessShark.Core
{
    internal class Player
    {
        public string Name { get; set; }
        public double Wallet { get; set; }
        public int Reputation { get; set; }

        public Player(string name)
        {
            Name = name;
            Wallet = 10000; // Starting money
            Reputation = 0;
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
                throw new InvalidOperationException("Not enough money.");
        }
    }
}
