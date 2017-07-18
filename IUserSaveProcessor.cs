namespace CQRS
{
    public interface IUserSaveProcessor
    {
        void Process(UserSave user);
    }
}
