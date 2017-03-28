using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenithWebsite.Data;
using ZenithWebsite.Models.ZenithModels;

namespace ZenithWebsite.Models
{
    public class DummyData
    {
        public static void Initialize(ApplicationDbContext db)
        {
            if (!db.Activities.Any())
            {
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Senior's Golf Tournament",
                    CreationDate = new DateTime(2017, 04, 01, 08, 30, 00)
                });
            }
        }
    }
}
