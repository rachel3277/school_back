//using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Models;
namespace Dal.Api
{
    public interface IStudent
    {
        void AcceptStudent(Student student, bool isAccept);
        void AddStudent(Student student);
        void DeleteExitStudents();
        void DeleteStudentById(int id);
        void DeleteStudent(Student student);
        void UpdateStudent(Student student);
        List<Student> GetNotAcceptedSons(int id);
        List<Student> GetAcceptedStudents();
        List<Student> GetSons(int id);
        Student GetStudentById(int id);
        List<Student> GetStudents();
        List<Student> GetStudentsByClass(int classs);
        List<Student> GetNotAcceptedStudents();
        void IncreaseYear();



    }
}
