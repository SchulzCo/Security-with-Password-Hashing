namespace Security_with_Password_Hashing.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }

}
