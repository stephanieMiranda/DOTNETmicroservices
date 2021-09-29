using System.ComponentModel.DataAnnotations;

namespace PlatformService.Dtos
{
     public class PlatformCreateDto
     {
          //db creates this for us
          //public int Id { get; set; }
          [Required]
          public string Name { get; set; }
          [Required]
          public string Publisher { get; set; }
          [Required]
          public string Cost { get; set; }
     }
}