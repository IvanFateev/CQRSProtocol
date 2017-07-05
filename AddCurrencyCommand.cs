namespace CQRS
{
    class AddCurrencyCommand : Command
    {
        public string currencyId;
        public int value;
    }
}
