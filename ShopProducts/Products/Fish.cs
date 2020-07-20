using System;

namespace ShopProducts.Products
{
    /// <summary>
    /// Defines products of a fish type.
    /// </summary>
    public class Fish : Product
    {
        /// <summary>
        /// Creates a fish product by its name
        /// and price.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        public Fish(string name, float price)
            : base(price)
        {
            this.Type = "Fish";
            this.Name = name;
        }
        
        /// <summary>
        /// Type of the product.
        /// </summary>
        public string Type { get; }
        /// <summary>
        /// Product name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Explicitly converts a Fish type to an Fruit type.
        /// </summary>
        /// <param name="fish"></param>
        public static explicit operator Fruit(Fish fish)
        {

        }

        /// <summary>
        /// Explicitly converts a Fish type to an Vegetable type.
        /// </summary>
        /// <param name="fish"></param>
        public static explicit operator Vegetable(Fish fish)
        {

        }
    }
}
