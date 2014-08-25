using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPortal.Models
{
    public abstract class EventWithLocation : IEventModel
    {
        private EventModel _eventModel;

        public EventWithLocation(EventModel eventModel)
        {
            _eventModel = eventModel;
        }


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