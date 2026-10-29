using System;
using System.Linq;
using static ListGenerators; // ProductList و CustomerList 

namespace LINQ___Session_01
{
    internal class Program
    {
        static void Main(string[] args)
        {



            #region Q1
            // 1. Get all products from the "Seafood" category. Print each product's name and price.
            var seafood = ProductList.Where(p => p.Category == "Seafood");

            foreach (var p in seafood)
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");
            #endregion



            #region Q2
            // 2. Get a list of only the product names from ProductList. Print each name.
            var names = ProductList.Select(p => p.ProductName);

            foreach (var name in names)
                Console.WriteLine(name);
            #endregion


            #region Q3
            // 3. Sort all products by UnitPrice (ascending). Print each product's name and price.
            var sortedByPrice = ProductList.OrderBy(p => p.UnitPrice);

            foreach (var p in sortedByPrice)
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");
            #endregion


            #region Q4
            // 4. Get all products where UnitPrice is between 10 and 30.
            var between10And30 = ProductList.Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);

            foreach (var p in between10And30)
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");
            #endregion


            #region Q5
            // 5. Get all products that are in stock (UnitsInStock > 0) and belong to the "Condiments" category.
            var inStockCondiments = ProductList.Where(p => p.UnitsInStock > 0 && p.Category == "Condiments");

            foreach (var p in inStockCondiments)
                Console.WriteLine($"{p.ProductName} - Stock: {p.UnitsInStock}");
            #endregion


            #region Q6
            // 6. Create a new anonymous type with three properties:
            //    Name -> the product name
            //    Price -> the unit price
            //    StockStatus -> "Available" if UnitsInStock > 0, otherwise "Out of Stock"
            //    Print the result.
            var stockResult = ProductList.Select(p => new
            {
                Name = p.ProductName,
                Price = p.UnitPrice,
                StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
            });

            foreach (var item in stockResult)
                Console.WriteLine($"{item.Name} - {item.Price} - {item.StockStatus}");
            #endregion


            #region Q7
            // 7. Print each product's name along with its position (1-based) in the list.
            //    Expected format: 1. Chai, 2. Chang, etc.
            var indexedProducts = ProductList.Select((p, i) => new { Index = i + 1, p.ProductName });

            foreach (var item in indexedProducts)
                Console.WriteLine($"{item.Index}. {item.ProductName}");
            #endregion


            #region Q8
            // 8. Sort ProductList by Category ascending, then within each category, sort by UnitPrice descending.
            var categoryThenPrice = ProductList
                .OrderBy(p => p.Category)
                .ThenByDescending(p => p.UnitPrice);

            foreach (var p in categoryThenPrice)
                Console.WriteLine($"{p.Category} - {p.ProductName} - {p.UnitPrice}");
            #endregion


            #region Q9
            // 9. Get all products from the "Beverages" category, sorted by UnitsInStock descending.
            //    Print name and stock.
            var beverages = ProductList
                .Where(p => p.Category == "Beverages")
                .OrderByDescending(p => p.UnitsInStock);

            foreach (var p in beverages)
                Console.WriteLine($"{p.ProductName} - Stock: {p.UnitsInStock}");
            #endregion


            #region Q10
            // 10. Using QUERY SYNTAX with a compound from clause, list all orders placed in 1997 or later
            //     showing CustomerID and OrderDate.
            var orders1997 = from c in CustomerList
                             from o in c.Orders
                             where o.OrderDate.Year >= 1997
                             select new { c.CustomerID, o.OrderDate };

            foreach (var item in orders1997)
                Console.WriteLine($"{item.CustomerID} - {item.OrderDate}");
            #endregion


            #region Q11
            // 11. Show position number alongside ProductName.
            var withPosition = ProductList.Select((p, i) => new { Position = i + 1, p.ProductName });

            foreach (var item in withPosition)
                Console.WriteLine($"{item.Position} - {item.ProductName}");
            #endregion


            #region Q12
            // 12. Sort first by word length and then by a case-insensitive sort of the words in an array.
            //     String[] Arr = {"aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry"};
            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedWords = Arr
                .OrderBy(w => w.Length)
                .ThenBy(w => w, StringComparer.OrdinalIgnoreCase);

            foreach (var w in sortedWords)
                Console.WriteLine(w);
            #endregion


            #region Q13
            // 13. Create a list of all digits in the array whose second letter is 'i'
            //     that is reversed from the order in the original array.
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var digitsWithI = digits
                .Where(d => d[1] == 'i')
                .Reverse();

            foreach (var d in digitsWithI)
                Console.WriteLine(d);
            #endregion
        }
    }
























































}
    }
}
