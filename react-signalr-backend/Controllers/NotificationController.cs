using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using react_signalr_backend.Hubs;

namespace react_signalr_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : ControllerBase
    {

        private readonly ILogger<NotificationController> _logger;
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationController(ILogger<NotificationController> logger, IHubContext<NotificationHub> hubContext)
        {
            _logger = logger;
            _hubContext = hubContext;
        }

        [HttpPost(Name = "TriggerNotification")]
        public async void Post()
        {
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", "This was sent from SignalR!");
        }
    }
}