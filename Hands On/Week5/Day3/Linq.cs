using System;
using System.Linq;
using LinqCodeTemplate;

namespace LinqCodeTemplate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product();

            // Get product list
            var products = product.GetProducts();

            // 1. Write a LINQ query to search and display all products with category “FMCG”.
            var q1 = products.Where(p => p.ProCategory == "FMCG");
            Console.WriteLine("\nFMCG Products:");
            foreach (var item in q1)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");

            // 2. Write a LINQ query to search and display all products with category “Grain”.
            var q2 = products.Where(p => p.ProCategory == "Grain");
            Console.WriteLine("\nGrain Products:");
            foreach (var item in q2)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");

            // 3. Write a LINQ query to sort products in ascending order by product code.
            var q3 = products.OrderBy(p => p.ProCode);
            Console.WriteLine("\nSort by Code:");
            foreach (var item in q3)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}");

            // 4. Write a LINQ query to sort products in ascending order by product Category.
            var q4 = products.OrderBy(p => p.ProCategory);
            Console.WriteLine("\nSort by Category:");
            foreach (var item in q4)
                Console.WriteLine($"{item.ProCategory}\t{item.ProName}");

            // 5. Write a LINQ query to sort products in ascending order by product Mrp.
            var q5 = products.OrderBy(p => p.ProMrp);
            Console.WriteLine("\nMRP Ascending:");
            foreach (var item in q5)
                Console.WriteLine($"{item.ProName}\t{item.ProMrp}");

            // 6. Write a LINQ query to sort products in descending order by product Mrp.
            var q6 = products.OrderByDescending(p => p.ProMrp);
            Console.WriteLine("\nMRP Descending:");
            foreach (var item in q6)
                Console.WriteLine($"{item.ProName}\t{item.ProMrp}");

            // 7. Write a LINQ query to display products group by product Category.
            var q7 = products.GroupBy(p => p.ProCategory);
            Console.WriteLine("\nGroup by Category:");
            foreach (var group in q7)
            {
                Console.WriteLine("Category: " + group.Key);
                foreach (var item in group)
                    Console.WriteLine(item.ProName);
            }

            // 8. Write a LINQ query to display products group by product Mrp.
            var q8 = products.GroupBy(p => p.ProMrp);
            Console.WriteLine("\nGroup by MRP:");
            foreach (var group in q8)
            {
                Console.WriteLine("Price: " + group.Key);
                foreach (var item in group)
                    Console.WriteLine(item.ProName);
            }

            // 9. Write a LINQ query to display product detail with highest price in FMCG category.
            var q9 = products.Where(p => p.ProCategory == "FMCG")
                             .OrderByDescending(p => p.ProMrp)
                             .First();
            Console.WriteLine("\nHighest FMCG:");
            Console.WriteLine($"{q9.ProName}\t{q9.ProMrp}");

            // 10. Write a LINQ query to display count of total products.
            Console.WriteLine("\nTotal Products: " + products.Count());

            // 11. Write a LINQ query to display count of total products with category FMCG.
            Console.WriteLine("FMCG Count: " + products.Count(p => p.ProCategory == "FMCG"));

            // 12. Write a LINQ query to display Max price.
            Console.WriteLine("\nMax Price: " + products.Max(p => p.ProMrp));

            // 13. Write a LINQ query to display Min price.
            Console.WriteLine("Min Price: " + products.Min(p => p.ProMrp));

            // 14. Write a LINQ query to display whether all products are below Mrp Rs.30 or not.
            Console.WriteLine("\nAll below 30: " + products.All(p => p.ProMrp < 30));

            // 15. Write a LINQ query to display whether any products are below Mrp Rs.30 or not.
            Console.WriteLine("Any below 30: " + products.Any(p => p.ProMrp < 30));

            Console.ReadLine();
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    internal class Product
    {
        public int ProCode { get; set; }

        public string ProName { get; set; }

        public string ProCategory { get; set; }

        public double ProMrp { get; set; }

        public List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product{ProCode=1001,ProName="Colgate-100gm",ProCategory="FMCG",ProMrp=55 },
                 new Product{ProCode=1002,ProName="Colgate-50gm",ProCategory="FMCG",ProMrp=30 },
                 new Product{ProCode=1009,ProName="DaburRed-100gm",ProCategory="FMCG",ProMrp=50 },
                 new Product{ProCode=1006,ProName="DaburRed-50gm",ProCategory="FMCG",ProMrp=28 },
                 new Product{ProCode=1008,ProName="Himalaya Neem Face Wash",ProCategory="FMCG",ProMrp=70 },
                 new Product{ProCode=1007,ProName="Niviea Face Wash",ProCategory="FMCG",ProMrp=120 },
                 new Product{ProCode=1010,ProName="Daawat-Basmati",ProCategory="Grain",ProMrp=130 },
                  new Product{ProCode=1011,ProName="Delhi Gate-Basmati",ProCategory="Grain",ProMrp=120 },
                  new Product{ProCode=1014,ProName="Saffola-Oil",ProCategory="Edible-Oil",ProMrp=160 },
                   new Product{ProCode=1016,ProName="Fortune-Oil",ProCategory="Edible-Oil",ProMrp=150 },
                   new Product{ProCode=1018,ProName="Nescafe",ProCategory="FMCG",ProMrp=70 },
                   new Product{ProCode=1019,ProName="Bru",ProCategory="FMCG",ProMrp=90},
                    new Product{ProCode=1015,ProName="Parachut",ProCategory="Edible-Oil",ProMrp=60}
            };

        }
    }
}