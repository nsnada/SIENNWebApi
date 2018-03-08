using Microsoft.AspNetCore.Mvc;
using SIENN.DbAccess.Repositories;
using SIENN.Models;
using System;
using System.Collections.Generic;

namespace SIENN.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        private IProductRepository _productRepository;
        private IUnitRepository _unitRepository;
        private ICategoryRepository _categoryRepository;
        private ITypeRepository _typeRepository;


        public ProductController(IProductRepository productRepository,
                                 IUnitRepository unitRepository,
                                 ICategoryRepository categoryRepository,
                                 ITypeRepository typeRepository)
        {
            _productRepository = productRepository;
            _unitRepository = unitRepository;
            _categoryRepository = categoryRepository;
            _typeRepository = typeRepository;
        }
        
        [HttpGet]
        public IEnumerable<ProductEntity> Get()
        {
            return _productRepository.GetAll();
        }
        
        [HttpGet("{id}")]
        public ProductEntity Get(int id)
        {
            return _productRepository.Get(id);

        }
        
        [HttpPost("{description}/{price}/{isAvailable}/{deliveryDate}/{unitId}")]
        public void Create(string description,
                           double price,
                           bool isAvailable,
                           DateTime deliveryDate,
                           int typeId,
                           int unitId
                           )
        {
            UnitEntity unit = _unitRepository.Get(unitId);
            TypeEntity type = _typeRepository.Get(typeId);
            if (unit != null && type != null)
            {
                ProductEntity productEntity = new ProductEntity();
                productEntity.Description = description;
                productEntity.Price = price;
                productEntity.IsAvailable = isAvailable;
                productEntity.DelivaryDate = deliveryDate;
                productEntity.TypeId = typeId;
                productEntity.UnitID = unitId;
                productEntity.Unit = unit;
                productEntity.Type = type;

                _productRepository.Add(productEntity);
            }
        }


        [HttpPut("{id}/{description}/{price}/{isAvailable}/{deliveryDate}/{unitId}")]
        public void Update(int id,
                           string description,
                           double price,
                           bool isAvailable,
                           DateTime deliveryDate,
                           int typeId,
                           int unitId
                          )
        {
            ProductEntity productEntity = _productRepository.Get(id);
            if (productEntity != null)
            {
                UnitEntity unitEntity = _unitRepository.Get(unitId);
                TypeEntity typeEntity = _typeRepository.Get(typeId);

                if (unitEntity != null && typeEntity != null) {
                    productEntity.Unit = unitEntity;
                    productEntity.Type = typeEntity;
                    productEntity.Description = description;
                    productEntity.Price = price;
                    productEntity.IsAvailable = isAvailable;
                    productEntity.DelivaryDate = deliveryDate;
                    productEntity.TypeId = typeId;
                    productEntity.UnitID = unitId;

                    _productRepository.Update(productEntity);
                }                
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ProductEntity product = _productRepository.Get(id);
            if (product != null)
                _productRepository.Remove(product);
        }
        
        [HttpGet("pagination/{page}/{numberOfItemsPerPage}")]
        public IEnumerable<ProductEntity> GetAvailableProductsPerPage(int page, int numberOfItemsPerPage)
        {
            return _productRepository.GetAvailableProductsPerPage(page, numberOfItemsPerPage);
        }
        
        [HttpGet("/productsWithDetails")]
        public IEnumerable<ProductModel> GetProductsWithDetails()
        {
            var productEntities = _productRepository.GetAll();
            var products = new List<ProductModel>();
            foreach (var productEntity in productEntities)
            {
                products.Add(new ProductModel(productEntity));
            }
            return products;
        }

        [HttpPost("/addCategory/{id}/{categoryId}")]
        public void AddCategory(int id, int categoryId)
        {
            ProductEntity product = _productRepository.Get(id);
            CategoryEntity category = _categoryRepository.Get(categoryId);

            if (product == null || category == null)
            {
                return;
            }
            
            _productRepository.AddCategory(product, category);
        }

        [HttpGet("/serchProducts")]
        public IEnumerable<ProductModel> SearchProducts(int? typeId,
                                                   int? categoryId,
                                                   int? productId,
                                                   string description,
                                                   double? price,
                                                   bool? isAvailable,
                                                   DateTime? deliveryDate
                                                  )
        {
            var searchResult = _productRepository.Search(typeId, categoryId, productId, description, price, isAvailable, deliveryDate);

            var products = new List<ProductModel>();
            foreach (var productEntity in searchResult)
            {
                products.Add(new ProductModel(productEntity));
            }
            return products;
        }
    }
}