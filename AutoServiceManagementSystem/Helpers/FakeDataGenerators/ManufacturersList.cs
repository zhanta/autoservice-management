using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoServiceManagementSystem.Helpers
{
	public static class ManufacturersList
	{
		private static List<string> _manufacturers = new List<string>()
		{
			"Audi", "Bentley", "BMW",
			"Cadillac", "Chevrolet",
			"Ferrari", "Hyundai",
			"Kia", "Lada", "Lamborghini", "Land Rover",
			"Lexus", "Mazda", "Mercedes",
			"Mitsubishi", "Nissan", "Peugeot", "Porsche",
			"Rolls Royce", "Subaru",
			"Tesla", "Toyota", "Volkswagen"
		};

		public static List<string> Manufacturers
		{
			get
			{
				return _manufacturers;
			}
			private set
			{
				_manufacturers = value;
			}
		}
	}
}