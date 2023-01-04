using System.Collections.Generic;
using System.Threading.Tasks;
using BookAPI.Data;
using BookAPI.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace BookAPI.Repository
{
    public interface IBooksRepository
    {
        Task<List<BookModel>> GetAllBooksAsync();
        Task<BookModel> GetBookByIdAsync(int bookId);
        Task<int> AddBookAsync(BookModel book);

        Task<Books> UpdateBookAsyn(int bookId, BookModel updateBook);
        Task UpdateBookAsyn2(int bookId, BookModel updateBook);

        Task UpdateBookPatchAsyn(int id, JsonPatchDocument bookModel);

        Task DeleteBookAsync(int id);
    }
}