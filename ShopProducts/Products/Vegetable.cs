using System;

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
            var strcat = $"{lhs.Name}-{rhs.Name}";
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

        /// <summary>
        /// Checks if two Vegetable objects are equal.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;

            var vegetable = (Vegetable)obj;

            // Float tolerance.
            var tolerance = 0.001f;
            return this.Name.ToUpper() == vegetable.Name.ToUpper()
                && (Math.Abs(this.Price - vegetable.Price) < tolerance);
        }

        /// <summary>
        /// Calculates a vegetable obj hash code.
        /// </summary>
        /// <returns>Int32 hash code.</returns>
        public override int GetHashCode()
        {
            return (int)(this.Name.GetHashCode() / this.Price);
        }

        /// <summary>
        /// Puts a vegetable object to a string.
        /// </summary>
        /// <returns>Formatted string of a vegetable type object.</returns>
        public override string ToString()
        {
            return $"{this.Type}: {this.Name} - {this.Price}";
        }
    }
}
