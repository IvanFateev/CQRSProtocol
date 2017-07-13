namespace CQRS
{
    public class AuthenticateCommand : Command
    {
        public string login;
        public string password;
    }
}
