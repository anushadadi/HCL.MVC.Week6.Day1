using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HCL.MVC.Week6.Day1.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        [Required]
        [StringLength(100)]
        //[Display(Name = "First Name")]
        [Column(TypeName ="Varchar")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        //[Display(Name = "Last Name")]
        [Column(TypeName = "Varchar")]
        public string LastName { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>     //dbcontext represents database
    {
        public ApplicationDbContext()
            : base("MVCCon", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<CustomerC> Customers{ get; set; }  //dbset represents table
        public DbSet<MovieC> Movies{ get; set; }
        public DbSet<Membership_Type> MemberShipTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }


    }
}