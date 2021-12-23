using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoServiceManagementSystem.Models;
using Newtonsoft.Json;

namespace AutoServiceManagementSystem.Helpers
{
    public static class CarSeeder
	{
		#region Private Fields
		private static Random rand = new Random();

        // Imaginary car model names used for testing.
        private static readonly string[] modelNames = 
        {
            "Lightning", "Blaze", "Elegance", "Flash", "Sports", "Winner", "Leader", "Magnum",
            "Jupiter", "Le Incredibile", "RTX 50", "Devil", "Daemon", "Femili", "Excellence",
            "Street", "Beauty", "Dragon", "Tornado", "Typhoon"
        };

        // Bulgarian region codes used in Plate Numbers. 
        // They represent the area where the vehicle was registered.
        private static readonly string[] regionCodes = 
        {
            "Е", "А", "В", "ВТ", "ВН", "ВР", "ЕВ", "ТХ", "К", "КН", "ОВ", "М", "РА", "РК",
            "ЕН", "РВ", "РР", "Р", "СС", "СН", "СМ", "СО", "С", "СА", "СВ", "Т", "Х", "Х", "У"
        };

        // World Manufacturer Identificators - the first three digits in a VIN code.
        // They give information about the country of origin and the manufacturer.
        // Note: Some manufacturers have factories in more than one country and
        // some WMIs have changed through the years. In a more realistic scenario
        // each manufacturer must have a list of WMIs.
        private static readonly Dictionary<string, string> worldManufacturerIds = new Dictionary<string, string>() 
        {
            {"Acura", "19U"}, {"Audi", "WAU"}, {"Alfa Romeo", "ZAR"}, {"Aston Martin", "SCF"}, {"Bentley", "SCB"},
            {"BMW", "WBA"},{"Bugatti", "ZA9"}, {"Cadillac", "1G6"}, {"Chevrolet", "1G1"}, {"Chrysler", "1A8"},
            {"Citroen", "VF7"}, {"Dacia", "UU1"}, {"Datsun", "JN1"}, {"Dodge", "1B7"}, {"Daewoo", "KLA"},
            {"Daihatsu", "JD1"}, {"Ferrari", "ZFF"}, {"Fiat", "ZFA"}, {"Honda", "JHM"}, {"Hummer", "5GT"},
            {"Hyundai", "KM8"}, {"Infiniti", "JNK"}, {"Isuzu", "4KL"}, {"Iveco", "ZCF"}, {"Jaguar", "SAJ"},
            {"Jeep", "1J4"}, {"Kia", "KNA"}, {"Lada", "XTA"}, {"Lamborghini", "ZA9"}, {"Land Rover", "SAL"},
            {"Lexus", "JT6"}, {"Lincoln", "1LN"}, {"Lotus", "SCC"}, {"Maserati", "ZAM"}, {"Maybach", "WDB"},
            {"Mazda", "JM1"}, {"Mercedes", "WDB"}, {"Mini", "WMW"}, {"Mitsubishi", "JA3"},{"Nissan", "JN3"},
            {"Opel", "W0L"}, {"Peugeot", "VF3"}, {"Pontiac", "1G2"}, {"Porsche", "WP0"}, {"Ram", "3B4"},
            {"Renault", "VF1"}, {"Rolls Royce", "SCA"}, {"SAAB", "YS3"}, {"Scion", "JTK"}, {"Seat", "VSS"},
            {"Shelby", "SFM"}, {"Skoda", "TMB"}, {"Smart", "WME"}, {"Subaru", "JF1"}, {"Suzuki", "JS2"}, 
            {"Tesla", "5YJ"}, {"Toyota", "JT2"}, {"Volkswagen", "WVW"}, {"Volvo", "YV1"}, {"Vauxhall", "VN1"}
        };

