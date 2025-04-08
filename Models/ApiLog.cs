namespace Security_with_Password_Hashing.Models
{
    public class ApiLog
    {
        public int LogId { get; set; }
        public string Action { get; set; }
        public DateTime Timestamp { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }

}
