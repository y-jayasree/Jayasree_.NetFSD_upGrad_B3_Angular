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
            var q1 = from p in products
                     where p.ProCategory == "FMCG"
                     select p;
            foreach (var item in q1)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }
            Console.WriteLine("--------------------");

            // 2. Write a LINQ query to search and display all products with category “Grain”.
            var q2 = from p in products
                     where p.ProCategory == "Grain"
                     select p;

            foreach (var item in q2)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}");
            }
            Console.WriteLine("--------------------");

            // 3. Write a LINQ query to sort products in ascending order by product code.
            var q3 = from p in products
                     orderby p.ProCode
                     select p;
            foreach (var item in q3)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}");
            }
            Console.WriteLine("--------------------");


            // 4. Write a LINQ query to sort products in ascending order by product Category.
            var q4 = from p in products
                     orderby p.ProCategory
                     select p;
            foreach (var item in q4)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}");
            }
            Console.WriteLine("--------------------");


            // 5. Write a LINQ query to sort products in ascending order by product Mrp.
            var q5 = from p in products
                     orderby p.ProMrp
                     select p;
            foreach (var item in q5)
            {
                Console.WriteLine($"{ item.ProCode}\t{ item.ProName}\t{ item.ProMrp}");
            }
            Console.WriteLine("--------------------");

            // 6. Write a LINQ query to sort products in descending order by product Mrp.
            var q6 = from p in products
                     orderby p.ProMrp descending
                     select p;
            foreach (var item in q6)
            {
                Console.WriteLine($"{item.ProName}\t{item.ProMrp}");
            }
            Console.WriteLine("--------------------");

            // 7. Write a LINQ query to display products group by product Category.
            var q7 = from p in products
                     group p by p.ProCategory;
            foreach (var group in q7)
            {
                Console.WriteLine("Category: " + group.Key);

                foreach (var item in group)
                {
                    Console.WriteLine(item.ProName);
                }
            }
            Console.WriteLine("--------------------");

            // 8. Write a LINQ query to display products group by product Mrp.
            var q8 = from p in products
                     group p by p.ProMrp;
            foreach (var group in q8)
            {
                Console.WriteLine("Price: " + group.Key);

                foreach (var item in group)
                {
                    Console.WriteLine(item.ProName);
                }
            }
            Console.WriteLine("--------------------");

            // 9. Write a LINQ query to display product detail with highest price in FMCG category.
            var q9 = (from p in products
                      where p.ProCategory == "FMCG"
                      orderby p.ProMrp descending
                      select p).First();

            Console.WriteLine($"{q9.ProCode}\t{q9.ProName}\t{q9.ProMrp}");

            Console.WriteLine("--------------------");

            // 10. Write a LINQ query to display count of total products.
            Console.WriteLine((from p in products select p).Count());
            
            
            Console.WriteLine("--------------------");

            // 11. Write a LINQ query to display count of total products with category FMCG.
             Console.WriteLine((from p in products
                       where p.ProCategory == "FMCG"
                       select p).Count());
            
            Console.WriteLine("--------------------");

            // 12. Write a LINQ query to display Max price.
            Console.WriteLine((from p in products select p.ProMrp).Max());

 
            Console.WriteLine("--------------------");

            // 13. Write a LINQ query to display Min price.
            Console.WriteLine((from p in products select p.ProMrp).Min());

            
            Console.WriteLine("--------------------");

            // 14. Write a LINQ query to display whether all products are below Mrp Rs.30 or not.
            Console.WriteLine(products.All(p => p.ProMrp < 30));

            
            Console.WriteLine("--------------------");

            // 15. Write a LINQ query to display whether any products are below Mrp Rs.30 or not.
            Console.WriteLine(products.Any(p => p.ProMrp < 30));
            
            Console.WriteLine("--------------------");


            Console.ReadLine();
        }
    }
}
