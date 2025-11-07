using Microsoft.AspNetCore.Http;
using Readify.Domain.Core.User.Enums;

namespace Readify.Domain.Core.User.DTOs;

public class CreateUserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public IFormFile? ImgFile { get; set; }
    public string? ImgUrl { get; set; }
    public RoleEnum Role { get; set; }
}