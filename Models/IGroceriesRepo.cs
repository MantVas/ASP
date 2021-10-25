using System.Collections.Generic;
namespace MvcApp2.Models
{
    public interface IGroceriesRepo
    {
        IEnumerable<Groceries> GetAll();
        Groceries GetById(int id);
        bool DeleteById(int? id);
        void Create(string name);
        void Update(int updateableId, string updatedName);
    }
}
