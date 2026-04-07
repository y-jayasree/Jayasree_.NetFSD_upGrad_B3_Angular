using Dapper;
using Microsoft.Data.SqlClient;
using WebApplication5.Models;

namespace WebApplication5.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly string connStr;

        public CourseRepository(IConfiguration config)
        {
            connStr = config.GetConnectionString("DefaultConnection");
        }

        private SqlConnection GetConnection() => new SqlConnection(connStr);
        public IEnumerable<Course> GetCourses()
        {
            using var conn = GetConnection();
            return conn.Query<Course>("SELECT * FROM Course");
        }

        public void AddCourse(Course course)
        {
            using var con = GetConnection();
            string query = "INSERT INTO Course (CourseName) VALUES (@CourseName)";
            con.Execute(query, course);
        }
        public IEnumerable<Course> GetAllCoursesWithStudents()
        {
            using var conn = GetConnection();
            string query = @"
                SELECT c.*, s.*
                FROM Course c
                LEFT JOIN Student s ON c.CourseId = s.CourseId
            ";

            var courseDict = new Dictionary<int, Course>();

            var result = conn.Query<Course, Student, Course>(
                query,
                (course, student) =>
                {
                    if (!courseDict.TryGetValue(course.CourseId, out var currentCourse))
                    {
                        currentCourse = course;
                        currentCourse.Students = new List<Student>();
                        courseDict.Add(currentCourse.CourseId, currentCourse);
                    }

                    if (student != null)
                        currentCourse.Students.Add(student);

                    return currentCourse;
                },
                splitOn: "StudentId"
            );

            return courseDict.Values;
        }
        public void AddStudent(Student student)
        {
            using var con = GetConnection();
            string query = @"INSERT INTO Student (StudentName, CourseId)
                             VALUES (@StudentName, @CourseId)";
            con.Execute(query, student);
        }
    }
}
