namespace RealEstate.Server.Data
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public string UserPassword { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Avatar { get; set; }
        public List<UserPost> UserPosts { get; set; } = new List<UserPost>();

    }
}
