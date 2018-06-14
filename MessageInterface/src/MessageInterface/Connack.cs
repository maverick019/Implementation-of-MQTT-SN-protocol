using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MessageInterface
{
    public struct Connack
    {
        public byte length; // 0
        public byte messageType; // 1
        public byte returnCode; // 2
    }

    public class ConnackWrk
    {
        public Connack connack;

        public ConnackWrk()
        {
            this.connack = new Connack();
            connack.length = Convert.ToByte("03", 16);
            connack.messageType = Convert.ToByte("05", 16);
        }

        public ConnackWrk(byte[] input)
        {
            this.connack = new Connack();

            connack.length = input[0];
            connack.messageType = input[1];
            connack.returnCode = input[2];
        }

        public byte[] Serialized
        {
            get
            {
                byte[] messageFull = new byte[connack.length];
                messageFull[0] = connack.length;
                messageFull[1] = connack.messageType;
                messageFull[2] = connack.returnCode;

                return messageFull;
            }
        }
    }
}
