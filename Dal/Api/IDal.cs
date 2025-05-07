using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface IDal
    {
        public IClass Class { get; }
        public IEvent Event { get; }
        public IParent Parent { get; }
        public IStudent Student { get; }
        public IRegistration Registration { get; }
        
    }
}
