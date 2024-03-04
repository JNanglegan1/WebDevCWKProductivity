using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebDevCWK.Models;

public class Tasks
{
    [Key]
    [Required]
    public int TaskID {get;set;}
    [Required]
    public string? TaskName {get;set;}
    public string? TaskDescription {get;set;}
    public string? TaskDueDate {get;set;}
    public string? TaskStatus {get;set;}

    //FK
    [Required]
    public int UserID {get;set;}
    [JsonIgnore]
    public Users? Users {get;set;}
}