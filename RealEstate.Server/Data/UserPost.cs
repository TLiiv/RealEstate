using System.Diagnostics.Metrics;

namespace RealEstate.Server.Data
{
    public class UserPost
    {
        public Guid UserPostId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public List<Images> Images { get; set; }
        public string Address { get; set; }
        public int CountyId { get; set; }
        public County County { get; set; }

        public int CityId { get; set; } 
        public City City { get; set; }

        public int DistrictId { get; set; }
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
