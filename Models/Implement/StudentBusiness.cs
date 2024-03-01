using StudentInfo.models;
using StudentInfo.Models.Interface;
using System.Net;

namespace StudentInfo.Models.Implement
{
    public class StudentBusiness : IStudentBusiness
    {
        public List<Student> GetStudent()
        {
            var students = new List<Student>() {
                new Student() {
                    Id= 1,
                    Name= "Shivam",
                    Age= 22,
                    Address= "Bhopal",
                    Email= "shivam@gmail.com",
                    PostalCode= "853443",
            },
                new Student() {
                    Id= 2,
                    Name= "Abhijit",
                    Age= 23,
                    Address= "Bhopal",
                    Email= "abhi@gmail.com",
                    PostalCode= "887443",
            }


            };

            return students;
        }
    }
}
