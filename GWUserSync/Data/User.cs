namespace GWUserSync.Data;
public class User
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? GoogleId { get; set; }
    public DateTime Birthday { get; set; }
    public DateTime HireDate { get; set; }
    public string? Role { get; set; }
}
