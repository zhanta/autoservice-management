using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoServiceManagementSystem.Validation
{
	public class PhoneNumberAttribute : ValidationAttribute
	{
		public PhoneNumberAttribute()
			: base("Valid phone numbers follow this pattern: 87XXXXXXXXX")
		{

		}

		/// <summary>
		/// Checks if a phone number is a valid one.
		///  11 digits
		/// </summary>
		/// <param name="value">Input phone number.</param>
		/// <param name="validationContext">Describes the context in which the validation check is done.</param>
		/// <returns>Success or ErrorMesage</returns>
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value != null)
			{
				string s = value.ToString();
				bool valid = true;

				if (s.StartsWith("87") && s.Length == 10)
				{
					foreach (char c in s)
					{
						if (!Char.IsDigit(c))
						{
							valid = false;
							break;
						}
					}
				}
				else
				{
					valid = false;
				}

				if(!valid)
				{
					var errorMessage = FormatErrorMessage(validationContext.DisplayName);
					return new ValidationResult(errorMessage);
				}

			}
			return ValidationResult.Success;
		}
	}
}