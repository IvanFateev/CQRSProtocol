namespace CQRS
{
    public class AddCurrencyCommand : Command, IUserSaveProcessor
    {
        public string currencyId;
        public int value;

        public void Process(UserSave user)
        {
            if (user.currencies == null)
            {
                user.currencies = new System.Collections.Generic.Dictionary<string, int>();
            }

            int count;

            if (!user.currencies.TryGetValue(currencyId, out count))
            {
                user.currencies[currencyId] = value;
            }
            else
            {
                user.currencies[currencyId] += value;
            }
        }
    }
}
