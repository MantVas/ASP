using System.Collections.Generic;
using System.Linq;

namespace MvcApp2.Models
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private static List<Employee> _employees;
        public EmployeeRepo()
        {
            _employees = new List<Employee>(){
                new Employee() { Id = 1, Name = "Mindaugas"},
                new Employee() { Id = 2, Name = "Jonas"},
                new Employee() { Id = 3, Name = "Petras"}
            };
        }
        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }

        public Employee GetById(int id)
        {
            return _employees.First(e => e.Id == id);
        }
        public bool DeleteById(int? id)
        {
            var e = _employees.First(e => e.Id == id);
            return _employees.Remove(e);
        }
        public void Update(int updateableId, string updatedName)
        {
            System.Console.WriteLine("Repo update: " + updateableId + " : " + updatedName);
            var e = _employees.First(e => e.Id == updateableId);
            e.Name = updatedName;
        }
        public void Create(string name)
        {
            _employees.Add(new Employee() { Id = _employees.Count + 1, Name = name });
        }

    }
}
