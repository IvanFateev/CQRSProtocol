namespace CQRS
{
    public class AddCurrencyCommand : Command
    {
        public string currencyId;
        public int value;
    }
}
