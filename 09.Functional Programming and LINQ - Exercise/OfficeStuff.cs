using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

public class OfficeStuff
{
    private static void Main()
    {
        var ordersCount = int.Parse(Console.ReadLine());
        var orders = new List<Order>();
        for (int i = 0; i < ordersCount; i++)
        {
            var order = Console.ReadLine()
                .Trim('|')
                .Split('-')
                .Select(x => x.Trim())
                .ToArray();
            orders.Add(new Order(order[0], order[2], int.Parse(order[1])));
        }

        //var groupedComp = 
        orders
            .GroupBy(or => or.CompanyName)
            .OrderBy(x => x.Key)
            .Select(gr => gr   //One line solution
                  .GroupBy(pr => pr.ProductName)
                  .Select(prg => new
                    {
                        CompanyName = gr.Key,
                        ProdName = prg.Key,
                        Amount = prg.Sum(x => x.Amount)
                    })
                   )
            .ToList()
            .ForEach(list => Console.WriteLine(list.Select(x => x.CompanyName).First() + ": " + string.Join(", ", list.Select(x => $"{x.ProdName}-{x.Amount}"))));

        //foreach (var company in groupedComp)
        //{
        //    Console.Write(company.Key + ": ");
        //    var products = company
        //        .GroupBy(pr => pr.ProductName)
        //        .Select(gr => new
        //        {
        //            ProdName = gr.Key,
        //            Amount = gr.Sum(x => x.Amount)
        //        });
        //    Console.Write(string.Join(", ", products.Select(x => $"{x.ProdName}-{x.Amount}")));
        //    Console.WriteLine();
        //}
    }

    private class Order
    {
        public string CompanyName;
        public string ProductName;
        public int Amount;

        public Order(string companyName, string productName, int amount)
        {
            CompanyName = companyName;
            ProductName = productName;
            Amount = amount;
        }
    }
}