namespace ESchoolApi.Models;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Institution { get; set; }
    public string Role { get; set; }
    public string CreatedAt { get; set; }
    public string UpdatedOn { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    
    public virtual ICollection<UsersQualification> UsersQualifications { get; set; }
}