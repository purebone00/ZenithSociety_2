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
    public class EventsRestfulController : Controller
    {
        private ApplicationDbContext _context;

        public EventsRestfulController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _context.Events.ToList();
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
