using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class StudentRepository
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }
    }
}
