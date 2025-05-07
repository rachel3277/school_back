using Bl.Models;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public class ConversionFunctions
    {
        public static List<BlEvent> ChangeEListToBlEList(List<Event> events)
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
                Price = e.Price
            })); ;
            return blEvents;
        }
        public static List<BlStudentReference> ChangeSListToBlSList(List<Student> students)
        {
            List<BlStudentReference> blStudents = new();
            students.ForEach(e => {
                Parent parent = e.Parents;
                parent.Students = null;
                blStudents.Add(new BlStudentReference()
                {
                    Id = e.Id,
                    Name = e.Name,
                    ParentsId = e.ParentsId,
                    Class = e.Class,
                    Accepted = e.Accepted,
                    Parents = parent
                });
            });
            return blStudents;
        }
    }
}
