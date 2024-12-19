namespace RealEstate.Server.Data
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountyId { get; set; }
        public County County { get; set; }
        public List<District> Districts { get; set; } = new List<District>();
    }
}
