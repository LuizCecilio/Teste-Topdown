using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteTopDownDomain.Contracts.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = new int();
        }

        public int Id { get; set; }
    }
}
