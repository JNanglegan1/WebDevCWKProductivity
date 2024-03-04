using System.ComponentModel.DataAnnotations;

public class UserTeam
{
  [Key]
  public int UserID { get; set; }
  public int TeamID { get; set; }
}