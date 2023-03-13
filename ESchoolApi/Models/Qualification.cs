
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ESchoolApi.Models;

public class Qualification
{
    [Key]
    public Guid Id { get; set; }
    public Guid DisciplineId { get; set; }
    public ICollection<UsersQualification> UsersQualifications { get; set; }
    // public List<UsersQualifications> UsersQualificationsCollection { get; set; }
}