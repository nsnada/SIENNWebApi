using SIENN.Models;
using System;
using System.Linq;

namespace SIENN.Db
{
    public class SIENNDbInitializer
    {
        public static void Initialize(SIENNDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any())
            {
                return;
            }

            TypeEntity type1 = new TypeEntity { Description = "New" };
            TypeEntity type2 = new TypeEntity { Description = "Used" };

            var types = new TypeEntity[2]
            {
                type1, type2
            };

            foreach (var t in types)
            {
                context.Types.Add(t);
            }
            context.SaveChanges();
            
            UnitEntity unit1 = new UnitEntity { Description = "EUR" };
            UnitEntity unit2 = new UnitEntity { Description = "CHF" };
            UnitEntity unit3 = new UnitEntity { Description = "USD" };

            var units = new UnitEntity[3]
            {
                unit1, unit2, unit3
            };

            foreach (var u in units)
            {
                context.Units.Add(u);
            }
            context.SaveChanges();

            CategoryEntity category1 = new CategoryEntity { Description = "Techics" };
            CategoryEntity category2 = new CategoryEntity { Description = "Computer" };
            CategoryEntity category3 = new CategoryEntity { Description = "Home" };
            CategoryEntity category4 = new CategoryEntity { Description = "Fashion" };

            var categories = new CategoryEntity[4]
            {
                category1, category2, category3, category4
            };

            foreach (var c in categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();

            ProductEntity product1 = new ProductEntity {
                Description = "TV",
                Price = 200,
                IsAvailable = true,
                DelivaryDate = new DateTime(2018, 05, 06),
                Unit = unit1,
                UnitID = unit1.Id,
                TypeId = type1.Id
            };
            ProductEntity product2 = new ProductEntity {
                Description = "Scarf",
                Price = 10,
                IsAvailable = false,
                DelivaryDate = new DateTime(2018, 03, 09),
                Unit = unit1,
                UnitID = unit1.Id,
                TypeId = type1.Id
            };
            ProductEntity product3 = new ProductEntity {
                Description = "Monitor",
                Price = 150,
                IsAvailable = true,
                DelivaryDate = new DateTime(2018, 01, 10),
                Unit = unit3,
                UnitID = unit3.Id,
                TypeId = type2.Id
            };
                        
            ProductEntity product4 = new ProductEntity
            {
                Description = "Radio",
                Price = 110,
                IsAvailable = true,
                DelivaryDate = new DateTime(2018, 03, 08),
                Unit = unit1,
                UnitID = unit1.Id,
                TypeId = type2.Id
            };

            ProductEntity product5 = new ProductEntity
            {
                Description = "Cooler",
                Price = 15,
                IsAvailable = true,
                DelivaryDate = new DateTime(2018, 05, 06),
                Unit = unit1,
                UnitID = unit1.Id,
                TypeId = type2.Id
            };

            var products = new ProductEntity[5]
            {
                product1, product2, product3, product4, product5
            };
            foreach (var p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();

            ProductCategoryEntity productCategory1 = new ProductCategoryEntity {
                Product = product1,
                ProductId = product1.Id,
                Category = category1,
                CategoryId = category1.Id
            };

            ProductCategoryEntity productCategory2 = new ProductCategoryEntity {
                Product = product2,
                ProductId = product2.Id,
                Category = category4,
                CategoryId = category4.Id
            };

            ProductCategoryEntity productCategory3 = new ProductCategoryEntity {
                Product = product1,
                ProductId = product1.Id,
                Category = category3,
                CategoryId = category3.Id
            };

            ProductCategoryEntity productCategory4 = new ProductCategoryEntity
            {
                Product = product3,
                ProductId = product3.Id,
                Category = category2,
                CategoryId = category2.Id
            };

            ProductCategoryEntity productCategory5 = new ProductCategoryEntity
            {
                Product = product4,
                ProductId = product4.Id,
                Category = category3,
                CategoryId = category3.Id
            };

            ProductCategoryEntity productCategory6 = new ProductCategoryEntity
            {
                Product = product3,
                ProductId = product3.Id,
                Category = category1,
                CategoryId = category1.Id
            };

            var productCategories = new ProductCategoryEntity[6]
            {
                productCategory1,
                productCategory2,
                productCategory3,
                productCategory4,
                productCategory5,
                productCategory6
            };

            foreach (var pc in productCategories)
            {
                context.ProductCategories.Add(pc);
            }
            context.SaveChanges();
        }
    }
}
