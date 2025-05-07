using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Models;
namespace Dal.Api
{
    public interface IEvent
    {
        Event GetEventById(int id);
        List<Event> GetEvents();
        List<Event> GetEventsByName(string name);
        List<Event> GetEventsByClass(int classNum);
        List<Event> GetBeforeEvents();
        List<Event> GetAfterEvents();
        void AddEvent(Event eventt);
        List<Event> UpdateEvent(Event eventt);
        List<Event> DeleteEvent(Event eventt);
        List<Event> DeleteEventById(int id);
        void DeleteRegistrationsByEventId(int eId);
    }
}
