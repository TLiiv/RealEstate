namespace RealEstate.Server.Data
{
    public class City
    {
        public Guid CityId { get; set; }
        public string Name { get; set; }
        public Guid CountyId { get; set; }
        public County County { get; set; }
        public List<District> Districts { get; set; } = new List<District>();
    }
}
