using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using Repository_Pattern_Template.Data;
using Repository_Pattern_Template.Models;
using Repository_Pattern_Template.Repository.Interfaces;
using System.Linq;

namespace Repository_Pattern_Template.Repository.implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDatabaseContext _studentContext;
        public StudentRepository(StudentDatabaseContext studentDatabaseContext)
        {
            _studentContext = studentDatabaseContext;
        }
        public void AddStudent(Student newStudent)
        {
            if (newStudent.Id == null) { 
            newStudent.Id = ObjectId.GenerateNewId().ToString();
                    }
            _studentContext.Students.Add(newStudent);

            _studentContext.SaveChanges();
        }

        public void EditStudent(Student oldStudent, Student updatedStudent)
        {
            oldStudent.Email = updatedStudent.Email;
            oldStudent.FirstName = updatedStudent.FirstName;
            oldStudent.LastName = updatedStudent.LastName;
            oldStudent.Age = updatedStudent.Age;

            _studentContext.Students.Update(oldStudent);
            _studentContext.SaveChanges();
        }

        public  IEnumerable<Student> GetAllStudents()
        {
             return  _studentContext.Students.OrderBy(c => c.Id).AsNoTracking().AsEnumerable<Student>();
        }

        public Student? GetStudentById(string id)
        {
            return _studentContext.Students.FirstOrDefault(s => s.Id == id);
        }

        public void RemoveStudent(Student student)
        {
            _studentContext.Students.Remove(student);
            _studentContext.SaveChanges();
        }
    }
}
