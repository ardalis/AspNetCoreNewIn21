using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace WhatsNewIn21
{

    public class UsersHub : Hub
    {
        public async Task SendSignIn(string userName)
        {
            await Clients.Others.SendAsync("ReceiveSignIn", userName);
        }
    }
}
