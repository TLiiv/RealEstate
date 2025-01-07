using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace RealEstate.Server.Data
{
    public class UserPost
    {
        [Key]
        public Guid UserPostId { get; set; }  // Primary Key

        public Guid UserId { get; set; }  // Foreign Key to User

        public User User { get; set; }  // Navigation Property to User
        public string Title { get; set; }
        public int Price { get; set; }
        public List<Image> Images { get; set; } = new List<Image>();
        public string Address { get; set; }
        public Guid CountyId { get; set; }
        public County County { get; set; }

        public Guid CityId { get; set; } 
        public City City { get; set; }

        public Guid DistrictId { get; set; }
        public District District { get; set; }
        public int Room {  get; set; }
        public int Bathroom { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Type { get; set; }
        public string Property { get; set; }
       
        public DateTime CreatedAt { get; set; }
    }

}
