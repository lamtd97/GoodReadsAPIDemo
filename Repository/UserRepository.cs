using Contracts;
using Entities;
using Entity.Models;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository 
    { 
        public UserRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext) 
        { 
        }

        public IEnumerable<User> UserDetail(Guid ownerId) =>
            FindByCondition(a => a.UserId.Equals(ownerId)).ToList();
        
    }
}
