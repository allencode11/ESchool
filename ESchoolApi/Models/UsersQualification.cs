namespace ESchoolApi.Models;

public class UsersQualification
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User Users { get; set; }
    
    public Guid QualificationId { get; set; }
    public Qualification Qualifications { get; set; }
}