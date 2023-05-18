using Microsoft.AspNetCore.Mvc;
using School.Domain.Entities;
using School.Domain.Repositories;

namespace School.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentRepository _studentRepository;

    public StudentsController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var student = _studentRepository.Get(id);

        return student != null ? Ok(student) : NotFound();
    }

    [HttpGet]
    public IActionResult GetAll()
    { 
        var students = _studentRepository.GetAll();

        return students.Any() ? Ok(students) : NotFound();
    }

    [HttpPost]
    public IActionResult Save(Student student)
    {
        _studentRepository.Save(student);

        return Ok();
    }
}