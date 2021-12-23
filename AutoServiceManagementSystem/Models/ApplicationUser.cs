using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AutoServiceManagementSystem.Models
{
	public class ApplicationUser : IdentityUser
	{
        public ApplicationUser()
        {
            UserDetails = new UserDetails();
        }

		public UserDetails UserDetails { get; set; }

		public virtual List<Customer> Customers { get; set; }

		public virtual List<Supplier> Suppliers { get; set; }

		// methods
		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
		{
			
			var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
			
			return userIdentity;
		}
	}
}