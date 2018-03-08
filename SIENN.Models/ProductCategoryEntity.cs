namespace SIENN.Models
{
    public class ProductCategoryEntity
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }

        public virtual ProductEntity Product { get; set; }
        public virtual CategoryEntity Category { get; set; }
    }
}
