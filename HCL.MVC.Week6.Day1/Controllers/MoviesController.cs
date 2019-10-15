using HCL.MVC.Week6.Day1.Models;
using HCL.MVC.Week6.Day1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace HCL.MVC.Week6.Day1.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private ApplicationDbContext dbContext = null;
        public MoviesController()
        {
            dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                dbContext.Dispose();
            }
        }
        // GET: Movies
        public ActionResult Index()
        {
            var c6 = dbContext.Movies.ToList();
            return View(c6);
        }
        public ActionResult SpecificDetails(int Id)
        {
            var c4 = dbContext.Movies.Include(m => m.Genre).ToList().SingleOrDefault(a => a.Id == Id);
            return View(c4);

            //normal way
            //CustomerC c4 = new CustomerC();
            //var c5 = GetCustomers();
            //foreach (var ob in c5)
            //{
            //    if(ob.Id==Id)
            //    {
            //        c4 = ob;
            //    }
            //}
            //return View(c4);

            //using linq with lambda

            //using linq
            //var customer = from res in GetCustomers()
            //         where res.Id == Id
            //         select res;
            //return View(customer);
        }
        //public List<MovieC> GetMovies()
        //{
        //    List<MovieC> c2 = new List<MovieC>
        //    {
        //        new MovieC{Id=1,Name="Maharshi",ReleaseDate=Convert.ToDateTime("10-05-2019"),AddDate=Convert.ToDateTime("01-10-2019")},
        //        new MovieC{Id=2,Name="Lights Out",ReleaseDate=Convert.ToDateTime("07-08-2017"),AddDate=Convert.ToDateTime("10-10-2017")}
        //    };
        //    return c2;
        //}
        //public ActionResult Display()
        //{
        //    CustomerMovieViewModel VM = new CustomerMovieViewModel();
        //    MovieC m = new MovieC { Name = "MAHARSHI" };
        //    List<CustomerC> customers = new List<CustomerC>
        //    {
        //        new CustomerC{CustomerName="JUNNU"},
        //        new CustomerC{CustomerName="LOLLIPOP"},
        //        new CustomerC{CustomerName="CHANDU"},
        //        new CustomerC{CustomerName="MOHAN"},
        //        new CustomerC{CustomerName="Madhuri"}
        //    };
        //    VM.Movie = m;
        //    VM.Customers = customers;
        //    return View(VM);
        //}
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.GenreId = ListGenre();
            return View();
        }

        [HttpPost]
        public ActionResult Create(MovieC movie)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.GenreId = ListGenre();
                return View(movie);
            }
            dbContext.Movies.Add(movie);  //insert option
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
        [NonAction]
        public IEnumerable<SelectListItem> ListGenre()
        {
            var Genre = (from m in dbContext.Genres.AsEnumerable()
                              select new SelectListItem
                              {
                                  Text = m.Name,
                                  Value = m.Id.ToString()
                              }).ToList();
            Genre.Insert(0, new SelectListItem { Text = "----Select-----", Value = "0", Disabled = true, Selected = true });
            return Genre;
        }
    }
}