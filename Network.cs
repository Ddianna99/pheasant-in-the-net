using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fazan
{
    class Network
    {
        protected Socket connection;

        public void Send(string message)
        {
            byte[] msg = Encoding.ASCII.GetBytes(message);
            connection.Send(msg);
        }

        public string Recieve()
        {
            byte[] bytes = new byte[1024];
            int bytesRec = connection.Receive(bytes);

            return Encoding.ASCII.GetString(bytes, 0, bytesRec);
        }
    }
}
