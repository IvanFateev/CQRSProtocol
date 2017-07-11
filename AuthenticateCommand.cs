namespace CQRS
{
    public class AuthenticateCommand : Command
    {
        public string userId;
        public string password;
    }
}
