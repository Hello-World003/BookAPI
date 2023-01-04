using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using BookAPI.Models;
using BookAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;

namespace BookAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;

        public BooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        
        /// <summary>
        /// Get ALL book
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        [Authorize]
        public async Task<IActionResult> GetAllBook()
        {
            var books =await _booksRepository.GetAllBooksAsync();
            return Ok(books);
        }

        
        /// <summary>
        /// Find Book By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllBookById([FromRoute] int id)
        {
            var books = await _booksRepository.GetBookByIdAsync(id);
            if (books == null)
            {
                return NotFound();
            }
            return Ok(books);
        }

        
        /// <summary>
        /// AddBook
        /// </summary>
        [HttpPost("")]
        public async Task<IActionResult> AddNewBook([FromBody]BookModel book)
        {
          await _booksRepository.AddBookAsync(book);
            return Ok($"Post Ok ID={book.Id} , Title={book.Title} , Description={book.Description}");
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromRoute]int id,[FromBody]BookModel book)
        {
           var update=   await _booksRepository.UpdateBookAsyn(id, book);
           if (update == null)
           {
               return NotFound();
           }
            return Ok($"Update Success ID={id} , Title={book.Title} , Description={book.Description}");
        }


        [HttpPut("update1/{id}")]
        public async Task<IActionResult> UpdateBook1([FromBody]BookModel book,[FromRoute] int id)
        {
            await _booksRepository.UpdateBookAsyn2(id, book);
            return Ok($"Update1 Ok");
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBookPatch([FromRoute]int id,[FromBody] JsonPatchDocument book)
        {
            await _booksRepository.UpdateBookPatchAsyn(id, book);
            return Ok($"Update Patch Ok");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _booksRepository.DeleteBookAsync(id);
            return Ok($"Delete Ok Id={id}");
        }
    }
}