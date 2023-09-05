namespace Server.API.Controllers
{
    #region Usings
    using Contracts;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;
    using Server.API.Hubs;
    #endregion

    #region ChatController
    [ApiController]
    public class ChatController : ControllerBase
    {
        #region Private : Fields
        private readonly IHubContext<Chat, IChat> _hubContext;
        #endregion
        
        #region Public : Constructor
        public ChatController(IHubContext<Chat, IChat> hubContext)
        {
            _hubContext = hubContext;
        }
        #endregion

        #region API methods
        [HttpPost]
        [Route("send-message")]
        public async Task<IActionResult> SendMessage(string username, string message)
        {
            await _hubContext.Clients.All.ReceiveMessage(username, message);
            return Ok();
        }
        #endregion
    }
    #endregion
}