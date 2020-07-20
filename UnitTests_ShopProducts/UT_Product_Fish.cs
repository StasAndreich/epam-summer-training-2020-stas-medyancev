using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopProducts.Products;

namespace UnitTests_ShopProducts
{
    [TestClass]
    public class UT_Product_Fish
    {
        [TestMethod]
        public void AdditionOperatorOverloading_TwoFishObjects_GluedFishObject()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create a product with random price.
                var randPrice1 = (float)(rand.Next(0, 10000) * rand.NextDouble());
                var randPrice2 = (float)(rand.Next(0, 10000) * rand.NextDouble());
                var product1 = new Fish("name", randPrice1);
                var product2 = new Fish("name", randPrice2);

                // Calc expected sum.
                var expectedProduct = new Fish("name-name", (randPrice1 + randPrice2) / 2);

                // Calc product sum.
                var resultProduct = product1 + product2;

                if (!expectedProduct.Equals(resultProduct))
                    throw new ApplicationException("Addition of two products is incorrect.");
            }

            // If everything is OK.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ExplicitCastOverloading_FishObject_VegetableObject()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create a product with random price.
                var randPrice = (float)(rand.Next(0, 10000) * rand.NextDouble());
                var product = new Fish("name", randPrice);

                var vegetableFromFruit = (Vegetable)product;
                var expectedProdType = new Vegetable("name", randPrice);

                if (!expectedProdType.Equals(vegetableFromFruit))
                    throw new InvalidCastException("Incorrect type casting.");
            }

            // If everything is OK.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ExplicitCastOverloading_FishObject_FruitObject()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create a product with random price.
                var randPrice = (float)(rand.Next(0, 10000) * rand.NextDouble());
                var product = new Fish("name", randPrice);

                var fishFromFruit = (Fruit)product;
                var expectedProdType = new Fruit("name", randPrice);

                if (!expectedProdType.Equals(fishFromFruit))
                    throw new InvalidCastException("Incorrect type casting.");
            }

            // If everything is OK.
            Assert.IsTrue(true);
        }
    }
}
