using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebDevCWK.Models;

public class Projects
{
    [Key]
    [Required]
    public int ProjectID {get;set;}
    [Required]
    public string? ProjectName {get;set;}
    public string? ProjectDescription {get;set;}
    public string? ProjectDueDate {get;set;}
    public string? ProjectStatus {get;set;}

    //FK
    [JsonIgnore]
    public List<Milestones>? Milestones {get;set;}
}