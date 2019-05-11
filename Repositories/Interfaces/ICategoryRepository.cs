using System.Collections.Generic;
using ProductCatalog.Models;

namespace ProductCatalog.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Get();
        Category getById(int id);
        IEnumerable<Product> GetProducts(int id);
        void Save(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}
