
using Microsoft.EntityFrameworkCore;

namespace ESchoolApi.Models;

public class Qualification
{
    public Guid Id { get; set; }
    public Guid DisciplineId { get; set; }
    public virtual ICollection<UsersQualification> UsersQualifications { get; set; }
}