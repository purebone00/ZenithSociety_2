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
                    CreationDate = new DateTime(2017, 03, 01, 08, 30, 00)
                });

                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Leadership General Assembly Meeting",
                    CreationDate = new DateTime(2017, 03, 02, 08, 30, 00)
                });

                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Youth Bowling Tournament",
                    CreationDate = new DateTime(2017, 03, 03, 08, 30, 00)
                });
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Young ladies cooking lessons",
                    CreationDate = new DateTime(2017, 03, 04, 08, 30, 00)
                });
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Youth craft lessons",
                    CreationDate = new DateTime(2017, 03, 05, 08, 30, 00)
                });
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Youth choir practice",
                    CreationDate = new DateTime(2017, 03, 05, 08, 30, 00)
                });
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Lunch",
                    CreationDate = new DateTime(2017, 03, 05, 08, 30, 00)
                });
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Pancake Breakfast",
                    CreationDate = new DateTime(2017, 03, 06, 08, 30, 00)
                });
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Swimming Lessons for the youth",
                    CreationDate = new DateTime(2017, 03, 06, 09, 30, 00)
                });
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Swimming Exercise for parents",
                    CreationDate = new DateTime(2017, 03, 06, 10, 30, 00)
                });
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Bingo Tournament",
                    CreationDate = new DateTime(2017, 03, 06, 11, 30, 00)
                });
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "BBQ Lunch",
                    CreationDate = new DateTime(2017, 03, 06, 12, 30, 00)
                });
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Garage Sale",
                    CreationDate = new DateTime(2017, 03, 06, 13, 30, 00)
                });
            }

            if(!db.Events.Any())
            {
                db.Events.Add(new Event()
                {
                    StartDateTime = new DateTime(2017, 03, 28, 08, 30, 00),
                    EndDateTime = new DateTime(2017, 03, 28, 10, 30, 00),
                    ActivityId = db.Activities.FirstOrDefault(f => f.ActivityDescription == "Senior's Golf Tournament").ActivityId,
                    EnteredBy = "a",
                    CreatedTime = new DateTime(2017, 02, 01, 08, 30, 00),
                    IsActive = true
                });

                db.Events.Add(new Event()
                {
                    StartDateTime = new DateTime(2017, 03, 28, 10, 30, 00),
                    EndDateTime = new DateTime(2017, 03, 28, 12, 30, 00),
                    ActivityId = db.Activities.FirstOrDefault(f => f.ActivityDescription == "Leadership General Assembly Meeting").ActivityId,
                    EnteredBy = "a",
                    CreatedTime = new DateTime(2017, 03, 12, 08, 30, 00),
                    IsActive = true
                });

                db.Events.Add(new Event()
                {
                    StartDateTime = new DateTime(2017, 03, 27, 17, 30, 00),
                    EndDateTime = new DateTime(2017, 03, 27, 19, 15, 00),
                    ActivityId = db.Activities.FirstOrDefault(f => f.ActivityDescription == "Youth Bowling Tournament").ActivityId,
                    EnteredBy = "a",
                    CreatedTime = new DateTime(2017, 03, 13, 08, 30, 00),
                    IsActive = true
                });

                db.Events.Add(new Event()
                {
                    StartDateTime = new DateTime(2017, 03, 29, 19, 00, 00),
                    EndDateTime = new DateTime(2017, 03, 29, 20, 00, 00),
                    ActivityId = db.Activities.FirstOrDefault(f => f.ActivityDescription == "Young ladies cooking lessons").ActivityId,
                    EnteredBy = "a",
                    CreatedTime = new DateTime(2017, 03, 29, 08, 30, 00),
                    IsActive = true
                });

                db.Events.Add(new Event()
                {
                    StartDateTime = new DateTime(2017, 03, 30, 08, 30, 00),
                    EndDateTime = new DateTime(2017, 03, 30, 10, 30, 00),
                    ActivityId = db.Activities.FirstOrDefault(f => f.ActivityDescription == "Youth craft lessons").ActivityId,
                    EnteredBy = "a",
                    CreatedTime = new DateTime(2017, 03, 15, 08, 30, 00),
                    IsActive = true
                });

                db.Events.Add(new Event()
                {
                    StartDateTime = new DateTime(2017, 03, 30, 10, 30, 00),
                    EndDateTime = new DateTime(2017, 03, 30, 12, 00, 00),
                    ActivityId = db.Activities.FirstOrDefault(f => f.ActivityDescription == "Youth choir practice").ActivityId,
                    EnteredBy = "a",
                    CreatedTime = new DateTime(2017, 03, 16, 08, 30, 00),
                    IsActive = true
                });

                db.Events.Add(new Event()
                {
                    StartDateTime = new DateTime(2017, 03, 27, 12, 00, 00),
                    EndDateTime = new DateTime(2017, 03, 27, 12, 30, 00),
                    ActivityId = db.Activities.FirstOrDefault(f => f.ActivityDescription == "Lunch").ActivityId,
                    EnteredBy = "a",
                    CreatedTime = new DateTime(2017, 03, 11, 08, 30, 00),
                    IsActive = true
                });

                db.Events.Add(new Event()
                {
                    StartDateTime = new DateTime(2017, 03, 30, 07, 30, 00),
                    EndDateTime = new DateTime(2017, 03, 30, 08, 30, 00),
                    ActivityId = db.Activities.FirstOrDefault(f => f.ActivityDescription == "Youth choir practice").ActivityId,
                    EnteredBy = "a",
                    CreatedTime = new DateTime(2017, 03, 30, 08, 30, 00),
                    IsActive = true
                });
            }
        }
    }
}
