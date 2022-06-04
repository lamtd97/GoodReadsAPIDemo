
using Entity.Models;

namespace Contracts
{
    public interface IUserRepository: IRepositoryBase<User>
    {
        IEnumerable<User> UserDetail(Guid ownerId);
    }
}
