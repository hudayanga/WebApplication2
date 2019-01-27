using Microsoft.Bot.Builder.Calling;
using Microsoft.Bot.Connector;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication2.Voice;

namespace WebApplication2.Controllers
{
    public class CallingController : ApiController
    {
        public CallingController() : base()
        {
            CallingConversation.RegisterCallingBot(callingBotService => new DemoCallingBot(callingBotService));
        }

        [Route("callback")]
        public async Task<HttpResponseMessage> ProcessCallingEventAsync()
        {
            return await CallingConversation.SendAsync(this.Request, CallRequestType.CallingEvent);
        }

        [Route("call")]
        public async Task<HttpResponseMessage> ProcessIncomingCallAsync()
        {
            return await CallingConversation.SendAsync(this.Request, CallRequestType.IncomingCall);
        }
    }
}
