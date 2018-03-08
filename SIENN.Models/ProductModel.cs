using System;

namespace SIENN.Models
{
    public class ProductModel
    {
        public ProductModel() { }
        public ProductModel(ProductEntity product)
        {
            Description = String.Format(" ({0}) {1}", product.Id, product.Description);
            Price = product.Price.ToString("C2");
            IsAvailable = product.IsAvailable ? "Available" : "Unavailable";
            DelivaryDate = $"{product.DelivaryDate.Day}.{product.DelivaryDate.Month}.{product.DelivaryDate.Year}";
            CategoriesCount = product.ProductCategories.Count;
            Type = String.Format(" ({0}) {1}", product.TypeId, product.Type.Description);
            Unit = String.Format(" ({0}) {1}", product.UnitID, product.Unit.Description);
        }

        public string Description { get; set; }
        public string IsAvailable { get; set; }
        public string Price { get; set; }
        public string DelivaryDate { get; set; }
        public int CategoriesCount { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }
    }
}
