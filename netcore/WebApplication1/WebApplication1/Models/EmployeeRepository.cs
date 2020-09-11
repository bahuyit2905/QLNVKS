using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> employees;
        public EmployeeRepository()
        {
            employees = new List<Employee>()
            {
                new Employee() { 
                    Id = 1, 
                    Fullname = "Huy Nguyen", 
                    Department= Dept.Manage, 
                    Email="huynguyenn@gmail.com", 
                    AvatarPath = "/images/av1.png"
                },
                 new Employee() {
                    Id = 2,
                    Fullname = "Trung Nguyen",
                    Department= Dept.Serve,
                    Email="huynguyen33n@gmail.com",
                    AvatarPath = "/images/av2.png"
                }

            };
        }

        public Employee Create(Employee employee)
        {
            employee.Id = employees.Max(e => e.Id) + 1;
            employee.AvatarPath = "/images/av2.png";
            employees.Add(employee);
            return employee;
        }

        public bool Delete(int id)
        {
            var delEmp = Get(id);
            if(delEmp != null)
            {
                employees.Remove(delEmp);
                return true;
            }
            return false;
        }

        public Employee Edit(Employee employee)
        {
            var editEmp = Get(employee.Id);
            editEmp.Fullname = employee.Fullname;
            editEmp.Email = employee.Email;
            editEmp.Department = employee.Department;
            return editEmp;
        }

        public Employee Get(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Employee> Gets()
        {
            return employees;
        }
    }
}
