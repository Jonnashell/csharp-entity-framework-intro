using exercise.webapi.Models;

namespace exercise.webapi.Repository
{
    public interface IBookRepository
    {
        public Task<IEnumerable<Book>> GetAllBooks();
        public Task<Book> GetBook(int id);
        public Task<Book> Update(int id, Book model);
        public Task<Book> Delete(int id);
        public Task<Book> Create(Book model);
    }
}
