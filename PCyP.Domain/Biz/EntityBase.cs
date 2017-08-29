using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCyP.Domain.Biz
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ChangedOn { get; set; }
        public int ChangedBy { get; set; }
        
    }
}
