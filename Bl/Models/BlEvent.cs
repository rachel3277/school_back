using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Models
{
    public partial class BlEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public DateTime Date { get; set; }
        public DateOnly Date { get; set; }
        //public string Date { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public string? Place { get; set; }
        public short MinClass { get; set; }

        public short MaxClass { get; set; }
        public bool? Registerate { get; set; }
    }
}
