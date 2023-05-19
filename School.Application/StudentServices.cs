using School.Domain.Entities;
using School.Domain.Repositories;

namespace School.Application;

public class StudentServices : IStudentServices
{
    private readonly IStudentRepository _studentRepository;

    public StudentServices(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public Student Get(int id)
    {
        return _studentRepository.Get(id);
    }

    public IEnumerable<Student> GetAll()
    {
        return _studentRepository.GetAll();
    }

    public void Save(Student student)
    {
        _studentRepository.Save(student);
    }
}