using Dapper;
using Microsoft.Data.SqlClient;
using WebApplication5.Models;
namespace WebApplication5.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string _connStr;

        public StudentRepository(IConfiguration config)
        {
            _connStr = config.GetConnectionString("DefaultConnection");
        }

        private SqlConnection GetConnection() => new SqlConnection(_connStr);

        public void AddStudent(Student student)
        {
            using var con = GetConnection();
            string query = @"INSERT INTO Student (StudentName, CourseId) 
                         VALUES (@StudentName, @CourseId)";
            con.Execute(query, student);
        }
        public IEnumerable<Student> GetStudentsWithCourse()
        {
            using var con = GetConnection();

            string query = @"SELECT s.*, c.*
                         FROM Student s
                         INNER JOIN Course c ON s.CourseId = c.CourseId";

            return con.Query<Student, Course, Student>(
                query,
                (student, course) =>
                {
                    student.Course = course;
                    return student;
                },
                splitOn: "CourseId"
            );
        }
    }
}

