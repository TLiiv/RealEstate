namespace RealEstate.Server.Data
{
    public class UserPostDetails
    {
        public Guid Id { get; set; }
        public EnergyClass EnergyClass { get; set; } 
        public string Description { get; set; }
        public PetOption Pet { get; set; }
        public int Size { get; set; }
        public int Floor { get; set; }
        public int FloorsInTotal { get; set; }
        public string HeatingSource { get; set; }
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
