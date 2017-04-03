using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ZenithWebsite.Data;
using ZenithWebsite.Models.ZenithModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ZenithWebsite.Controllers
{

    [Route("api/[controller]")]
    [Produces("application/json")]
    public class EventsRestfulController : Controller
    {
        private ApplicationDbContext _context;

        public EventsRestfulController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var EventList = from e in _context.Events
                            join a in _context.Activities on e.ActivityId equals a.ActivityId
                            select new { e.EventId, e.EventDate, e.StartDateTime, e.CreatedTime, e.EnteredBy, e.EndDateTime, e.ActivityId, e.IsActive, a.ActivityDescription};
            return Json(EventList);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Event Get(int id)
        {
            return _context.Events.FirstOrDefault(a => a.EventId == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Event eve)
        {
            _context.Events.Add(eve);
            _context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Event eve)
        {
            _context.Events.Update(eve);
            _context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var eve = _context.Events.FirstOrDefault(e => e.EventId == id);
            if (eve != null)
            {
                _context.Events.Remove(eve);
                _context.SaveChanges();
            }
        }
    }
}
