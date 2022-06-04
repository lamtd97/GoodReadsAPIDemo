using Contracts;
using Entities;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserBooksRepository : RepositoryBase<UserBook>, IUserBookRepository
    {
        public UserBooksRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public UserBook GetUserBooks(Guid userId)
        {
            throw new NotImplementedException();
        }

        public bool AddReadingBook(UserBookVM userBook)
        {
            var oldUB = this.RepositoryContext.UserBooks.Where(c => c.UserId == userBook.UserId && c.BookId == userBook.BookId).FirstOrDefault();
            if (oldUB != null) return false;
            var ub = new UserBook()
            {
                BookId = userBook.BookId,
                UserId = userBook.UserId,
                ReadingStatus = userBook.ReadingStatus
            };
            Create(ub);
            Save();
            return true;
        }
        public bool UpdateReadBook(UserBookVM userBook)
        {
            var oldUB = this.RepositoryContext.UserBooks.Where(c => c.UserId == userBook.UserId && c.BookId == userBook.BookId).FirstOrDefault();
            if (oldUB == null) return false;
            var ub = new UserBook()
            {
                BookId = userBook.BookId,
                UserId = userBook.UserId,
                ReadingStatus = userBook.ReadingStatus,
                UserBookId = oldUB.UserBookId
            };
            Update(ub);
            Save();
            return true;
        }

        public List<Book> GetListBookRead(Guid userId)
        {
            var userBook = this.RepositoryContext.UserBooks.Where(c => c.UserId == userId && c.ReadingStatus == Entities.Enums.ReadingStatusEnum.Read).Select(n => new Book()
            {
                Name = n.Book.Name,
                BookId = n.Book.BookId,
                Cover = n.Book.Cover,
                DatePublication = n.Book.DatePublication,
                Description = n.Book.Description
            }).ToList(); ;
            return userBook;
        }

        private UserBook MappingObject(UserBook userBook)
        {
            var ub = new UserBook()
            {
                UserId = userBook.UserId,
                BookId = userBook.BookId,
                ReadingStatus = userBook.ReadingStatus,
            };
            if (userBook.UserBookId != 0)
            {
                ub.UserBookId = userBook.UserBookId;
            }
            return ub;
        }
    }
}
