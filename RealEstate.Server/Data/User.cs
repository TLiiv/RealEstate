
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Server.Data
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,50}$",
        ErrorMessage = "Characters are not allowed.")]
        public string UserFirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,50}$",
         ErrorMessage = "Characters are not allowed.")]
        public string UserLastName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string UserPassword { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Avatar { get; set; }
        public List<UserPost> UserPosts { get; set; } = new List<UserPost>();

    }
}
