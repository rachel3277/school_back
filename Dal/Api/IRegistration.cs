using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface IRegistration
    {
        void AddRegistration(Registration registration);
        List<Registration> GetRegistrations();
        Registration GetRegistrationById(int eId, int sId);
        List<Registration> GetRegistrationsByEventId(int eId);
        void Delete(Registration registration);
        void Delete(ICollection<Registration> registration);
        void DeleteById(int eId ,int sId);
        List<Student> GetRegisteredStudentsForEventId(int eId);
    }
}
