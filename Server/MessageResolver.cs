using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace TPUM.ServerPresentation
{
    public class MessageResolver
    {
        public MessageResolver(Action<string> log) 
        {
            Log = log;
        }

        public string Resolve(string message)
        {
            return "Can't process given message";
        }

        private Action<string> Log { get; }
    }
}
