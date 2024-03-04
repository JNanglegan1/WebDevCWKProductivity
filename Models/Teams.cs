using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebDevCWK.Models;

public class Teams
{
    [Key]
    [Required]
    public int TeamID {get;set;}
    [Required]
    public string? TeamName {get;set;}

    //FK
    [JsonIgnore]
    public List<Users>? Users {get;set;}
    public int ProjectID {get;set;}
    [JsonIgnore]
    public Projects? Projects {get;set;}
}