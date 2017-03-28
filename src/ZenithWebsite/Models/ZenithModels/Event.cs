using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZenithWebsite.Models.ZenithModels
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        [Display(Name = "Event Date (YYYY-MM-DD)")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EventDate { get; set; }

        [Display(Name = "Start Date (YYYY-MM-DD HH:MM)")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartDateTime { get; set; }

        [Display(Name = "End Date (YYYY-MM-DD HH:MM)")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndDateTime { get; set; }

        [Display(Name = "Entered By")]
        public string EnteredBy { get; set; }

        [Display(Name = "Created Time (YYYY-MM-DD HH:MM)")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime CreatedTime { get; set; }

        [Display(Name = "Active Status")]
        public bool IsActive { get; set; }

        public int ActivityId { get; set; }

        public Activity Activity { get; set; }
    }
}
