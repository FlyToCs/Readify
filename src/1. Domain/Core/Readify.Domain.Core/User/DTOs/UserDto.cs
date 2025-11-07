

using System.Security.AccessControl;
using Readify.Domain.Core.User.Enums;

namespace Readify.Domain.Core.User.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public RoleEnum Role { get; set; }
        public string UserName { get; set; }
        public string? ImgUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
