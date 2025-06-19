namespace BusinessShark.Exceptions
{
    internal class NotEnoughMoneyException : Exception
    {
        public NotEnoughMoneyException()
            : base("Not enough money.") { }

        public NotEnoughMoneyException(string message)
            : base(message) { }

        public NotEnoughMoneyException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
