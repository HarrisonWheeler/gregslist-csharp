using System.ComponentModel.DataAnnotations;

namespace gregslist_api.Models
{
  public class Job
  {
    public int Id { get; set; }
    [Required]

    public string Company { get; set; }
    [Required]

    public string Description { get; set; }
    [Required]

    public int Hours { get; set; }
    [Required]

    public int Rate { get; set; }

    public string UserId { get; set; }

  }
}