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
    public class CustomerController : Controller
    {

        private ApplicationDbContext dbContext = null;
        public CustomerController()
        {
            dbContext = new ApplicationDbContext(); 
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
        }
        // GET: Customer
        [AllowAnonymous]
        public ActionResult Index()
        {
            var c3 = dbContext.Customers.Include(z => z.MemberShipType).ToList();
            return View("IndexDiff", c3);
        }
        public ActionResult SpecificDetails(int Id)
        {
            var c4 = dbContext.Customers.ToList().SingleOrDefault(a => a.Id == Id);
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
        public List<CustomerC> GetCustomers()
        {
            List<CustomerC> c2 = new List<CustomerC>
            {
                new CustomerC{Id=1,CustomerName="Poorna",DOB=Convert.ToDateTime("18-07-2019"),Gender="male"},
                new CustomerC{Id=2,CustomerName="Paddu",DOB=Convert.ToDateTime("28-10-2015"),Gender="Female"},
                new CustomerC{Id=3,CustomerName="Navya",DOB=Convert.ToDateTime("13-08-1998"),Gender="Female"},
                new CustomerC{Id=4,CustomerName="Anu",DOB=Convert.ToDateTime("20-01-1995"),Gender="Female"},
                new CustomerC{Id=5,CustomerName="Manu",DOB=Convert.ToDateTime("02-04-1993"),Gender="male"}
            };
            return c2;
        }
        public ActionResult CustomerDisplay()
        {
            MovieCustomer1ViewModel VMC = new MovieCustomer1ViewModel();
            CustomerC c1 = new CustomerC { CustomerName = "Janu" };
            List<MovieC> m1 = new List<MovieC>
            {
                new MovieC{Name="Maharshi"},
                new MovieC{Name="Bharat Ane Nenu"},
                new MovieC{Name="Busines Man"},
                new MovieC{Name="One"}
            };
            VMC.customer = c1;
            VMC.movies = m1;
            return View(VMC);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var customer = new CustomerC();

            ViewBag.Gender = ListGender();
            ViewBag.Membership_TypeId = ListMembership();
            return View(customer);
        }

        [HttpPost]
        
        public ActionResult Create(CustomerC CustomerfromView)
        {
           
            if (!ModelState.IsValid)
            {
                ViewBag.Gender = ListGender();
                ViewBag.Membership_TypeId = ListMembership();
                return View(CustomerfromView);
            }
            dbContext.Customers.Add(CustomerfromView); //insert option
            dbContext.SaveChanges();//update to database
            return RedirectToAction("Index", "Customer");
        }
        public ActionResult EditCustomer()
        {
            var customer = new CustomerC();
            return View(customer);
        }
        [HttpGet]
        public ActionResult EditCustomer(int Id)
        {
            var customer = dbContext.Customers.SingleOrDefault(c => c.Id == Id);
            if (customer != null)
            {
                ViewBag.Gender = ListGender();
                ViewBag.Membership_TypeId = ListMembership();
                return View(customer);
            }
            else
            return HttpNotFound("Customer Not Found");
        }
        [HttpPost]
        public ActionResult EditCustomer(CustomerC customerfromView)
        {
            if(ModelState.IsValid)
            {
                var Custindb = dbContext.Customers.FirstOrDefault(c => c.Id == customerfromView.Id);
                Custindb.CustomerName = customerfromView.CustomerName;
                Custindb.City = customerfromView.City;
                Custindb.Gender = customerfromView.Gender;
                Custindb.DOB = customerfromView.DOB;
                Custindb.Membership_TypeId = customerfromView.Membership_TypeId;
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                ViewBag.Gender = ListGender();
                ViewBag.Membership_TypeId = ListMembership();
                return View(customerfromView);
            }
        }

        [HttpGet]
        public ActionResult DeleteCustomer(int Id)
        {
            var customer = dbContext.Customers.SingleOrDefault(c => c.Id == Id);
            if (customer != null)
            {
                ViewBag.Gender = ListGender();
                ViewBag.Membership_TypeId = ListMembership();
                return View(customer);
            }
            else
                return HttpNotFound("Customer Not Found");
        }
        [HttpPost]
        public ActionResult DeleteCustomer(CustomerC customerfromView)
        {
           
                var Custindb = dbContext.Customers.FirstOrDefault(c => c.Id == customerfromView.Id);
                dbContext.Customers.Remove(Custindb);
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Customer");
           
        }
        [NonAction]
        public IEnumerable<SelectListItem> ListGender()
        {
            var gender = new List<SelectListItem>
            {
                new SelectListItem{Text="Select Gender",Value="0",Disabled=true,Selected=true},
                new SelectListItem{Text="Male",Value="1"},
                new SelectListItem{Text="Female",Value="2"},
                new SelectListItem{Text="Others",Value="3"}
            };
            return gender;
        }

        [NonAction]
        public IEnumerable<SelectListItem> ListMembership()
        {
            var membership = (from m in dbContext.MemberShipTypes.AsEnumerable()
                              select new SelectListItem
                              {
                                  Text = m.Name,
                                  Value = m.Id.ToString()
                              }).ToList();
            membership.Insert(0, new SelectListItem { Text = "----Select-----", Value = "0" ,Disabled=true,Selected=true});
            return membership;
        }

    }
}