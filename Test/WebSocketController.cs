using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace TPUM.ClientData
{
    public class WebSocketController
    {
        public ClientWebSocketConnection _clientWebSocket;
        public Action<string> _connectionLogger;

        string _result = "";
        bool _parseResult = false;

        public WebSocketController()
        {
            _connectionLogger = message => _result = message;
        }

        public async Task<bool> Connect(Uri peer)
        {
            await WebSocketClient.Connect(peer, _connectionLogger);
            _clientWebSocket = (ClientWebSocketConnection)WebSocketClient._connectionSocket;
            _clientWebSocket.onMessage = message => OnInvokeMessage(message);
            return true;
        }

        public async Task<bool> SendTask(string newTask)
        {
            await _clientWebSocket.SendTask(newTask);
            _parseResult = true;
            return true;
        }

        private void OnInvokeMessage(string message)
        {
            if (_parseResult)
            {
                ParseMessege(message);
                _parseResult = false;
            }

            _result = message;
        }

        private void ParseMessege(string message)
        {
            MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(message));


            memoryStream.Close();
        }
    }
}
