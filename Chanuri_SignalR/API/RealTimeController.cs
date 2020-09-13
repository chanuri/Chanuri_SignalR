using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chanuri_SignalR.hub;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Chanuri_SignalR.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealTimeController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hub;
        // GET: api/RealTime
        
       public RealTimeController(IHubContext<ChatHub> hub)
        {
            _hub = hub;
        }

        // POST: api/RealTime
        [HttpPost]
        public void Post(List<string> data)
        {
            foreach (var item in data)
            {
                _hub.Clients.All.SendAsync(item);
            }
            

        }

        // PUT: api/RealTime/5
       
    }
}
