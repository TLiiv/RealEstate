namespace RealEstate.Server.Data
{
    public class Image
    {
        public Guid ImageId { get; set; }  
        public string FileName { get; set; } 
        public string FilePath { get; set; } 
        public Guid UserPostId { get; set; }  
        public UserPost UserPost { get; set; }  
    }
}
