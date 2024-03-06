using SkUtil;
using SkUtil.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Follow
{
    class FollowClient : SkClient
    {
        public byte[] Header = new byte[8];
        public byte[] Data = new byte[8];
        public override void ClientStart(bool ClientType = true)
        {
            base.ClientStart();
        }

        public override void Client_ReceiveData(NetworkStream ClientStream)
        {
            if (!Client_ReceiveData(ClientStream, Header))
            {
                return;
            }
            if (CT_Converter.ByteToInt32(Header, 0) != 1234567890)
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
        public bool Client_ReceiveData(NetworkStream ClientStream, byte[] buffer)
        {
            return ClientStream.Read(buffer, 0, (int)buffer.Length) == buffer.Length;
        }
    }
}
