using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Api;
using Dal.Models;

namespace Dal.Services
{
    internal class DalEventService : IEvent
    {
        dbcontext data;
        public DalEventService(dbcontext data)
        {
            this.data = data;
        }
        public void AddEvent(Event eventt)
        {
            data.Events.Add(eventt);  
            data.SaveChanges();
        }

        public List<Event> DeleteEvent(Event eventt)
        {
            data.Remove(eventt);
            data.SaveChanges();
            return GetEvents();

        }

        public List<Event> DeleteEventById(int id)
        {
            data.Events.ToList().
                ForEach(e => { if (e.Id == id) data.Events.Remove(e); });
            data.SaveChanges();
            return GetEvents();
        }

        public void DeleteRegistrationsByEventId(int eId)
        {
            data.Registrations.ToList().
                     ForEach(r => { if (r.EventId == eId) data.Registrations.Remove(r); });
            data.SaveChanges();
        }

        public List<Event> GetAfterEvents()
        {
            return data.Events.ToList().Where(e => e.Date > DateTime.Now).ToList();
        }

        public List<Event> GetBeforeEvents()
        {
            return data.Events.ToList().Where(e => e.Date < DateTime.Now).ToList(); 
        }

        public Event GetEventById(int id)
        {
            return data.Events.ToList().Find(e => e.Id == id);
        }

        public List<Event> GetEvents()
        {
            return data.Events.ToList();
        }

        public List<Event> GetEventsByClass(int classNum)
        {
            return data.Events.ToList().
                Where(e =>  classNum >= e.MinClass && classNum <= e.MaxClass).ToList();
        }
        
        public List<Event> GetEventsByName(string name)
        {
            return data.Events.Where(e => e.Name.Equals(name)).ToList();
        }

        public List<Event> UpdateEvent(Event eventt)
        {
            data.Events.ToList().
                ForEach(e => { if (e.Id == eventt.Id)
                    {
                        e.Id = eventt.Id;
                        e.Name = eventt.Name;
                        e.Description = eventt.Description;
                        e.Date = eventt.Date;
                        e.Price = eventt.Price; 
                        e.Place = eventt.Place;
                        e.MinClass = eventt.MinClass;
                        e.MaxClass = eventt.MaxClass;
                    }
                });
            data.SaveChanges();
            return GetEvents();

        }
    }
}
