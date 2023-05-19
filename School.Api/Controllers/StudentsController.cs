using Microsoft.AspNetCore.Mvc;
using School.Domain.Entities;
using School.Domain.Repositories;

namespace School.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentServices _studentServices;

    public StudentsController(IStudentServices studentServices)
    {
        _studentServices = studentServices;
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var student = _studentServices.Get(id);

        return student != null ? Ok(student) : NotFound();
    }

    [HttpGet]
    public IActionResult GetAll()
    { 
        var students = _studentServices.GetAll();

        return students.Any() ? Ok(students) : NotFound();
    }

    [HttpPost]
    public IActionResult Save(Student student)
    {
        _studentServices.Save(student);

        return Ok();
    }
}