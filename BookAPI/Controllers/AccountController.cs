using System.Threading.Tasks;
using BookAPI.Models;
using BookAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody]SignUpModel signUpModel)
        {
            var result = await _accountRepository.SignUpAsync(signUpModel);
            if (result != null)
            {
                return Ok($"Sign Up Ok {result}");
            }

            return Unauthorized(result);
        }


        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody]SignInModel signInModel)
        {
            var result = await _accountRepository.SignInAsync(signInModel);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized(result);
            }

            return Ok($"SignIn Ok {result}");
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _accountRepository.GetAll());
        }
    }
}