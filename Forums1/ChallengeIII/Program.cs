using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Want a challenge III
// https://social.msdn.microsoft.com/Forums/en-US/06610ab7-9fd4-416d-aba7-95d0906d6dae/want-a-challenge-iii?forum=vbgeneral

namespace ChallengeIII
{
    public class Product : IEquatable<Product>
    {
        public string ProductName { get; set; }
        public int CategoryIdentifier { get; set; }

        public override int GetHashCode()
        {
            return this.ProductName.GetHashCode() + CategoryIdentifier;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Product))
                return false;
            return Equals((Product)obj);
        }

        public bool Equals(Product other)
        {
            if (ProductName != other.ProductName)
                return false;
            return CategoryIdentifier == other.CategoryIdentifier;
        }

        public static bool operator ==(Product product1, Product product2)
        {
            return product1.Equals(product2);
        }

        public static bool operator !=(Product product1, Product product2)
        {
            return !product1.Equals(product2);
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            List<Product> products =  new List<Product>()
                {
                new Product()
                {
                    CategoryIdentifier = 5,
                    ProductName = "Apples"
                },
                new Product()
                {
                    CategoryIdentifier = 7,
                    ProductName = "Apples"
                },
                new Product()
                {
                    CategoryIdentifier = 5,
                    ProductName = "Apples"
                },
                new Product()
                {
                    CategoryIdentifier = 1,
                    ProductName = "Grapes"
                },
                new Product()
                {
                    CategoryIdentifier = 11,
                    ProductName = "Bread"
                }
            };

            IEnumerable<Product> noDuplicates = products.Distinct();
            foreach (Product product in noDuplicates)
            {
                Console.WriteLine($"{product.CategoryIdentifier}, {product.ProductName}");
            }
        }
    }
}
