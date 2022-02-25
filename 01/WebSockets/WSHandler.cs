using System;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using System.Web.WebSockets;

namespace WebSockets
{
    public class WSHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(WebSocketRequest);
            }
            else
            {
                context.Response.WriteFile("/html/WSClient.html");
            }
        }

        private async Task WebSocketRequest(AspNetWebSocketContext context)
        {
            while (context.WebSocket.State == WebSocketState.Open)
            {
                var msg = (DateTime.Now).ToString();
                await context.WebSocket.SendAsync(new ArraySegment<byte>(System.Text.Encoding.UTF8.GetBytes(msg)), WebSocketMessageType.Text, true, CancellationToken.None);
                Thread.Sleep(2000);
            }
        }
    }
}