        // In a VIN code the 10th digit represents the year of manufacturing.
        private static readonly Dictionary<char, int> charToYear = new Dictionary<char, int>()
        {
            {'L', 1990}, {'M', 1991}, {'N', 1992}, {'P', 1993}, {'R', 1994}, {'S', 1995}, {'T', 1996},
            {'V', 1997}, {'W', 1998}, {'X', 1999}, {'Y', 2000}, {'A', 2010}, {'1', 2001}, {'2', 2002},
            {'3', 2003}, {'4', 2004}, {'5', 2005}, {'6', 2006}, {'7', 2007}, {'8', 2008}, {'9', 2009},
            {'B', 2011}, {'C', 2012}, {'D', 2013}, {'E', 2014}, {'F', 2015}, {'G', 2016}, {'H', 2017},
            {'J', 2018}, {'K', 2018}
        };
		#endregion

		
        public static string GenerateManufacturer()
        {
            string[] manufacturers = ManufacturersList.Manufacturers.ToArray();
            string result = manufacturers[rand.Next(0, manufacturers.Length)];

            return result;
        }

        
        public static string GenerateModel()
        {
            string result = modelNames[rand.Next(0, modelNames.Length)];
            return result;
        }

		
		public static string GenerateModel(string manufacturer)
		{
			throw new NotImplementedException();
		}

        
        public static string GeneratePlateNumber()
        {
            string[] allowedCharacters = { "А", "В", "Е", "К", "М", "Н", "О", "Р", "С", "Т", "У", "Х" };
            var plateNumber = new StringBuilder();
            plateNumber.Append(regionCodes[rand.Next(0, regionCodes.Length)]);
            plateNumber.Append(" ");
            plateNumber.Append(rand.Next(1000, 9999));
            plateNumber.Append(" ");
            plateNumber.Append(
                allowedCharacters[rand.Next(0, allowedCharacters.Length)]);
            plateNumber.Append(
                allowedCharacters[rand.Next(0, allowedCharacters.Length)]);

            return plateNumber.ToString();
        }

      
        public static string GenerateEngineCode()
        {
            var engineCode = new StringBuilder();

            for (int i = 0; i < 4; i++)
            {
                // get the ASCII code [65->90 = (A-Z)]
                char letter = (char)rand.Next(65, 91);
                engineCode.Append(letter);
            }

            return engineCode.ToString();
        }

      
        public static string GenerateVinCode(string manufacturer)
        {
            string allowedChars = "ABCDEFGHJKLMNPRSTUVWXYZ1234567890";
            var vin = new StringBuilder();

            
            vin.Append(worldManufacturerIds[manufacturer]);

            
            for (int i = 0; i < 5; i++)
            {
                vin.Append(
                     allowedChars[rand.Next(0, allowedChars.Length)]);
            }

            vin.Append(Convert.ToChar("0"));

            
            char modelYearDigit = '0';
            while (modelYearDigit == '0' || modelYearDigit == 'U'
                || modelYearDigit == 'Z')
            {
                modelYearDigit = allowedChars[rand.Next(0, allowedChars.Length)];
            }
            vin.Append(modelYearDigit);

            
            for (int i = 0; i < 7; i++)
            {
                string digits = "0123456789";
                vin.Append(digits[rand.Next(0, digits.Length)]);
            }

            return vin.ToString();
        }

		public static Fuel GenerateFuelType()
		{
			switch (rand.Next(0, 3))
			{
				case 0:
					return Fuel.Diesel;
				case 1:
					return Fuel.Gas;
				case 2:
					return Fuel.Petrol;
                case 3:
                    return Fuel.Electric;
				default:
					return Fuel.Petrol;
			}
		}

        public static int GetYear(string vin)
        {
            return charToYear[vin[9]];
        }

		
        public static Car NextCar(ApplicationUser user = null, Customer owner = null)
        {
            var car = new Car();
            car.Manufacturer = GenerateManufacturer();
            car.Model = GenerateModel();
            car.VIN = GenerateVinCode(car.Manufacturer);
            car.PlateCode = GeneratePlateNumber();
            car.Year = GetYear(car.VIN);
            car.EngineCode = GenerateEngineCode();
			car.FuelType = GenerateFuelType();
			car.Jobs = new List<Job>();
            car.User = user;
            car.Customer = owner;

            return car;
        }
    }
}