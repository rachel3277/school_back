using Bl.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Api;
using Bl.Models;
using Dal.Models;

namespace Bl.Services
{
    public class BlRegistrationService : IBlRegistration
    {
        IRegistration dal;
        public BlRegistrationService(IDal dalManager)
        {
            this.dal = dalManager.Registration;
        }
        private static List<BlRegistration> ChangeRListToBlRList(List<Registration> rList)
        {
            List<BlRegistration> blRList = new();
            rList.ForEach(r => blRList.Add(new BlRegistration()
            {
                EventId = r.EventId,
                StudentId = r.StudentId,
                Date = r.Date
            }));
            return blRList;
        }
        private static Registration ChangeBlRToR(BlRegistration BlRegistration)
        {
            Registration registration = new() {
                EventId = BlRegistration.EventId,
                StudentId = BlRegistration.StudentId,
                Date = BlRegistration.Date
            };
            return registration;
        }

        public void AddRegistration(BlRegistration registration)
        {
            if(dal.GetRegistrationById(registration.EventId, registration.StudentId) == null)
                dal.AddRegistration(ChangeBlRToR(registration));  
        }

        public List<BlRegistration> GetAll()
        {
            return ChangeRListToBlRList(dal.GetRegistrations());
        }

        public List<BlRegistration> GetRegistrationByEventId(int eventId)
        {
            return ChangeRListToBlRList(dal.GetRegistrationsByEventId(eventId));
        }

        public List<BlStudentReference> GetRegisteredStudentsForEventId(int eId)
        {
            return ConversionFunctions.ChangeSListToBlSList(dal.GetRegisteredStudentsForEventId(eId));
        }
    }
}
