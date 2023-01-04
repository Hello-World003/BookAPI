using System;

namespace BookAPI.Dtos
{
    public class UserInfoDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
    }
}