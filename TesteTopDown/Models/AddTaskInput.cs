using System.ComponentModel.DataAnnotations;

namespace TesteTopDown.Models
{
    public class AddTaskInput
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; }

    }
}
