using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MessageInterface
{
    public struct Suback
    {
        public byte length; // 0
        public byte messageType; // 1
        public byte flags; // 2
        public byte[] topicId; //34
        public byte[] messageId; // 56
        public byte ReturnCode; // 7
    }

    public class SubackWrk
    {
        public Suback suback;

        public SubackWrk()
        {
            this.suback = new Suback();
            suback.length = Convert.ToByte("08", 16);
            suback.messageType = Convert.ToByte("13", 16);
        }

        public SubackWrk(byte[] input)
        {
            this.suback = new Suback();

            suback.length = input[0];
            suback.messageType = input[1];
            suback.flags = input[2];
            suback.topicId = new byte[2];
            suback.messageId = new byte[2];
            System.Buffer.BlockCopy(input, 3, suback.topicId, 0, 2);
            System.Buffer.BlockCopy(input, 5, suback.messageId, 0, 2);
            suback.ReturnCode = input[7];
        }

        public byte[] Serialized
        {
            get
            {
                byte[] messageFull = new byte[suback.length];
                messageFull[0] = suback.length;
                messageFull[1] = suback.messageType;
                messageFull[2] = suback.flags;
                System.Buffer.BlockCopy(suback.topicId, 0, messageFull, 3, 2);
                System.Buffer.BlockCopy(suback.messageId, 0, messageFull, 5, 2);

                messageFull[7] = suback.ReturnCode;

                return messageFull;
            }
        }
    }
}
