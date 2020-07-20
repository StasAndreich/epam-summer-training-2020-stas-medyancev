namespace ShopProducts.Products
{
    /// <summary>
    /// Defines products of a fish type.
    /// </summary>
    public class Fish : Product, IProductType
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
        /// Adds two fish objects:
        /// concats names strings with dash (Fish - Fish),
        /// puts and AVG price of two obj.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Fish operator +(Fish lhs, Fish rhs)
        {
            var strcat = $"{lhs.Name} - {rhs.Name}";
            var avgPrice = (lhs.Price + rhs.Price) / 2;

            return new Fish(strcat, avgPrice);
        }

        /// <summary>
        /// Explicitly converts a Fish type to a Fruit type.
        /// </summary>
        /// <param name="fish"></param>
        public static explicit operator Fruit(Fish fish)
        {
            return new Fruit(fish.Name, fish.Price);
        }

        /// <summary>
        /// Explicitly converts a Fish type to a Vegetable type.
        /// </summary>
        /// <param name="fish"></param>
        public static explicit operator Vegetable(Fish fish)
        {
            return new Vegetable(fish.Name, fish.Price);
        }
    }
}
