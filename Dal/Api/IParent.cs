using Dal.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface IParent
    {
        //bool HasLessThan3NotAccepted(int parentId);
        int AddParent(Parent parent);
        List<Student> GetAcceptedSons(int id);
        List<Parent> GetParents();
        Parent GetParentById(int id);
        //Parent GetParentByName(string name, string lastName);
        List<Parent> GetNotAcceptedParents();
        //void DeleteExitParents();
        List<Parent> Delete(Parent parent);
        List<Parent> DeleteById(int id);
        void UpdateParent(Parent parent);
    }
}
