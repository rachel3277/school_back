using Bl.Api;
using Bl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dal.Api;
using Dal.Models;
using Microsoft.SqlServer.Server;

namespace Bl.Services
{
    public class BlEventService : IBlEvent
    {
        IEvent dal;
        IRegistration registrationDal;
        public BlEventService(IDal dalManager)
        {
            dal = dalManager.Event;
            registrationDal = dalManager.Registration;
        }

        public List<BlEvent> AddEvent(BlEvent blEvent)
        {
            Event eventt = ChangeBlEToE(blEvent);
            if (eventt != null) 
                dal.AddEvent(eventt);
            return ChangeEListToBlEList(dal.GetEvents());
        }
        private static List<BlEvent> ChangeEListToBlEList(List<Event> events)
        {
            List<BlEvent> blEvents = new();
            events.ForEach(e => blEvents.Add(new BlEvent()
            {
                Id = e.Id,
                Name = e.Name,
                //Date = e.Date,
                Date = DateOnly.FromDateTime(e.Date),
                Description = e.Description,
                Place = e.Place,
                Price = e.Price,
                MinClass = e.MinClass,
                MaxClass = e.MaxClass,
            })); ;
            return blEvents;
        }
        private static Event ChangeBlEToE(BlEvent blEvent)
        {
            if (blEvent == null)
                return null;
            Event eventt = new() 
            {
                Id = blEvent.Id,
                Name = blEvent.Name,
                //Date = blEvent.Date,
                Date = new DateTime(blEvent.Date.Year, blEvent.Date.Month, blEvent.Date.Day),
                Description = blEvent.Description,
                Place = blEvent.Place,
                Price = blEvent.Price,
                MinClass = blEvent.MinClass,
                MaxClass = blEvent.MaxClass,
            };
            return eventt;
        }
        private static BlEvent ChangeEToBlE(Event eventt)
        {
            if (eventt == null)
                return null;
            BlEvent blEvent = new()
            {
                Id = eventt.Id,
                Name = eventt.Name,
                //Date = blEvent.Date,
                Date = DateOnly.FromDateTime(eventt.Date),
                Description = eventt.Description,
                Place = eventt.Place,
                Price = eventt.Price,
                MinClass = eventt.MinClass,
                MaxClass = eventt.MaxClass,
            };
            return blEvent;
        }
        public List<BlEvent> GetAll()
        {
            return ChangeEListToBlEList(dal.GetEvents());
        }

        public BlEvent GetEventById(int id)
        {
            return ChangeEToBlE(dal.GetEventById(id));
        }

        public List<BlEvent> DeleteEvent(BlEvent eventt)
        {
            DeleteRegistrationsByEventId(eventt.Id);
            return ChangeEListToBlEList(dal.DeleteEvent(ChangeBlEToE(eventt)));
        }

        public List<BlEvent> DeleteEventById(int id)
        {
            DeleteRegistrationsByEventId(id);
            return ChangeEListToBlEList(dal.DeleteEventById(id));
        }

        public void DeleteRegistrationsByEventId(int eId)
        {
            dal.DeleteRegistrationsByEventId(eId);
        }

        public List<BlEvent> UpdateEvent(BlEvent eventt)
        {
            return ChangeEListToBlEList(dal.UpdateEvent(ChangeBlEToE(eventt)));
        }

        public List<BlEvent> GetBeforeEvents()
        {
            return ChangeEListToBlEList(dal.GetBeforeEvents());
        }

        public List<BlEvent> GetAfterEvents()
        {
            return ChangeEListToBlEList((dal.GetAfterEvents()));
        }

        public List<BlEvent> GetEventsByName(string name)
        {
            return ChangeEListToBlEList(dal.GetEventsByName(name));
        }

        public List<BlEvent> GetEventsOfStudent(BlStudent blStudent)
        { 
            var id = blStudent.Id;
            List<BlEvent> allEvents = ChangeEListToBlEList(dal.GetEventsByClass(blStudent.Class));
            allEvents.Where(e => registrationDal.GetRegistrationById(e.Id, id) != null).
                ToList().ForEach(e => e.Registerate = true);
            return allEvents;
        }
    }
}
