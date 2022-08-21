using Microsoft.AspNetCore.Mvc;
using WebApi.Properties;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
        private static List<Employee> EmployeeLists = new List<Employee>()
       {
           new Employee
           {
               Id = 1,
               Name = "Merve",
               Surname = "Bozturk",
               DateofBirth = "26.03.2000",
               Email = "mervebozturk@gmail.com",
               PhoneNumber = "5307031834",
               Salary = 9000,
           },
           new Employee
           {
               Id = 2,
               Name = "Fýrat",
               Surname = "Aydýn",
               DateofBirth = "07.05.1999",
               Email = "firataydin@gmail.com",
               PhoneNumber = "5414145625",
               Salary = 8999,
           },
           new Employee
           {
               Id = 3,
               Name = "Esma",
               Surname = "Poluc",
               DateofBirth = "30.03.2001",
               Email = "esmapoluc@gmail.com",
               PhoneNumber = "5066060134",
               Salary = 8998,
           }


       };

        [HttpGet]  //We use this method to see our data at once.
        public List<Employee> GetEmployees()
        {
            var employeeList = EmployeeLists.OrderBy(x => x.Id).ToList<Employee>();
            return employeeList;

        }

        [HttpGet("{id}")] //we use GetById to call our data one by one
        public Employee GetById(int id)
        {
            var employee = EmployeeLists.Where(employee => employee.Id == id).SingleOrDefault();
            return employee;

        }

        [HttpPost]  //In the post method, we use it when we want to enter new data.

         public IActionResult AddEmployee([FromBody] Employee newEmployee)
        {

        var Employee = EmployeeLists.SingleOrDefault(x => x.Name == newEmployee.Name);

        if (Employee is not null)
            return BadRequest();

        EmployeeLists.Add(newEmployee);
        return Ok();


        }

        [HttpPut("{id}")]  //In the put method, we enter the id information of the data we want to update and enter the information we want to update below.

        public IActionResult UpdateEmployee(int id, [FromBody] Employee updatedEmployee)
        {
            var Employee = EmployeeLists.SingleOrDefault(x=> x.Id == id);
            
            if (Employee is not null)
                return BadRequest();

        Employee.Name = updatedEmployee.Name != default ? updatedEmployee.Name : Employee.Name;
        Employee.Surname = updatedEmployee.Surname != default ? updatedEmployee.Surname : Employee.Surname;
        Employee.DateofBirth = updatedEmployee.DateofBirth != default ? updatedEmployee.DateofBirth : Employee.DateofBirth;
        Employee.Email = updatedEmployee.Email != default ? updatedEmployee.Email : Employee.Email;
        Employee.PhoneNumber = updatedEmployee.PhoneNumber != default ? updatedEmployee.PhoneNumber : Employee.PhoneNumber;
        Employee.Salary = updatedEmployee.Salary != default ? updatedEmployee.Salary : Employee.Salary;

        return Ok();


        }

        [HttpDelete("{id}")]  //In the delete method, we remove it by entering the id information of the data we want to delete.

        public IActionResult DeleteEmployee(int id)
        { 

            var Employee = EmployeeLists.SingleOrDefault(x => x.Id == id);
        if (Employee is null)
            return BadRequest();

        EmployeeLists.Remove(Employee);
        return Ok();
            
        }






}