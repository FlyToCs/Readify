using Readify.Domain.UserAgg.Enums;

namespace Readify.UI_MVC.Models
{
    public class OnlineUser
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public RoleEnum Role { get; set; }
        public bool IsActive { get; set; }
    }
}
