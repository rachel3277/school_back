using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    internal class DalParentService : IParent
    {
        dbcontext data;
        public DalParentService(dbcontext data)
        {
            this.data = data;
        }

        public int AddParent(Parent parent)
        {
            parent.Id = 0;
            parent.Accepted = false;
            data.Parents.Add(parent);
            data.SaveChanges();
            return data.Parents.Max(p => p.Id);
        }

        public List<Parent> Delete(Parent parent)
        {
            data.Parents.Remove(parent);
            data.SaveChanges();
            return GetParents();
        }

        public List<Parent> DeleteById(int id)
        {
            data.Parents.ToList().
                ForEach(p => { if(p.Id == id) data.Parents.Remove(p); });
            data.SaveChanges();
            return GetParents();
        }

        public List<Student> GetAcceptedSons(int id)
        {
            Parent parent = data.Parents.Include(x => x.Students).ToList().
                Find(p => p.Id == id);
            return parent != null ? parent.Students.ToList().FindAll(s => s.Accepted): new List<Student>();
        }

        //public void DeleteExitParents()
        //{
        //    data.Parents.ToList().
        //        ForEach(p => 
        //        { 
        //            List<Student> students = GetSons(p.Id);
        //            bool flag = false;
        //            students.ForEach(student => { if(student.Class != 9) flag = true; });
        //            if(!flag)
        //                Delete(p);
        //           // if (p.) data.Parents.Remove(p); 
        //        });
        //}

        public List<Parent> GetNotAcceptedParents()
        {
            return data.Parents.Include(x=> x.Students).ToList().FindAll(p => !p.Accepted);  
        }

        public Parent GetParentById(int id)
        {
            return data.Parents.Include(x=> x.Students).ToList().Find(p => p.Id == id);
        }

        public List<Parent> GetParents()
        {
            return data.Parents.ToList();
        }

        public void UpdateParent(Parent parent)
        {
            Parent p =data.Parents.ToList().Find(p => p.Id == parent.Id);
            if (p != null) { 
            p.FamilyLastName = parent.FamilyLastName;
            p.FatherFirstName = parent.FatherFirstName;
            p.MotherFirstName = parent.MotherFirstName;
            p.Mail = parent.Mail;
            p.HomeNumberPhone = parent.HomeNumberPhone;
            p.NumberPhone1 = parent.NumberPhone1;
            p.NumberPhone2 = parent.NumberPhone2;
            p.Address = parent.Address;
            p.Accepted = parent.Accepted;
            data.SaveChanges();
}
        }

        //public bool HasLessThan3NotAccepted(int parentId)
        //{
        //    Parent parent = data.Parents.Include(x => x.Students).ToList().
        //        Find(p => p.Id == parentId);
        //    return parent == null ?  true: parent.Students.Count < 3;
        //}
    }
}
