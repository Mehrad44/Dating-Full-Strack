using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace API.Dtos
{
    public class LoginDto
    {
        public string Email { get; set; } = "";

        public string Password { get; set; } = "";
    }
}