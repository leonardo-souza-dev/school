using School.Domain.Entities;

namespace School.Domain.Repositories;

public interface IStudentRepository
{
    Student Get(int id);
    IEnumerable<Student> GetAll();
    void Save(Student student);
}