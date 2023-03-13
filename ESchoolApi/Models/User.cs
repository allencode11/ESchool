using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ESchoolApi.Models;

public class User
{
    public Guid Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Username { get; set; }
    [Required]
    [MaxLength(25)]
    public string Password { get; set; }
    [Required]
    [MaxLength(35)]
    public string Email { get; set; }
    [Required]
    [MaxLength(25)]
    public string Institution { get; set; }
    public string Role { get; set; }
    public string CreatedAt { get; set; }
    public string UpdatedOn { get; set; }
    [Required]
    [MaxLength(25)]
    public string Name { get; set; }
    [Required]
    [MaxLength(25)]

    public string Surname { get; set; }
    
    // public ICollection<Qualification> Qualifications { get; set; }
    public ICollection<UsersQualification> UsersQualifications { get; set; }
}