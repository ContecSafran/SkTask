using SkUtil;
using SkUtil.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Action.Network
{
    public class TaskServer : SkServer
    {
        public byte[] packetBuffer = new byte[16]
        {   0x49, 0x96, 0x02, 0xD2,
            0x00, 0x00, 0x00, 0x10,
            0x00, 0x00, 0x00, 0x00,
            0xB6, 0x69, 0xFD, 0x2E};
        public TaskServer() : base()
        {

        }
        public void SendCommand(int index)
        {
            CT_Converter.Int32ToByte(index, ref packetBuffer, 4 * 2);
            this.Send(packetBuffer);
        }
    }
}
