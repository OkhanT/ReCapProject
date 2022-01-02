using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Brain : IEntity
    {
        public int BrainId { get; set; }
        public string BrainName { get; set; }
    }
}
