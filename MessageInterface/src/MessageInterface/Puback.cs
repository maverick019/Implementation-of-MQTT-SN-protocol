using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MessageInterface
{
    public struct Puback
    {
        public byte length; // 0
        public byte messageType; // 1
        public byte[] topicId; //23
        public byte[] messageId; // 45
        public byte ReturnCode; // 6
    }

    public class PubackWrk
    {
        public Puback puback;

        public PubackWrk()
        {
            this.puback = new Puback();
            puback.length = Convert.ToByte("07", 16);
            puback.messageType = Convert.ToByte("0D", 16);
        }

        public PubackWrk(byte[] input)
        {
            this.puback = new Puback();

            puback.length = input[0];
            puback.messageType = input[1];
            puback.topicId = new byte[2];
            puback.messageId = new byte[2];
            System.Buffer.BlockCopy(input, 2, puback.topicId, 0, 2);
            System.Buffer.BlockCopy(input, 4, puback.messageId, 0, 2);
            puback.ReturnCode = input[6];
        }

        public byte[] Serialized
        {
            get
            {
                byte[] messageFull = new byte[puback.length];
                messageFull[0] = puback.length;
                messageFull[1] = puback.messageType;
                System.Buffer.BlockCopy(puback.topicId, 0, messageFull, 2, 2);
                System.Buffer.BlockCopy(puback.messageId, 0, messageFull, 4, 2);

                messageFull[6] = puback.ReturnCode;

                return messageFull;
            }
        }
    }
}
