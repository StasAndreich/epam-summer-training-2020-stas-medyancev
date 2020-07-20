using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopProducts.Products;

namespace UnitTests_ShopProducts
{
    [TestClass]
    public class UT_Product_Vegetable
    {
        [TestMethod]
        public void AdditionOperatorOverloading_TwoVegetableObjects_GluedVegetableObject()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create a product with random price.
                var randPrice1 = (float)(rand.Next(0, 10000) * rand.NextDouble());
                var randPrice2 = (float)(rand.Next(0, 10000) * rand.NextDouble());
                var product1 = new Vegetable("name", randPrice1);
                var product2 = new Vegetable("name", randPrice2);

                // Calc expected sum.
                var expectedProduct = new Vegetable("name-name", (randPrice1 + randPrice2) / 2);

                // Calc product sum.
                var resultProduct = product1 + product2;

                if (!expectedProduct.Equals(resultProduct))
                    throw new ApplicationException("Addition of two products is incorrect.");
            }

            // If everything is OK.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ExplicitCastOverloading_VegetableObject_FishObject()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create a product with random price.
                var randPrice = (float)(rand.Next(0, 10000) * rand.NextDouble());
                var product = new Vegetable("name", randPrice);

                var vegetableFromFruit = (Fish)product;
                var expectedProdType = new Fish("name", randPrice);

                if (!expectedProdType.Equals(vegetableFromFruit))
                    throw new InvalidCastException("Incorrect type casting.");
            }

            // If everything is OK.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ExplicitCastOverloading_VegetableObject_FruitObject()
        {
            var attempts = 10000;
            var rand = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // Create a product with random price.
                var randPrice = (float)(rand.Next(0, 10000) * rand.NextDouble());
                var product = new Vegetable("name", randPrice);

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
