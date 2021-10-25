using System.Collections.Generic;
using System.Linq;

namespace MvcApp2.Models
{
    public class GroceriesRepo : IGroceriesRepo
    {
        private static List<Groceries> _groceries;
        public GroceriesRepo()
        {
            _groceries = new List<Groceries>(){
                new Groceries() { Id = 1, Name = "Coffee", Count = 2},
                new Groceries() { Id = 2, Name = "Chocolate",Count = 4},
                new Groceries() { Id = 3, Name = "Oil",Count = 1},
                new Groceries() { Id = 4, Name = "Sugar",Count = 5},
            };
        }
        public IEnumerable<Groceries> GetAll()
        {
            return _groceries;
        }

        public Groceries GetById(int id)
        {
            return _groceries.First(e => e.Id == id);
        }
        public bool DeleteById(int? id)
        {
            var e = _groceries.First(e => e.Id == id);
            return _groceries.Remove(e);
        }
        public void Update(int updateableId, string updatedName)
        {
            System.Console.WriteLine("Repo update: " + updateableId + " : " + updatedName);
            var e = _groceries.First(e => e.Id == updateableId);
            e.Name = updatedName;
        }
        public void Create(string name)
        {
            _groceries.Add(new Groceries() { Id = _groceries.Count + 1, Name = name, Count = _groceries.Count + 1 });
        }
    }
}
