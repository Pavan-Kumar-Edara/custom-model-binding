using System.ComponentModel.DataAnnotations;

namespace CricketCrudApi.Models
{
    public class Cricket
    {
        [Key]
        public int cricketerId { get; set; }

        [Required]
        public string cricketerName { get; set; }

        [Required]
        public string cricketerRole { get; set;}

        public string country { get; set; }
    }
}
