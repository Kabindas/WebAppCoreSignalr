using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCoreSignalr.Hubs;

namespace WebAppCoreSignalr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly IHubContext<ChatHub> _hubContext;

        public ValuesController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet]
        [Route("SetValues")]
        public IActionResult SetValues(string name, string value)
        {
            _hubContext.Clients.All.SendAsync("ReceiveMessage", name, value);
            return Ok();
        }
    }
}
