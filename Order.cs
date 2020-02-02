using System;
using System.Collections.Generic;
using System.Linq;



namespace ConsoleApp1 {
    class Order {
        public int OrderId { get; set; }
        public decimal TotalAmount { get; set; }

        public List<Product> Products;

        public Order(List<Product> productList) {

            if (productList == null) {
                    throw new ArgumentNullException("The list parameter is null");        
            }
            
            TotalAmount = 0;
            Products = new List<Product>(productList);

            for (var i = 0; i < Products.Count; i++) {
                TotalAmount = TotalAmount + Products[i].ProductPrice;
            }

            PrintingMessages.PrintMsg("The cost of the order is:");
            Console.WriteLine($"{TotalAmount} Euros");
        }   
           
        //Get a list of products and select "num " of them and and return them as newList
        public static List<Product> MakeRandomList(List<Product> list1, int num) {

           if (list1 == null) {
                throw new ArgumentNullException("The list parameter is null");
           }

           if (num < 0 || num > list1.Count()) {
                throw new ArgumentException("The num you provided is either greater than list's size or negative");
           }

            Random randomItem = new Random();
            var newList = new List<Product>();

            PrintingMessages.PrintMsg("CUSTOMERS'S LIST");

            for (var i = 0; i < num; i++) {
                newList.Add(list1[randomItem.Next(0, list1.Count)]);
                Console.WriteLine($"The product {newList[i].ProductId} costs {newList[i].ProductPrice} Euros");
            }
           
            return newList;
        }

        //Printing 10 most popular products
        public static void FindPopularProducts(List<Product> list1, List<Product> list2, int num) {

            if (list1 == null) {
                throw new ArgumentNullException($" The {list1} parameter is null ");
            }

            if (list2 == null) {
                throw new ArgumentNullException($" The {list2} parameter is null ");
            }

            var newList = new List<Product>();
            newList = list1.Concat(list2).ToList();

            PrintingMessages.PrintMsg(" PRODUCTS FROM EVERY ORDER ");
            for (var i = 0; i < newList.Count; i++) {
                Console.WriteLine($" {newList[i].ProductId}");

            }

            var popularList = (newList.GroupBy(p => p.ProductId).OrderByDescending(grp => grp.Count())).ToList();

            PrintingMessages.PrintMsg(" POPULAR PRODUCTS ");
                for ( var i = 0; i < num; i++) {
                    Console.WriteLine($" {popularList[i].Key}");
                }    
        }
    }
}
