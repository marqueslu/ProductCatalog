using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Models;
using ProductCatalog.Repositories.Interfaces;

namespace ProductCatalog.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [Route("v1/categories")]
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _categoryRepository.Get();
        }

        [Route("v1/categories/{id}")]
        [HttpGet]
        public Category get(int id)
        {
            return _categoryRepository.getById(id);
        }

        [Route("v1/categories/{id}/products")]
        [HttpGet]
        public IEnumerable<Product> GetProducts(int id)
        {
            return _categoryRepository.GetProducts(id);
        }

        [Route("v1/categories")]
        [HttpPost]
        public Category Post([FromBody]Category category)
        {
            _categoryRepository.Save(category);
            return category;
        }

        [Route("v1/categories")]
        [HttpPut]
        public Category Put([FromBody]Category category)
        {
            _categoryRepository.Update(category);
            return category;
        }

        [Route("v1/categories")]
        [HttpDelete]
        public Category Delete([FromBody]Category category)
        {
            _categoryRepository.Delete(category);
            return category;
        }
    }
}