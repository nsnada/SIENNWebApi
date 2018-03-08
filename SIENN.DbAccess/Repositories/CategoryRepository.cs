using SIENN.Db;
using SIENN.Models;
using System.Linq;

namespace SIENN.DbAccess.Repositories
{
    public class CategoryRepository : GenericRepository<CategoryEntity>, ICategoryRepository
    {
        private SIENNDbContext _context;

        public CategoryRepository(SIENNDbContext context) : base(context)
        {
            _context = context;
        }

        public void AddProduct(CategoryEntity category, ProductEntity product)
        {
            if (_context.ProductCategories.Where(x => x.ProductId == product.Id && x.CategoryId == category.Id).FirstOrDefault() == null)
            {
                category.ProductCategories.Add(new ProductCategoryEntity { Product = product });
                _context.SaveChanges();
            }
        }
    }
}
