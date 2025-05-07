using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Models
{
    public class BlClass
    {
        public int Id { get; set; }

        public virtual ICollection<Event> Eventts { get; set; } = new List<Event>();
    }
}
