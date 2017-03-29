using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenithWebsite.Utility;
using ZenithWebsite.Data;
using ZenithWebsite.Models.ZenithModels;

namespace ZenithWebsite.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var firstdayOfThisWeek = DateTime.Now.FirstDayOfWeek();
            var lastdayOfThisWeek = DateTime.Now.LastDayOfWeek();

            var ActivityEventsList = from e in _db.Events
                                     join a in _db.Activities on e.ActivityId equals a.ActivityId
                                     where (e.StartDateTime >= firstdayOfThisWeek)
                                     && (e.StartDateTime < lastdayOfThisWeek)
                                     && (e.IsActive == true)
                                     orderby (e.CreatedTime)
                                     select new EventActivityModel { Event = e, Activity = a };

            return View(ActivityEventsList);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public class EventActivityModel
        {
            public Event Event { get; set; }
            public Activity Activity { get; set; }
        }
    }
}
