using Microsoft.EntityFrameworkCore;
using SIENN.Db;
using SIENN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIENN.DbAccess.Repositories
{
    public class ProductRepository : GenericRepository<ProductEntity>, IProductRepository
    {
        private SIENNDbContext _context;

        public ProductRepository(SIENNDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<ProductEntity> GetAvailableProductsPerPage(int page, int numberOfItemsPerPage)
        {
            var resultPageList = _context.Products.Where(p => p.IsAvailable).Skip(numberOfItemsPerPage * page).Take(numberOfItemsPerPage).ToList();

            return resultPageList;
        }

        public IEnumerable<ProductEntity> Search(int? typeId,
                                                   int? categoryId,
                                                   int? productId,
                                                   string description,
                                                   double? price,
                                                   bool? isAvailable,
                                                   DateTime? deliveryDate
                                                  )
        {
            var selectedProducts = _context.Products
                .Include(x => x.Type)
                .Include(x => x.Unit)
                .Include(x => x.ProductCategories)
                .Include("ProductCategories.Category")
                .Where(p =>
                (typeId.HasValue && p.TypeId == typeId.Value) ||
                (categoryId.HasValue && p.ProductCategories.Any(pc => pc.CategoryId == categoryId.Value)) ||
                (!string.IsNullOrWhiteSpace(description) && p.Description.Equals(description)) ||
                (price.HasValue && p.Price == price.Value) ||
                (isAvailable.HasValue && p.IsAvailable == isAvailable) ||
                (deliveryDate.HasValue && p.DelivaryDate <= deliveryDate.Value)
                ).ToList();

            return selectedProducts;
        }

        public void AddCategory(ProductEntity product, CategoryEntity category)
        {
            if (_context.ProductCategories.Where(x => x.ProductId == product.Id
                                                 && x.CategoryId == category.Id
                                                )
                                         .FirstOrDefault() == null
              )
            {
                product.ProductCategories.Add(new ProductCategoryEntity { Category = category });
                _context.SaveChanges();
            }
        }

        public override IEnumerable<ProductEntity> GetAll()
        {
            var products = _context.Products.Include(p => p.ProductCategories).ToList();
            return products;
        }
    }
}
