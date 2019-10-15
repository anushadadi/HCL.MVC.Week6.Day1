using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HCL.MVC.Week6.Day1.Models
{
    public class MovieC
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Enter Name" )]
        [Display(Name="Movie Name")]
        public string Name { get; set; }
       // public string Genre { get; set; }

       [Required]
        [Display(Name="Released Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        public DateTime ?AddDate { get; set; }

       
        public int AvailableStock { get; set; }

        //reference table
        public Genre Genre { get; set; }

        [Required]
        [Display(Name ="Genre")]
        //reference table column
        public int? GenreId { get; set; }
    }
}