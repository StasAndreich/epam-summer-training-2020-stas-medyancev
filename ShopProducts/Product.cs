using System;

namespace ShopProducts
{
    /// <summary>
    /// Defines a shop product.
    /// </summary>
    public abstract class Product
    {
        /// <summary>
        /// Default ctor that inits basic product props.
        /// </summary>
        /// <param name="price"></param>
        public Product(float price)
        {
            this.Price = price;
        }

        /// <summary>
        /// Product price.
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// Implicitly converts a product type to an integer type.
        /// </summary>
        /// <param name="product"></param>
        public static implicit operator int(Product product)
        {
            // Find an integer price.
            // 100 is a amt of 'penny' in 1 money unit.
            return (int)(product.Price * 100);
        }

        /// <summary>
        /// Implicitly converts a product type to a float type.
        /// </summary>
        /// <param name="product"></param>
        public static implicit operator float(Product product)
        {
            // Return float price of a product.
            return product.Price;
        }
    }
}
