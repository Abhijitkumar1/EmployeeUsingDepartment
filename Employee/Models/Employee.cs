using System.ComponentModel.DataAnnotations;

namespace Employee.Models
{
    
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
      //  public List<Employe> Employees { get; set; }
    }

    public class Employe
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

        public Department Department { get; set; }
       // public Department Department { get; set; }
    }

}
