using SIENN.Models;
using System;
using System.Collections.Generic;

namespace SIENN.DbAccess.Repositories
{
    public interface IProductRepository : IGenericRepository<ProductEntity>
    {
        IEnumerable<ProductEntity> GetAvailableProductsPerPage(int page, int numberOfItemsPerPage);

        IEnumerable<ProductEntity> Search(int? typeId,
                                          int? categoryId,
                                          int? productId,
                                          string description,
                                          double? price,
                                          bool? isAvailable,
                                          DateTime? deliveryDate);

        void AddCategory(ProductEntity product, CategoryEntity category);
    }
}
