using Bl.Api;
using Bl.Models;
using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Services
{
    public class BlParentService : IBlParent
    {
        IParent dal;
        IBlStudent Student;
        public BlParentService(IDal dalManager,IBlStudent student)
        {
            dal = dalManager.Parent;
            Student= student; 
        }
        private static List<BlParent> ChangePListToBlPList(List<Parent> parents)
        {
            List<BlParent> blParents = new();
            parents.ForEach(p => blParents.Add(new BlParent()
            {
                Id = p.Id,
                FamilyLastName = p.FamilyLastName,
                FatherFirstName = p.FatherFirstName,
                MotherFirstName = p.MotherFirstName,
                Mail = p.Mail,
                HomeNumberPhone = p.HomeNumberPhone,
                NumberPhone1 = p.NumberPhone1,
                NumberPhone2 = p.NumberPhone2,
                Address = p.Address,
                Accepted = p.Accepted
            }));
            return blParents;
        }
        private static BlParent ChangePToBlP(Parent parent)
        {
            BlParent blParent = new(){
                Id = parent.Id,
                FamilyLastName = parent.FamilyLastName,
                FatherFirstName = parent.FatherFirstName,
                MotherFirstName = parent.MotherFirstName,
                Mail = parent.Mail,
                HomeNumberPhone = parent.HomeNumberPhone,
                NumberPhone1 = parent.NumberPhone1,
                NumberPhone2 = parent.NumberPhone2,
                Address = parent.Address,
                Accepted = parent.Accepted
            };
            return blParent;
        }
        private static Parent ChangeBlPToP(BlParent blParent)
        {
            Parent parent = new()
            {
                Id = blParent.Id,
                FamilyLastName = blParent.FamilyLastName,
                FatherFirstName = blParent.FatherFirstName,
                MotherFirstName = blParent.MotherFirstName,
                Mail = blParent.Mail,
                HomeNumberPhone= blParent.HomeNumberPhone,
                NumberPhone1 = blParent.NumberPhone1,
                NumberPhone2 = blParent.NumberPhone2,
                Address = blParent.Address,
                Accepted = blParent.Accepted
            };
            return parent;
        }
        public int AddParent(BlParent blParent)
        {
            return dal.AddParent(ChangeBlPToP(blParent));
        }

        //public void DeleteExitParents()
        //{
        //    dal.DeleteExitParents();
        //}

        public List<BlParent> GetAll()
        {
            return ChangePListToBlPList(dal.GetParents());
        }

        public List<BlParent> GetNotAcceptedParents()
        {
            return ChangePListToBlPList(dal.GetNotAcceptedParents());
        }

        public BlParent GetParentById(int id)
        {
            Parent parent = dal.GetParentById(id);
            if(parent != null)
                return ChangePToBlP(dal.GetParentById(id));
            return null;
        }

        //public bool HasLessThan3NotAccepted(int parentId)
        //{
        //    return dal.HasLessThan3NotAccepted(parentId);
        //}

        public List<BlStudent> GetAcceptedSons(int id)
        {
            return Student.ChangeSListToBlSList(dal.GetAcceptedSons(id));
        }

        public List<BlParent> UpdateParent(BlParent blParent)
        {
            dal.UpdateParent(ChangeBlPToP(blParent));
            return GetAll();
        }
        public List<BlParent> Delete(BlParent parent)
        {
            return ChangePListToBlPList(dal.Delete(ChangeBlPToP(parent)));
           
        }

        public List<BlParent> DeleteById(int id)
        {
            return ChangePListToBlPList(dal.DeleteById(id));
        }
    }
}
