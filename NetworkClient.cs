using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Fazan
{
    class NetworkClient : Network
    {
        public NetworkClient()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 42070);

            connection = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            try
            {
                connection.Connect(remoteEP);
            }
            catch (Exception e)
            {
                MessageBox.Show("Connection error");
            }
        }
    }
}
