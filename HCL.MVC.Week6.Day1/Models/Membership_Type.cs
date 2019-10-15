using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCL.MVC.Week6.Day1.Models
{
    public class Membership_Type
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short Duration { get; set; }
        public double SignupFee { get; set; }
        public short Discount { get; set; }
    }
}