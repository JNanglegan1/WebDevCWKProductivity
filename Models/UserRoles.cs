using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebDevCWK.Models;

public class UserRoles
{
    [Key]
    [Required]
    public int UserRoleID{get;set;}
    [Required]
    public string? UserRoleName{get;set;}

    //FK
    [Required]
    public int UserID {get;set;}
    [JsonIgnore]
    public Users? Users {get;set;}
}