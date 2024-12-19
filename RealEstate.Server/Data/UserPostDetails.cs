namespace RealEstate.Server.Data
{
    public class UserPostDetails
    {
        public int Id { get; set; }
        public EnergyClass EnergyClass { get; set; } 
        public string Description { get; set; }
        public PetOption Pet { get; set; }
        public int Size { get; set; }
    }

    public enum EnergyClass
    {
        None,
        A,
        B,
        C,
        D,
        F,
        G,
        H
    }

    public enum PetOption
    {
        Yes,
        No
    }
}
