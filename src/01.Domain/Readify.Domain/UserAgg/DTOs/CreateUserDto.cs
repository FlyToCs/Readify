using Readify.Domain.UserAgg.Enums;

namespace Readify.Domain.UserAgg.DTOs;

public class CreateUserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string HashedPassword { get; set; }
    public string ImgUrl { get; set; }
    public RoleEnum Role { get; set; }
}