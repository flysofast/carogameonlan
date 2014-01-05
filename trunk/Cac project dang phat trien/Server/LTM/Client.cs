using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LTM
{
      class Client
    {
        public string Nick { get; set; }

        public string IP { get; set; }

        public Socket socket { get; set; }
    }
}
