using System.ComponentModel.DataAnnotations;

namespace TodoREST
{
	public class TodoItem
	{
        [Required]
        public string ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public string Notes { get; set; }
    }
}
