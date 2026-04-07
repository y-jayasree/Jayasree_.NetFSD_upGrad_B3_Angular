using WebApplication5.Models;

namespace WebApplication5.Repository
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAllCoursesWithStudents();
        IEnumerable<Course> GetCourses();
        void AddCourse(Course course);
    }
}
