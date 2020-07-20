namespace ShopProducts.Products
{
    /// <summary>
    /// Defines products of a fruit type.
    /// </summary>
    public class Fruit : Product, IProductType
    {
        /// <summary>
        /// Creates a fruit product by its name
        /// and price.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        public Fruit(string name, float price)
            : base(price)
        {
            this.Type = "Fruit";
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
        /// concats names strings with dash (Fruit - Fruit),
        /// puts and AVG price of two obj.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Fruit operator +(Fruit lhs, Fruit rhs)
        {
            var strcat = $"{lhs.Name} - {rhs.Name}";
            var avgPrice = (lhs.Price + rhs.Price) / 2;

            return new Fruit(strcat, avgPrice);
        }

        /// <summary>
        /// Explicitly converts a Fruit type to a Fish type.
        /// </summary>
        /// <param name="fish"></param>
        public static explicit operator Fish(Fruit fish)
        {
            return new Fish(fish.Name, fish.Price);
        }

        /// <summary>
        /// Explicitly converts a Fruit type to a Vegetable type.
        /// </summary>
        /// <param name="fish"></param>
        public static explicit operator Vegetable(Fruit fish)
        {
            return new Vegetable(fish.Name, fish.Price);
        }
    }
}
