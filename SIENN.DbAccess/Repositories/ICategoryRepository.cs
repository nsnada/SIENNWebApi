using SIENN.Models;

namespace SIENN.DbAccess.Repositories
{
    public interface ICategoryRepository : IGenericRepository<CategoryEntity>
    {
        void AddProduct(CategoryEntity category, ProductEntity product);
    }    
}
