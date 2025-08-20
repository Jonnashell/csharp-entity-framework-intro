using exercise.webapi.Data;
using exercise.webapi.DTOs;
using exercise.webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.webapi.Repository
{
    public class BookRepository: IBookRepository
    {
        DataContext _db;
        
        public BookRepository(DataContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
          return await _db.Books.Include(b => b.Author).Include(b => b.Publisher).ToListAsync();

        }
        public async Task<Book> GetBook(int id)
        {
            return await _db.Books.Include(b => b.Author).Include(b => b.Publisher).FirstOrDefaultAsync(b => b.Id == id);
        }
        public async Task<Book> Update(int id, Book model)
        {
            var entity = await GetBook(id); //await _db.Books.FindAsync(id);
            entity = model;
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<Book> Delete(int id)
        {
            var entity = await GetBook(id);
            _db.Books.Remove(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<Book> Create(Book model)
        {
            await _db.AddAsync(model);
            await _db.SaveChangesAsync();
            return model;
        }
    }
}
