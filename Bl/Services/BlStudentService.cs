using Bl.Api;
using Bl.Models;
using Dal.Api;
using Dal.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Services
{
    public class BlStudentService : IBlStudent
    {
        IStudent dal;
        public BlStudentService(IDal dalManger)
        {
            dal = dalManger.Student;
        }
        public List<BlStudent> ChangeSListToBlSList(List<Student> students)
        {
            List<BlStudent> blStudents = new();
            students.ForEach(e => blStudents.Add(new BlStudent() { Id = e.Id, Name = e.Name, ParentsId = e.ParentsId,
            Class = e.Class, Accepted = e.Accepted}));
            return blStudents;
        }
        private static BlStudent ChangeSToBlS(Student student)
        {
            if (student == null)
                return null;
            BlStudent blStudent = new()
            {
                Id = student.Id,
                Name = student.Name,
                ParentsId = student.ParentsId,
                Class = student.Class,
                Accepted = student.Accepted
            };
            return blStudent;
        }
        private static Student ChangeBlSToS(BlStudent blStudent)
        {
            Student student = new()
            {
                Id = blStudent.Id,
                Name = blStudent.Name,
                ParentsId = blStudent.ParentsId,
                Class = blStudent.Class,
                Accepted = blStudent.Accepted
            };
            return student;
        }
        private static bool CheckValidationsStudentDetails(BlStudent student)
        {
            //צריך לבדוק את תקינות הנתונים
            // 1
            // parentId is reference key of parents
            if (student == null)
                return false;
            return true;
        }
        public List<BlStudent> AcceptStudent(int id, bool isAccept)
        {
            Student student = dal.GetStudentById(id);
            if (student != null)
                dal.AcceptStudent(student, isAccept);            
            else
                Console.WriteLine("לזרוק שגיאת זמן ריצה");
            return GetAll();
        }
        public List<BlStudent> GetSons(int id)
        {
            return ChangeSListToBlSList(dal.GetSons(id));
        }
        public List<BlStudent> GetAll()
        {
            return ChangeSListToBlSList(dal.GetStudents());
        }
        public BlStudent GetById(int id)
        {
            return ChangeSToBlS(dal.GetStudentById((int)id));   
        }
        public List<BlStudent> GetByParentsId(int parentsId)
        {
            throw new NotImplementedException();
        }
        public List<BlStudentReference> GetAcceptedStudents()
        {
            return ConversionFunctions.ChangeSListToBlSList(dal.GetAcceptedStudents());
        }
        public List<BlStudentReference> GetNotAcceptedStudents()
        {
            return ConversionFunctions.ChangeSListToBlSList(dal.GetNotAcceptedStudents());
        }

        public List<BlStudent> GetStudentsByClass(int classs)
        {
            return ChangeSListToBlSList(dal.GetStudentsByClass(classs));
        }
        public void IncreaseYear()
        {
            dal.IncreaseYear();
        }

        public void AddStudent(BlStudent student)
        {
            if (CheckValidationsStudentDetails(student) && 
                dal.GetNotAcceptedSons(student.ParentsId).Count < 3)
            {
                student.Id = 0;
                student.Accepted = false;
                dal.AddStudent(ChangeBlSToS(student));
            }
        }

        public List<BlStudent> UpdateStudent(BlStudent student)
        {
            dal.UpdateStudent(ChangeBlSToS(student));
            return GetAll();
        }

        public List<BlStudent> DeleteStudentById(int id)
        {
            dal.DeleteStudentById(id);
            return GetAll();
        }           
    }
}
