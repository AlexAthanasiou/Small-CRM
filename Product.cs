using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;



namespace ConsoleApp1 {
    public class Product 
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public Product() { }

        public Product(string str1, string str2) {

            Random randomItem = new Random();
            ProductId = str1;
            ProductDescription = str2;   
            ProductPrice =(decimal)Math.Round(randomItem.NextDouble() * 50 + 0.1, 2) ;
        }

        //Overloading Equals method
        internal class ProductComparer : IEqualityComparer<Product> {

            public bool Equals(Product product1, Product product2) {
                return (string.Equals(product1.ProductId, product2.ProductId));
            }
           
            public int GetHashCode(Product obj) {
                return obj.ProductId.GetHashCode();
            }
        }

        //Loading products from CSV and storing them to LIST
        public static List<Product> LoadProductList(string filename) {

            if (string.IsNullOrWhiteSpace(filename)) {
                throw new ArgumentNullException(nameof(filename));
            }
 
            var fileRows = File.ReadAllLines(filename);   
            
            foreach (var s in fileRows) { 
                if (string.IsNullOrWhiteSpace(s)) {
                    throw new ArgumentNullException(nameof(s));
                }
            }

            List<Product> ListOfProducts = new List<Product>();
           
            for (var i=0 ; i<fileRows.Length; i++) {
                var rowSplit = fileRows[i].Split(';');
                ListOfProducts.Add(new Product(rowSplit[0], rowSplit[1]));
            }

            ListOfProducts = ListOfProducts.Distinct(new ProductComparer()).ToList();

            PrintingMessages.PrintMsg("PRODUCT LIST");

            for(var i=0; i<ListOfProducts.Count; i++) {
                Console.WriteLine($" ID: {ListOfProducts[i].ProductId}, Price: {ListOfProducts[i].ProductPrice} Euros ");
            }
            return ListOfProducts;
        }
    }
}

 