using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebDevCWK.Models;

public class Milestones
{
    [Key]
    [Required]
    public int MilestoneID {get;set;}
    [Required]
    public string? MilestoneName {get;set;}
    public string? MilestoneDescription {get;set;}
    public string? MilestoneDueDate {get;set;}
    public string? Status {get;set;}

    //FK
    [Required]
    public int ProjectID { get; set; }
    [JsonIgnore]
    public Projects? Project { get; set; }
}