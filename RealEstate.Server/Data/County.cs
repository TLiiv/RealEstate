namespace RealEstate.Server.Data
{
    public class County
    {
        public Guid CountyId { get; set; }
        public string Name { get; set; }
        public List<City> Cities { get; set; } = new List<City>();
    }
}
