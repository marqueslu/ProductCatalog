using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Models;
using ProductCatalog.ViewModels.ProductViewModel;
using ProductCatalog.ViewModels;
using ProductCatalog.Repositories.Interfaces;

namespace ProductCatalog.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [Route("v1/products")]
        [HttpGet]
        public IEnumerable<ListProductViewModel> Get()
        {
            return _productRepository.Get();
        }

        [Route("v1/products/{id}")]
        [HttpGet]
        public Product Get(int id)
        {
            return _productRepository.GetById(id);
        }

        [Route("v1/products")]
        [HttpPost]
        public ResultViewModel Post([FromBody]EditorPRoductViewModel model)
        {
            model.Validate();
            if (model.Invalid)
            {
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível cadastrar o produto",
                    Data = model.Notifications
                };
            }

            var product = new Product();
            product.Title = model.Title;
            product.CategoryId = model.CategoryId;
            product.CreateDate = DateTime.Now;
            product.Description = model.Description;
            product.Image = model.Image;
            product.LastUpdateDate = DateTime.Now;
            product.Price = model.Price;
            product.Quantity = model.Quantity;

            _productRepository.Save(product);

            return new ResultViewModel
            {
                Success = true,
                Message = "Produto Cadastrado com sucesso!",
                Data = product
            };
        }

        [Route("v1/products")]
        [HttpPut]
        public ResultViewModel Put([FromBody]EditorPRoductViewModel model){
            model.Validate();
            if (model.Invalid)
            {
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível cadastrar o produto",
                    Data = model.Notifications
                };
            }

            var product = _productRepository.GetById(model.Id);
            product.Title = model.Title;
            product.CategoryId = model.CategoryId;            
            product.Description = model.Description;
            product.Image = model.Image;
            product.LastUpdateDate = DateTime.Now;
            product.Price = model.Price;
            product.Quantity = model.Quantity;

            _productRepository.Update(product);

            return new ResultViewModel
            {
                Success = true,
                Message = "Produto Cadastrado com sucesso!",
                Data = product
            };
        }
    }
}