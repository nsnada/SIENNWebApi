using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIENN.Models
{
    public class CategoryEntity
    {
        public CategoryEntity()
        {
            ProductCategories = new List<ProductCategoryEntity>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public virtual IList<ProductCategoryEntity> ProductCategories { get; set; }
    }
}
