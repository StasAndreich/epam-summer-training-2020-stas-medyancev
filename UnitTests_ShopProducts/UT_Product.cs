using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopProducts.Products;

namespace UnitTests_ShopProducts
{
    [TestClass]
    public class UT_Product
    {
        private const float tolerance = 0.001f;

        [TestMethod]
        public void ImplicitCastOverloading_ProductTypeObject_CorrectIntegerValue()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create a product with random price.
                var randPrice = (float)(rand.Next(0, 10000) * rand.NextDouble());
                var product = new Fish("name", randPrice);

                var expectedInt = (int)(randPrice * 100);
                int actualInt = product;

                if ()
            }
        }
    }
}
