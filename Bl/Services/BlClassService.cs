using Bl.Api;
using Bl.Models;
using Dal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bl.Services
{
    public class BlClassService : IBlClass
    {
        IClass dal;
        public BlClassService(IDal dalManager) {
            dal = dalManager.Class;
        }
        public List<BlEvent> GetClassEvents(int Id)
        {
            return ConversionFunctions.ChangeEListToBlEList(dal.GetClassEvents(Id));
        }
    }
}
