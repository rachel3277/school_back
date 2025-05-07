using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bl.Models;
using Dal.Models;

namespace Bl.Api
{
    public interface IBlStudent
    {
        List<BlStudent> AcceptStudent(int id, bool isAccept);
        void AddStudent(BlStudent student);
        List<BlStudent> ChangeSListToBlSList(List<Student> students);
        List<BlStudent> DeleteStudentById(int id);
        List<BlStudent> GetSons(int id);
        List<BlStudentReference> GetAcceptedStudents();
        List<BlStudent> GetAll();
        BlStudent GetById(int id);
        
        List<BlStudent> GetByParentsId(int parentsId);
        List<BlStudentReference> GetNotAcceptedStudents();
        List<BlStudent> GetStudentsByClass(int classs);
        void IncreaseYear();
        List<BlStudent> UpdateStudent(BlStudent student);
    }
}
