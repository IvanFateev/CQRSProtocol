namespace CQRS
{
    public class Command
    {
        string guid;
        string userId;
        public virtual void Execute() { }
    }
}