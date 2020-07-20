namespace ShopProducts
{
    interface IProductType
    {
        /// <summary>
        /// Type of the product.
        /// </summary>
        string Type { get; }
        /// <summary>
        /// Product name.
        /// </summary>
        string Name { get; }
    }
}
