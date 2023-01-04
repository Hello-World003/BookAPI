using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookAPI.Data;
using BookAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Repository
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public BooksRepository(BookStoreContext _context, IMapper mapper)
        {
            this._context = _context;
            this._mapper = mapper;
        }

        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            // var records = await _context.Books.Select(x => new BookModel()
            // {
            //     Id = x.Id,
            //     Title = x.Title,
            //     Description = x.Description
            // }).ToListAsync();

            var records = await _context.Books.ToListAsync();
            return _mapper.Map<List<BookModel>>(records);
        }


        public async Task<BookModel> GetBookByIdAsync(int bookId)
        {
            // var record = await _context.Books.Where(x=>x.Id==bookId).Select(x => new BookModel()
            // {
            //     Id = x.Id,
            //     Title = x.Title,
            //     Description = x.Description
            // }).FirstOrDefaultAsync();
            var record = await _context.Books.FindAsync(bookId);
            if (record == null)
            {
                return null;
            }
            return _mapper.Map<BookModel>(record);
        }


        public async Task<int> AddBookAsync(BookModel book)
        {
            var books = new Books()
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description
            };

             _context.Books.Add(books);
             await _context.SaveChangesAsync();
             return book.Id;
        }

        public async Task<Books> UpdateBookAsyn(int bookId, BookModel updateBook)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book != null)
            {
                //book.Id = updateBook.Id;
                book.Title = updateBook.Title;
                book.Description = updateBook.Description;
                await _context.SaveChangesAsync();
                
            }
            return book;
        }

        public async Task UpdateBookAsyn2(int bookId, BookModel updateBook)
        {
            var bok = new Books()
            {
                Id = updateBook.Id,
                Title = updateBook.Title,
                Description = updateBook.Description
            };

            _context.Books.Update(bok);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookPatchAsyn(int id, JsonPatchDocument bookModel)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                bookModel.ApplyTo(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = new Books() { Id = id };
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}