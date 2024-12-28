namespace RealEstate.Server.Data
{
    public class District
    {
        public Guid DistrictId { get; set; }
        public string Name { get; set; }
        public Guid CityId { get; set; }
        public City City { get; set; }

    }
}
