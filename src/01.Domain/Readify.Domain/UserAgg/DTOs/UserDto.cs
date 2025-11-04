

using System.Security.AccessControl;
using Readify.Domain.UserAgg.Enums;

namespace Readify.Domain.UserAgg.DTOs
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
