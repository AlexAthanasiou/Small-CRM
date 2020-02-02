using System;

namespace ConsoleApp1
{
    class Person
    {
        private int age_;

        public virtual int Age { 
            get {
                return age_;
            }
            set {
                if (value >= 1 && value < 120) {
                    age_ = value;
                    return;
                }

                throw new ArgumentOutOfRangeException(
                    "age", "Age must be in range [1, 120]");
            }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName)) {
                throw new ArgumentNullException(nameof(lastName));
            }

            LastName = lastName;
        }

        public string GetFullname()
        {
            return $"{FirstName} {LastName}";
        }

        public bool IsAdult()
        {
            return Age >= 18;
        }
    }
}
