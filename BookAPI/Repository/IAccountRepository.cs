using System.Collections.Generic;
using System.Threading.Tasks;
using BookAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace BookAPI.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
        Task<string> SignInAsync(SignInModel signInModel);
        Task<List<ApplicationUser>> GetAll();
    }
}