using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TPUM.ClientData;

namespace Logic.Systems
{
    public class ConnectionSystem
    {
        public ClientWebSocketConnection _clientWebSocket;
        public Action<string> _connectionLogger;
        public WebSocketController socketController;
        private Uri _Uri;

        public ConnectionSystem()
        {
            socketController = new WebSocketController();
        }

        public ConnectionSystem(string uri)
        {
            socketController = new WebSocketController();
            _Uri = new Uri(uri);
        }

        public async Task<bool> CreateConnection()
        {
            await socketController.Connect(_Uri);
            return true;
        }

        public async Task<bool> SendTask(string newTask)
        {
            await socketController.SendTask(newTask);
            return true;
        }

        public ClientWebSocketConnection GetClientWebSocket()
        {
            return socketController._clientWebSocket;
        }
    }
}
