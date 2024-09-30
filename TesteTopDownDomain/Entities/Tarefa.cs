using TesteTopDownDomain.Contracts.Models;

namespace TesteTopDownDomain.Entities
{
    public class Tarefa : Entity
    {
        //public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; }        
    }
}
