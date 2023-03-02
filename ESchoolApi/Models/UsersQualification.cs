using System.ComponentModel.DataAnnotations.Schema;

namespace ESchoolApi.Models;

public class UsersQualification
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid QualificationId { get; set; }
    
    public User User { get; set; }
    public Qualification Qualification { get; set; }
    
    public Boolean Confirmed { get; set; }
    public DateTime CreatedAt { get; set; }
}