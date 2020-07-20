namespace ShopProducts.Products
{
    /// <summary>
    /// Defines products of a vegetable type.
    /// </summary>
    public class Vegetable : Product, IProductType
    {
        /// <summary>
        /// Creates a vegetable product by its name
        /// and price.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        public Vegetable(string name, float price)
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
        /// concats names strings with dash (Vegetable - Vegetable),
        /// puts and AVG price of two obj.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Vegetable operator +(Vegetable lhs, Vegetable rhs)
        {
            var strcat = $"{lhs.Name} - {rhs.Name}";
            var avgPrice = (lhs.Price + rhs.Price) / 2;

            return new Vegetable(strcat, avgPrice);
        }

        /// <summary>
        /// Explicitly converts a Vegetable type to a Fish type.
        /// </summary>
        /// <param name="fish"></param>
        public static explicit operator Fish(Vegetable fish)
        {
            return new Fish(fish.Name, fish.Price);
        }

        /// <summary>
        /// Explicitly converts a Vegetable type to a Fruit type.
        /// </summary>
        /// <param name="fish"></param>
        public static explicit operator Fruit(Vegetable fish)
        {
            return new Fruit(fish.Name, fish.Price);
        }
    }
}
