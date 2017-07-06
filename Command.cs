namespace CQRS
{
    public class Command
    {
    	public string connectionId;
        public string guid;
        public string userId;
        public virtual void Execute() { }
    }
}
