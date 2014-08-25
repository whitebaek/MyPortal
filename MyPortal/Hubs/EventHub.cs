using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace MyPortal.Hubs
{
    public class EventHub : Hub
    {
        public void sendEventInformation()
        {
            Clients.All.broadcastEvent();
        }
    }
}