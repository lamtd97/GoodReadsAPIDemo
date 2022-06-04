using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper 
    { 
        private RepositoryContext _repoContext; 
        private IBookRepository _book; 
        private IUserRepository _user; 
        private IUserBookRepository _userBook; 
        public IBookRepository Book 
        { 
            get 
            { 
                if (_book == null) 
                { 
                    _book = new BookRepository(_repoContext); 
                } 
                return _book; 
            } 
        } 
        
        public IUserRepository User 
        { 
            get 
            { 
                if (_user == null) 
                { 
                    _user = new UserRepository(_repoContext); 
                } 
                return _user; 
            } 
        }

        public IUserBookRepository UserBook
        {
            get
            {
                if (_userBook == null)
                {
                    _userBook = new UserBooksRepository(_repoContext);
                }
                return _userBook;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext) 
        { 
            _repoContext = repositoryContext; 
        } 
        
        public void Save() 
        {
            _repoContext.SaveChanges();
        } 
    }
}
