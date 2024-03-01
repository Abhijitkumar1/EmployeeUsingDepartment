using Employee.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;
        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
       
        [HttpGet]
        public ActionResult<IEnumerable<object>> GetEmployees(
     string firstName, string middleName, string lastName, string departmentName, string gender)
        {
            var query = _context.Employees
                .Join(
                    _context.Departments,
                    employee => employee.Department.DepartmentId,
                    department => department.DepartmentId,
                    (employee, department) => new
                    {
                        EmployeeId = employee.EmployeeId,
                        FirstName = employee.FirstName,
                        MiddleName = employee.MiddleName,
                        LastName = employee.LastName,
                        Gender = employee.Gender,
                        DepartmentId = department.DepartmentId,
                        DepartmentName = department.DepartmentName
                    }
                )
                .AsQueryable();

            if (!string.IsNullOrEmpty(firstName))
                query = query.Where(e => e.FirstName.Contains(firstName));

            if (!string.IsNullOrEmpty(middleName))
                query = query.Where(e => e.MiddleName.Contains(middleName));

            if (!string.IsNullOrEmpty(lastName))
                query = query.Where(e => e.LastName.Contains(lastName));

            if (!string.IsNullOrEmpty(departmentName))
                query = query.Where(e => e.DepartmentName.Contains(departmentName));

            if (!string.IsNullOrEmpty(gender))
                query = query.Where(e => e.Gender.Equals(gender));

            var employeesWithDepartments = query.ToList();
            return Ok(employeesWithDepartments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employe>> GetEmployeeById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employe>> CreateEmployee(Employe employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employe updatedEmployee)
        {
            if (id != updatedEmployee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(updatedEmployee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(updatedEmployee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }

}


