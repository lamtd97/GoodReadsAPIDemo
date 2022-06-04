
using Entity.Models;

namespace Contracts
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(Guid bookId);
        Book GetBookWithDetails(Guid bookId);
        IEnumerable<Book> GetByName(string name = "");
    }
}
