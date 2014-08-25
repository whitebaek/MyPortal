using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPortal.Models
{
    public interface IEventModel
    {
        double GetLatitude();
        double GetLongitude();
    }
}