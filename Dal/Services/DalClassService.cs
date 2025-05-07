using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class DalClassService: IClass
    {
        dbcontext data;
        public DalClassService(dbcontext data)
        { this.data = data; }

        public List<Event> GetClassEvents(int Id)
        {
            return data.Classes.Include(c => c.Eventts).ToList().
                FindAll(c => c.Id == Id).Where(c => c != null).ToList().
                First().Eventts.ToList();
        }
    }
}
