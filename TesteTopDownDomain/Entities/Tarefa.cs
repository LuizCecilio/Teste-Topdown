using TesteTopDownDomain.Contracts.Models;

namespace TesteTopDownDomain.Entities
{
    public class Tarefa : Entity
    {
        public int Id { get; set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime? DueDate { get; private set; }
        public bool IsCompleted { get; private set; }
    }
}
