namespace Security_with_Password_Hashing.Models
{
    public class User
{
    public int UserId { get; set; }
    public string? Username { get; set; }
    public string? PasswordHash { get; set; }
    public string? Role { get; set; }
}

}