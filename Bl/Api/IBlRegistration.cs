using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bl.Models;
using Dal.Models;

namespace Bl.Api
{
    public interface IBlRegistration 
    {
        List<BlRegistration> GetAll();
        List<BlRegistration> GetRegistrationByEventId(int eId);
        void AddRegistration(BlRegistration registration);
        List<BlStudentReference> GetRegisteredStudentsForEventId(int eId);

    }
}
