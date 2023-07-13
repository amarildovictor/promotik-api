using Microsoft.AspNetCore.Identity;

namespace PromoTik.Domain.Entities.Auth
{
    public class User : IdentityUser
    {
        public User() : base() { }

        public User(string userName) : base(userName) { }

        public string? Password { get; set; }

        public string? Token { get; set; }
    }
}