using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUserBookRepository : IRepositoryBase<UserBook>
    {
        UserBook GetUserBooks(Guid userId);

        bool AddReadingBook(UserBookVM userBook);

        bool UpdateReadBook(UserBookVM userBook);

        List<Book> GetListBookRead(Guid userId);
    }
}
