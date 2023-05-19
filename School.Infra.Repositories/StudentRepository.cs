using Microsoft.Data.SqlClient;
using Dapper;
using School.Domain.Entities;
using School.Domain.Repositories;
using Microsoft.Extensions.Configuration;

namespace School.Infra.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly string? _connectionString;

    public StudentRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("School");
    }

    public Student Get(int id)
    {
        Student? student = null;
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            student = connection.QueryFirstOrDefault<Student>(
                "SELECT * FROM Student WHERE Id = @id",
                new { id }
                );
        }

        return student;
    }

    public IEnumerable<Student> GetAll()
    {
        IEnumerable<Student>? students = null;
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            students = connection.Query<Student>("SELECT * FROM Student ");
        }

        return students;
    }

    public void Save(Student student)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        connection.Execute("INSERT INTO Student VALUES (@name)", new { name = student.Name });
    }
}