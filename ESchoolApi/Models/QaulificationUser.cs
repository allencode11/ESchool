namespace ESchoolApi.Models;

public class QaulificationUser
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid QualificationId { get; set; }
    public User User { get; set; }
    public Qualification Qualification { get; set; }
}