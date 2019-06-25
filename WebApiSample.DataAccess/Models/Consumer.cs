using System.ComponentModel.DataAnnotations;

namespace WebApiSample.DataAccess.Models
{
    public class Consumer
    {
        public int Id { get; set; }

        [Required]
        public string Location { get; set; }

        public string Name { get; set; }

        [Required]
        public ConsumerType ConsumerType { get; set; }
    }

    public enum ConsumerType
    {
        User = 0,
        Agent = 1
    }
}
