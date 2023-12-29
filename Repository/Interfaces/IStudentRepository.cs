using MongoDB.Bson;
using Repository_Pattern_Template.Models;

namespace Repository_Pattern_Template.Repository.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudents();
        Student? GetStudentById(string id);

        void AddStudent(Student newStudent);

        // Doesn't make sense but just for the sake of testing
        void EditStudent(Student oldStudent, Student updatedStudent);

        void RemoveStudent(Student student);
    }
}
