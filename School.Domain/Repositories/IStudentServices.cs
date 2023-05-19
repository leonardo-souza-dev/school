using School.Domain.Entities;

namespace School.Domain.Repositories;

public interface IStudentServices
{
    Student Get(int id);
    IEnumerable<Student> GetAll();
    void Save(Student student);
}