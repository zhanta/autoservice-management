using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoServiceManagementSystem.Validation
{
	public class VinAttribute : ValidationAttribute
	{
		public VinAttribute()
			: base("Invalid VIN code.")
		{

		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value != null)
			{
				string vin = value.ToString().ToUpper();
				
			}
			return ValidationResult.Success;
		}
	}
}