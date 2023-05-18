using Microsoft.Data.SqlClient;
using Dapper;
using School.Domain.Entities;
using School.Domain.Repositories;
using Microsoft.Extensions.Configuration;

namespace School.Infra;

public class StudentRepository : IStudentRepository
{
    private readonly string CONN_STRING;

    public StudentRepository(IConfiguration configuration)
    {
        CONN_STRING = configuration.GetConnectionString("School");
    }

    public Student Get(int id)
    {
        Student student = null;
        using (var connection = new SqlConnection(CONN_STRING))
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
        IEnumerable<Student> students = null;
        using (var connection = new SqlConnection(CONN_STRING))
        {
            connection.Open();
            students = connection.Query<Student>("SELECT * FROM Student ");
        }

        return students;
    }

    public void Save(Student student)
    {
        using var connection = new SqlConnection(CONN_STRING);
        connection.Open();
        connection.Execute("INSERT INTO Student VALUES (@name)", new { name = student.Name });
    }
}