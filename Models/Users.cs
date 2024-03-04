using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebDevCWK.Models;

public class Users
{
    [Key]
    [Required]
    public int UserID {get;set;}
    [Required]
    public string? UserName{get;set;}

    //FK
    [JsonIgnore]
    public List<UserRoles>? UserRoles {get;set;}
    [JsonIgnore]
    public List<Tasks>? Tasks {get;set;}
    [JsonIgnore]
    public List<Teams>? Teams {get;set;}
}