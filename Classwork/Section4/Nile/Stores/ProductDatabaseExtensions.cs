/*
 * ITSE 1430
 */
using System;
using System.Collections.Generic;
using System.Linq; 

namespace Nile.Stores
{
    /// <summary>Provides extensions for <see cref="IProductDatabase"/>.</summary>
    public static class ProductDatabaseExtensions
    {
        public static Product GetByName( this IProductDatabase source, string name)
        {
            foreach (var item in source.GetAll())
            {
                if (String.Compare(item.Name, name, true) == 0)
                    return item; 
            }
            return null; 
        }
        
        public static IEnumerable<Product> GetPRoductsByDiscountPrice( this IProductDatabase source,
                                                                        Func<Product, decimal> priceCalculator)
        {
            var products = from product in source.GetAll()
                           where product.IsDiscontinued
                           //orderby priceCalculator(product)
                           select new  { Product = product, AdjustedPRice = product.IsDiscontinued ? priceCalculator(product) : product.Price };

            
            return from product in products
                   orderby product.AdjustedPrice
                   select product.Product; 
        }
        //private (Product, AdjustedPRice : decimal) DoSomething()
        //{
        //    return (new Prduct, 10M); 
        //}
        /// <summary>Adds seed data to a database.</summary>
        /// <param name="database">The data to seed.</param>
        public static void WithSeedData( this IProductDatabase source )
        {
            source.Add(new Product() { Name = "Galaxy S7", Price = 650 });
            source.Add(new Product() { Name = "Galaxy Note 7", Price = 150, IsDiscontinued = true });
            source.Add(new Product() { Name = "Windows Phone", Price = 100 });
            source.Add(new Product() { Name = "iPhone X", Price = 1900, IsDiscontinued = true });
        }
    }
}
