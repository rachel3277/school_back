using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bl.Models;
using Dal.Models;

namespace Bl.Api
{
    public interface IBlEvent
    {
        List<BlEvent> GetEventsOfStudent(BlStudent blStudent);
        List<BlEvent> GetAll();
        List<BlEvent> GetEventsByName(string name);
        List<BlEvent> GetBeforeEvents();
        List<BlEvent> GetAfterEvents();
        BlEvent GetEventById(int id);
        List<BlEvent> AddEvent(BlEvent blEvent);
        List<BlEvent> DeleteEvent(BlEvent eventt);
        List<BlEvent> DeleteEventById(int id);
        void DeleteRegistrationsByEventId(int eId);
        List<BlEvent> UpdateEvent(BlEvent eventt);
    }
}
