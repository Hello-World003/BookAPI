using AutoMapper;
using BookAPI.Data;
using BookAPI.Models;

namespace BookAPI.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Books, BookModel>();
        }
    }
}