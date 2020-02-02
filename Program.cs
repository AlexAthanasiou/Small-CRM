using System;

namespace ConsoleApp1 {
    class Program
    {
       //public static ILogger Logger;

        static void Main(string[] args) 
        {
            var products = Product.LoadProductList("products.csv");

            var newlist1 =  Order.MakeRandomList(products, 10);
            var newOrder = new Order(newlist1);
            var customer1 = new Customer("athanasiou1", newOrder);

            var newlist2 = Order.MakeRandomList(products, 10);
            newOrder = new Order(newlist2);
            var customer2 = new Customer("athanasiou2", newOrder);

            Order.FindPopularProducts(newlist1, newlist2, 10);
            Customer.BestCustomer(customer1, customer2);

            /*
                        Logger = FileLogger.GetInstance();

                        Console.WriteLine("Please enter your Lastname:");
                        var lastName = Console.ReadLine();

                        Console.WriteLine("please enter your first name:");
                        var firstName = Console.ReadLine();

                        var age = GetAge();
                        if (age == null) {
                            return;
                        }

                        var person1 = default(Person);
                        try {
                            person1 = new Person(lastName);
                            person1.Age = age.Value;
                            person1.FirstName = firstName;
                        } catch (Exception e) {
                            Logger.Log(e);
                            return;
                        }

                        Console.WriteLine(@$"Your lastname is {person1.LastName},
                            your firstname is {person1.FirstName} and you are
                            {(person1.IsAdult() ? "" : "not")} an adult");
                    }

                    public static int? GetAge()
                    {
                        Console.WriteLine("please enter your age:");

                        var value = Console.ReadLine();

                        if (!int.TryParse(value, out var age)) {
                            Logger.Log($"Value {value} is not a valid age");
                            Console.WriteLine("Age is not a number");
                            return null;
                        }

                        return age;
                    }
                    */
        }
    }
}