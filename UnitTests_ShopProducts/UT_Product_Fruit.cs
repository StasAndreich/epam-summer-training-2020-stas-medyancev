using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopProducts.Products;

namespace UnitTests_ShopProducts
{
    [TestClass]
    public class UT_Product_Fruit
    {
        [TestMethod]
        public void AdditionOperatorOverloading_TwoFruitObjects_GluedFruitObject()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create a product with random price.
                var randPrice1 = (float)(rand.Next(0, 10000) * rand.NextDouble());
                var randPrice2 = (float)(rand.Next(0, 10000) * rand.NextDouble());
                var product1 = new Fruit("name", randPrice1);
                var product2 = new Fruit("name", randPrice2);

                // Calc expected sum.
                var expectedProduct = new Fruit("name-name", (randPrice1 + randPrice2) / 2);

                // Calc product sum.
                var resultProduct = product1 + product2;

                if (!expectedProduct.Equals(resultProduct))
                    throw new ApplicationException("Addition of two products is incorrect.");
            }

            // If everything is OK.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ExplicitCastOverloading_FruitObject_VegetableObject()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create a product with random price.
                var randPrice = (float)(rand.Next(0, 10000) * rand.NextDouble());
                var product = new Fruit("name", randPrice);

                var vegetableFromFruit = (Vegetable)product;
                var expectedProdType = new Vegetable("name", randPrice);

                if (!expectedProdType.Equals(vegetableFromFruit))
                    throw new InvalidCastException("Incorrect type casting.");
            }

            // If everything is OK.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ExplicitCastOverloading_FruitObject_FishObject()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create a product with random price.
                var randPrice = (float)(rand.Next(0, 10000) * rand.NextDouble());
                var product = new Fruit("name", randPrice);

                var fishFromFruit = (Fish)product;
                var expectedProdType = new Fish("name", randPrice);

                if (!expectedProdType.Equals(fishFromFruit))
                    throw new InvalidCastException("Incorrect type casting.");
            }

            // If everything is OK.
            Assert.IsTrue(true);
        }
    }
}
