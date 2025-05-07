using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Models
{
    public class BlStudentReference
    {
        public int Id { get; set; }

        public bool Accepted { get; set; }

        public string Name { get; set; } = null!;

        public int Class { get; set; }

        public int ParentsId { get; set; }

        public virtual Parent Parents { get; set; } = null!;
    }
}
