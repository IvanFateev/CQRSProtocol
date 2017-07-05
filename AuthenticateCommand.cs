namespace CQRS
{
    class AuthenticateCommand : Command
    {
        public string userId;
        public string password;
    }
}
