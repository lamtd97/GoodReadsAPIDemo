using Contracts;
using Entities;
using Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return FindAll()
                .OrderBy(book => book.Name)
                .ToList();
        }

        public Book GetBookById(Guid bookId)
        {
            return FindByCondition(book => book.BookId.Equals(bookId))
                .FirstOrDefault();
        }

        public Book GetBookWithDetails(Guid bookId)
        {
            return FindByCondition(book => book.BookId.Equals(bookId))
                //.Include(ac => ac.Accounts)
                .FirstOrDefault();
        }

        public void CreateBook(Book book) => Create(book);

        public void UpdateBook(Book book) => Update(book);

        public void DeleteBook(Book book) => Delete(book);

        public IEnumerable<Book> GetByName(string name = "")
        {
            return FindByCondition(book => book.Name.Contains(name));
        }
    }
}
