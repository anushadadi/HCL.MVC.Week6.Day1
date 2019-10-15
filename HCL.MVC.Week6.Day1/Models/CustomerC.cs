using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //to change the displaying names
using System.ComponentModel.DataAnnotations.Schema;//to change size of columns

namespace HCL.MVC.Week6.Day1.Models
{
    public class CustomerC
    {
        //Domain class or Model
        public int Id { get; set; }
        [Required]
        [Display(Name ="Customer Name")]
        [StringLength(10)]
        public string CustomerName { get; set; }

        
        [Display(Name="Date of Birth")]
        public DateTime? DOB { get; set; }

        [Required]
        [Column(TypeName ="char")]
        [StringLength(8)]

        public string Gender { get; set; }
        public string City { get; set; }

        //reference class
        public Membership_Type MemberShipType { get; set; }

        //reference table column
        [Required]
        public int? Membership_TypeId { get; set; }
    }
}