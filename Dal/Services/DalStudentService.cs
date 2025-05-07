using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal.Services
{
    internal class DalStudentService : IStudent
    {
        dbcontext data;
        public DalStudentService(dbcontext data)
        {
            this.data = data;
        }

        public void AcceptStudent(Student student, bool isAccept)
        {
            student = data.Students.Include(s => s.Parents).ToList().
                    Find(s => s.Id == student.Id);
            if (student != null)
            {
                if (isAccept)
                {
                        student.Parents.Accepted = true;
                        student.Accepted = true;
                }
                else
                {
                    student.Registrations
                        .ToList().ForEach(r => data.Registrations.Remove(r));
                    data.SaveChanges();
                    //registration.Delete(student.Registrations);
                    DeleteStudent(student);
                    Parent parent = data.Parents.Include(x => x.Students).ToList().Find(p => p.Id == student.Parents.Id);
                    if( parent != null && parent.Students.Count() == 0 )
                        data.Parents.Remove(student.Parents) ;
                    //int parentsId = student.ParentsId;
                    //data.Registrations.ToList().FindAll(r => r.StudentId == student.Id)
                    //    .ToList().ForEach(r => data.Registrations.Remove(r));
                    //data.SaveChanges();
                    //data.Registrations.ToList().ForEach(r => Console.WriteLine(r.StudentId));
                    //DeleteStudent(student);
                    //Parent p = data.Parents.ToList().Find(p => p.Id == parentsId);
                    //if (p != null && !p.Accepted)
                    //{
                    //    data.Parents.Remove(p);
                    //}
                }
            }
            data.SaveChanges();
        }

        public void AddStudent(Student student)
        {
            data.Students.Add(student);
            data.SaveChanges();

        }

        public void DeleteExitStudents()
        {
            data.Students.ToList().FindAll(s => s.Class == 9).ToList().
                ForEach(s  => data.Students.Remove(s));
            data.SaveChanges();
            data.Parents.ToList().
                ForEach(p =>
                { if (data.Students.ToList().Find(s => s.ParentsId == p.Id) == null)
                        data.Parents.Remove(p);
                });
            data.SaveChanges();
        }

        public void DeleteStudent(Student student)
        {
            data.Students.Remove(student);
            data.SaveChanges();
        }

        public void DeleteStudentById(int id)
        {
            data.Students.ToList().
                ForEach(s => { if (s.Id == id) data.Students.Remove(s); });
            data.SaveChanges();
        }

        public List<Student> GetAcceptedStudents()
        {
            return data.Students.Include(s => s.Parents).ToList().FindAll(s => s.Accepted);
        }

        public List<Student> GetNotAcceptedSons(int id)
        {
            return data.Students.ToList().FindAll(s => s.ParentsId == id
            && !s.Accepted);
        }

        public List<Student> GetNotAcceptedStudents()
        {
            return data.Students.Include(s => s.Parents).ToList().FindAll(s => !s.Accepted);
        }
        public List<Student> GetSons(int id)
        {
            return data.Students.ToList().FindAll(s => s.ParentsId == id);
        }
        public Student GetStudentById(int id)
        {
            return data.Students.ToList().Find(s => s.Id == id);
        }
      
        public List<Student> GetStudents()
        {
           return data.Students.ToList();
        }

        public List<Student> GetStudentsByClass(int classs)
        {

            return data.Students.ToList().FindAll(s => s.Class == classs);
        }

        public void IncreaseYear()
        {
            data.Students.ToList().
               ForEach(s => { s.Class += 1;  });
            data.SaveChanges();
            DeleteExitStudents();
        }

        public void UpdateStudent(Student student)
        {
            {
                data.Students.ToList().
                    ForEach(e => {
                        if (e.Id == student.Id)
                        {
                            e.Name = student.Name;
                            e.Class = student.Class;
                            e.ParentsId = student.ParentsId;
                        }
                    });
                data.SaveChanges();
            }
        }
    }
}
