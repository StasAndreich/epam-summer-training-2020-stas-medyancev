namespace ShopProducts
{
    /// <summary>
    /// Contains definitions for a Product type elements.
    /// </summary>
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
