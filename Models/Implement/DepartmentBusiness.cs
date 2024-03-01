using StudentInfo.Models.Interface;

namespace StudentInfo.Models.Implement
{
    public class DepartmentBusiness : IDepartmentBusiness
    {
        public List<Department> GetDepartment()
        {
            var Department = new List<Department>() {new Department(){
                Id=1,
            Department_Name = "HR",
            Department_HOD = "Sam",
            Department_Field = "Manager"
        },
                new Department(){
                    Id=2,
            Department_Name = "Sales",
            Department_HOD = "Rohan",
            Department_Field = "BPO"
        }
};

            return Department;
        }


    }
}
