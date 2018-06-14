using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MessageInterface
{
    
    public struct Connect
    {
        public byte length; // 0
        public byte messageType; // 1
        public byte flags; // 2
        public byte protocolId; // 3
        public byte[] duration; // 45
        public byte[] clientId; // 6n
    }

    public class ConnectWrk
    {
        public Connect connect;

        public ConnectWrk()
        {
            connect = new Connect();
            connect.length = 10;
            connect.messageType = Convert.ToByte("04", 16);
            connect.protocolId = Convert.ToByte("01", 16);
            connect.duration = new byte[] { 1,1};
        }

        public ConnectWrk(byte[] input)
        {
            this.connect = new Connect();

            connect.length = input[0];
            connect.messageType = input[1];
            connect.flags = input[2];
            connect.protocolId = input[3];
            connect.duration = new byte[2];
            connect.clientId = new byte[connect.length - 6];
            System.Buffer.BlockCopy(input, 4, connect.duration, 0, 2);
            System.Buffer.BlockCopy(input, 6, connect.clientId, 0, connect.length - 6);
        }

        public byte[] Serialized
        {
            get
            {
                byte[] messageFull = new byte[connect.length];
                messageFull[0] = connect.length;
                messageFull[1] = connect.messageType;
                messageFull[2] = connect.flags;
                messageFull[3] = connect.protocolId;
                System.Buffer.BlockCopy(connect.duration, 0, messageFull, 4, 2);
                System.Buffer.BlockCopy(connect.clientId, 0, messageFull, 6, connect.length - 6);

                return messageFull;
            }
        }
    }
}
