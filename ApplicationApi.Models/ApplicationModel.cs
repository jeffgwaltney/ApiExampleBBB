namespace ApplicationApi.Models
{
    public class ApplicationModel
    {
        public int Id { get; set; }
        public DateTime DateTimeUpdated { get; set; }   
        public string Email { get; set; }   
        public string NameFirst { get; set; }   
        public string NameLast { get; set; }    
        public string BusinessName { get; set; }
        public string BusinessCategory { get; set; }
    }
}