using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenithWebsite.Data;
using ZenithWebsite.Models.ZenithModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ZenithWebsite.Controllers
{
    [Route("api/[controller]")]
    public class ActivitiesRestfulController : Controller
    {
        private ApplicationDbContext _context;

        public ActivitiesRestfulController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Activity> Get()
        {
            return _context.Activities.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Activity Get(int id)
        {
            return _context.Activities.FirstOrDefault(a => a.ActivityId == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Activity activity)
        {
            _context.Activities.Add(activity);
            _context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Activity activity)
        {
            _context.Activities.Update(activity);
            _context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var activity = _context.Activities.FirstOrDefault(a => a.ActivityId == id);
            if (activity != null)
            {
                _context.Activities.Remove(activity);
                _context.SaveChanges();
            }
        }
    }
}
