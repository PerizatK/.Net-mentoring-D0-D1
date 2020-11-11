using System;

namespace CheckDebugging
{
    public class Product
    {
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public double Price { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var products = new Product[]
         {
                new Product("Product 1", 10.0d),
                new Product("Product 2", 20.0d),
                new Product("Product 3", 30.0d),
         };
            var productToFind = new Product("Product 3", 30.0d);
            int index = Utilities.IndexOf(products, delegate (Product product) { return product.Equals(productToFind); });

            //          Assert.That(index, Is.EqualTo(2));
            Console.WriteLine(index);
            Console.ReadKey();
        }

        public class Utilities
        {
            /// <summary>
            /// Searches for the index of a product in an <paramref name="products"/> 
            /// based on a <paramref name="predicate"/>.
            /// </summary>
            /// <param name="products">Products used for searching.</param>
            /// <param name="predicate">Product predicate.</param>
            /// <returns>If match found then returns index of product in <paramref name="products"/>
            /// otherwise -1.</returns>
            public static int IndexOf(Product[] products, Predicate<Product> predicate)
            {
                if (products is null || predicate is null)
                    throw new ArgumentNullException("Method recieved some null argument");
                for (int i = 0; i < products.Length; i++)
                {
                    Product product = products[i];
                    if (predicate(product))
                    {
                        return i;
                    }
                }

                return -1;
            }
        }
    }
}

