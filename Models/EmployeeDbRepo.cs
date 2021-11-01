using System.Collections.Generic;
using System.Linq;

namespace MvcApp2.Models
{
    public class EmployeeDbRepo : IEmployeeRepo
    {
        private AppDbContext _dbContext;
        public EmployeeDbRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Employee> GetAll()
        {
            return _dbContext.Employees.ToList();
        }
        public Employee GetById(int id)
        {
            return _dbContext.Employees.Find(id);
        }
        public bool DeleteById(int? id)
        {
            var e = _dbContext.Employees.Find(id);
            _dbContext.Employees.Remove(e);
            return _dbContext.SaveChanges() == 1 ? true : false;
        }
        public void Create(string name)
        {
            _dbContext.Employees.Add(new Employee() { Name = name });
            _dbContext.SaveChanges();
        }
        public void Update(int updateableId, string updatedName)
        {
            var e = _dbContext.Employees.Find(updateableId);
            e.Name = updatedName;
            _dbContext.SaveChanges();
        }
    }
}