using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bl.Models;
using Dal.Models;

namespace Bl.Api
{
    public interface IBlParent
    {
        List<BlParent> GetAll();
        BlParent GetParentById(int id); 
        List<BlStudent> GetAcceptedSons(int id);
       // bool HasLessThan3NotAccepted(int parentId);
        int AddParent(BlParent blParent);
        List<BlParent> GetNotAcceptedParents();
        //void DeleteExitParents();
        List<BlParent> UpdateParent(BlParent blParent);
        List<BlParent> Delete(BlParent parent);
        List<BlParent> DeleteById(int id);
    }
}
