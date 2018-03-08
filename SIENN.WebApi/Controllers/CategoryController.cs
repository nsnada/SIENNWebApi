using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIENN.DbAccess.Repositories;
using SIENN.Models;

namespace SIENN.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Category")]
    public class CategoryController : Controller
    {
        private ICategoryRepository _categoryRepository;
        private IProductRepository _productRepository;

        public CategoryController(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        [HttpGet]
        public IEnumerable<CategoryEntity> Get()
        {
            return _categoryRepository.GetAll();
        }

        [HttpGet("{id}")]
        public CategoryEntity Get(int id)
        {
            return _categoryRepository.Get(id);
        }


        [HttpPost("{description}")]
        public void Create(string description)
        {
            CategoryEntity category = new CategoryEntity();
            category.Description = description;
            _categoryRepository.Add(category);
        }


        [HttpPut("{id}/{description}")]
        public void Update(int id, string description)
        {
            CategoryEntity categoryEntity = _categoryRepository.Get(id);
            if (categoryEntity != null)
            {
                categoryEntity.Description = description;
                _categoryRepository.Update(categoryEntity);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CategoryEntity category = _categoryRepository.Get(id);
            if (category != null)
            {
                _categoryRepository.Remove(category);
            }
        }


        [HttpPost("/addProduct/{id}/{productId}")]
        public void addProduct(int id, int productId)
        {
            CategoryEntity category = _categoryRepository.Get(id);
            ProductEntity product = _productRepository.Get(productId);

            if (category == null || product == null)
            {
                return;
            }
                        
            _categoryRepository.AddProduct(category, product);
        }
    }
}