using Dal.Api;
using Dal.Models;
using Dal.Services;

namespace Dal
{
    public class DalManager : IDal
    {
        public IEvent Event { get; }
        public IParent Parent { get; }
        public IStudent Student { get; }
        public IRegistration Registration { get; }
        public IClass Class { get; }

        public DalManager()
        {
            dbcontext data = new dbcontext();
            Class = new DalClassService(data);
            Event = new DalEventService(data);
            Parent = new DalParentService(data);
            Student = new DalStudentService(data);
            Registration = new DalRegistrationService(data);
        }
    }
}