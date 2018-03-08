﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIENN.Models
{
    public class ProductEntity
    {
        public ProductEntity()
        {
            ProductCategories = new List<ProductCategoryEntity>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        public bool IsAvailable { get; set; }

        public DateTime DelivaryDate { get; set; }

        [Required]
        public int UnitID { get; set; }
        
        [Required]
        public int TypeId { get; set; }

        public virtual UnitEntity Unit { get; set; }
        public virtual TypeEntity Type { get; set; }
        public virtual IList<ProductCategoryEntity> ProductCategories { get; set; }
    }
}
