using System.Collections.Generic;
using System;

namespace ConsoleApp1
{
    class Customer : Person
    {
        public int CustomerId { get; set; }

        public List<Order> Orders { get; set; }

        public decimal FinalCost { get; set; }

        public Customer(string lastname)
            : base(lastname) { 
        
            Age = 20;
            Orders = new List<Order>();
        }

        // Constructor for adding an order to the Order list
        public Customer(string lastname, Order order) : base(lastname) {

            Orders = new List<Order>();
            Orders.Add(order);
        }

        ////Operator overloading for Customer objects Comparison
        public static bool operator <(Customer customer1, Customer customer2) {
            return (TotalCost(customer1) < TotalCost(customer2));
        }

        public static bool operator >(Customer customer1, Customer customer2) {
            return (TotalCost(customer1) > TotalCost(customer2));
        }

        public static bool operator ==(Customer customer1, Customer customer2) {
            return (TotalCost(customer1) == TotalCost(customer2));
        }

        public static bool operator !=(Customer customer1, Customer customer2) {
            return (TotalCost(customer1) != TotalCost(customer2));
        }

        //Finds the best customer comparing the total costs from every order
        public static void BestCustomer(Customer customer1, Customer customer2) {

            PrintingMessages.PrintMsg("BEST CUSTOMER");
            if (customer1 == customer2) {
                Console.WriteLine($"{customer1} and {customer2} spent the same amount");
            } 
            else if (customer1 <customer2) {
                Console.WriteLine($"{customer2.LastName} spent {customer2.FinalCost} Euros");
            }
            else {
                Console.WriteLine($"{customer1.LastName} spent {customer1.FinalCost} Euros");
            }
        }

        //Calculating the total cost of every order in an order list
        public static decimal TotalCost(Customer customer) {

            decimal tempCost = 0;

            for (var i=0; i<customer.Orders.Count; i++) {
                tempCost = tempCost + customer.Orders[i].TotalAmount;
            }
            customer.FinalCost = tempCost;
            return tempCost;
        }
    }
}
