using System.Threading.Tasks;

namespace CQRS
{
    public interface IUserSaveProcessor
    {
        Task Process(UserSave user);
    }
}
