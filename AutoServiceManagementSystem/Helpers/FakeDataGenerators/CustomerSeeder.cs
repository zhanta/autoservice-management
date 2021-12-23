using AutoServiceManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace AutoServiceManagementSystem.Helpers
{
	public static class CustomerSeeder
	{
        private static Random rand = new Random();

        private static string[] femaleFirstNames = 
        {
            "Albena", "Adelina", "Adriana", "Ana", "Anelia"
        };

        private static string[] maleFirstNames = 
        {
            "Angel", "Anatoli", "Anton", "Blago", "Bozhidar"
        };

        private static string[] lastNames = 
        {
            "Ivanov", "Petrov", "Iliev", "Georgiev", "Mitev"
        };

		private static string[] cityNames = 
		{
			"Ruse", "Sofia", "Varna", "Lom", "Burgas"
		};

        public enum Sex
        {
            Male,
            Female
        }

        public static Sex GenerateSex()
        {
            return (rand.Next(0, 2) % 2) == 0 ? Sex.Male : Sex.Female;
        }

        
        public static Dictionary<string, string> GenerateName(Sex sex)
        {
            var name = new Dictionary<string, string>();
            switch (sex)
            {
                case Sex.Male:
                    name["first"] = maleFirstNames[rand.Next(0, maleFirstNames.Length)];
                    name["last"] = lastNames[rand.Next(0, lastNames.Length)];
                    break;
                case Sex.Female:
                    name["first"] = femaleFirstNames[rand.Next(0, femaleFirstNames.Length)];
                    name["last"] = lastNames[rand.Next(0, lastNames.Length)] + "a";
                    break;
            }
            return name;
        }

       
        public static string GeneratePhoneNumber()
        {
            var phoneNumber = new StringBuilder();
            phoneNumber.Append("08");
            phoneNumber.Append(rand.Next(7, 10));
            phoneNumber.Append("8");
            phoneNumber.Append(rand.Next(100000, 999999));
            return phoneNumber.ToString();
        }

		
		public static string GenerateCity()
		{
			return cityNames[rand.Next(0, cityNames.Length)];
		}

        public static Customer NextCustomer(ApplicationUser user = null)
        {
            var customer = new Customer();
            var sex = GenerateSex();
            var name = GenerateName(sex);
            customer.FirstName = name["first"];
            customer.LastName = name["last"];
            customer.PhoneNumber = GeneratePhoneNumber();
			customer.City = GenerateCity();
            customer.User = user;

            return customer;
        }
	}
}