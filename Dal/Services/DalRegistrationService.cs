using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Api;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace Dal.Services
{
    internal class DalRegistrationService : IRegistration
    {
        dbcontext data;
        public DalRegistrationService(dbcontext data)
        {
            this.data = data;
        }
        public void AddRegistration(Registration registration)
        {
            data.Registrations.Add(registration);
            data.SaveChanges();
        }

        public void Delete(Registration registration)
        {
            data.Registrations.Remove(registration);
            data.SaveChanges(); 
        }

        public void Delete(ICollection<Registration> registration)
        {
            registration.ToList().ForEach(r => Delete(r));
        }

        public void DeleteById(int eId, int sId)
        {
            data.Registrations.ToList().
                 ForEach(r => { if (r.EventId == eId && r.StudentId == sId) data.Registrations.Remove(r); });
            data.SaveChanges();
        }

        public Registration GetRegistrationById(int eId, int sId)
        {
            return data.Registrations.ToList().Find(r => r.EventId == eId && r.StudentId == sId);
        }

        public List<Registration> GetRegistrations()
        {
            return data.Registrations.ToList();
        }

        public List<Registration> GetRegistrationsByEventId(int eId)
        {
            return data.Registrations.ToList().FindAll(r => r.EventId == eId);
        }

        public List<Student> GetRegisteredStudentsForEventId(int eId)
        {
            //return data.Registrations.Include(r => r.Student).ToList().FindAll(r => r.EventId == eId).Select(r => r.Student).ToList();
            return data.Registrations.Include(r => r.Student).Include(r => r.Student.Parents).ToList().FindAll(r => r.EventId == eId).Select(r => r.Student).ToList();
        }
    }
}
