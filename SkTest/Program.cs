using SkUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SkTest
{
    class Program
    {
        static SkUtil.Network.SkServer server = new SkUtil.Network.SkServer();
        static SkUtil.Network.SkClient client= new SkUtil.Network.SkClient();

        static public byte[] Header = new byte[8];
        static public byte[] Data = new byte[8];
        static void Main(string[] args)
        {
            /*
            server.ServerStart();
            server.AddConnectClientEventHandler(new SkUtil.Network.SocketServer.ConnetEventHandler(Server_ConnetClient));
            server.AddReceiveEventHandler(new SkUtil.Network.SocketServer.ReceiveEventHandler(ReceiveEventHandler));*/
            client.ClientStart();
            client.AddReceiveDataEventHandler(new SkUtil.Network.SocketClient.ReceiveDataEventHandler(Client_ReceiveData));
            while (true)
            {
                Thread.Sleep(1000);
            }
        }
        static public void Client_ReceiveData(NetworkStream ClientStream)
        {
            if(!Client_ReceiveData(ClientStream, Header))
            {
                return;
            }
            if(CT_Converter.ByteToInt32(Header, 0) != 1234567890)
            {
                return;
            }
            if (CT_Converter.ByteToInt32(Header, 4) != 16)
            {
                return;
            }
            if (!Client_ReceiveData(ClientStream, Data))
            {
                return;
            }
            int key = CT_Converter.ByteToInt32(Data, 0);

        }
        static public bool Client_ReceiveData(NetworkStream ClientStream, byte[] buffer)
        {
            return ClientStream.Read(buffer, 0, (int)buffer.Length) == buffer.Length;
        }
        static void ReceiveEventHandler(string ClientIP, int ClientPort, string ClientID, byte[] data)
        {
            int dfd = 0;
        }
        static void Server_ConnetClient(string ClientIP, int ClientPort, string ClientID)
        {
            Console.WriteLine("ConnetClient IP : " + ClientIP + " Port : " + ClientPort.ToString() + " ID : " + ClientID);
        }
    }
}
