using Infrostructure.Models;

namespace Infrostructure.Interface;

public interface IStudentServices
{
    bool CreateStudent(Student student);
    List<Student> GetStudents();
    Student GetStudentById(int id);
    bool Update(Student student);
    bool Delete(int id);
}