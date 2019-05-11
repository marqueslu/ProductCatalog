using System.Collections.Generic;
using ProductCatalog.Models;
using ProductCatalog.ViewModels.ProductViewModel;

namespace ProductCatalog.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<ListProductViewModel> Get();
        Product GetById(int id);
        void Save(Product product);
        void Update(Product product);
    }
}
