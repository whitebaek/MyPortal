using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyPortal.Models
{
    public class EventModel : IEventModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public string Url { get; set; }
        public string Address { get; set; }
        //public decimal Latitude { get; set; }
        //public decimal Longitude { get; set; }

        [DisplayName("Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime StartDate { get; set; }

        [DisplayName("End Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime EndDate { get; set; }


        public double GetLatitude()
        {
            throw new NotImplementedException();
        }

        public double GetLongitude()
        {
            throw new NotImplementedException();
        }
    }
}