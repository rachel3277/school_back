using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Api
{
    public interface IBl
    {
        IBlClass Class { get; }
        IBlEvent events { get; }
        IBlParent parents { get; }
        IBlStudent students { get; }
        IBlRegistration registration { get; }
    }
}
