using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MessageInterface
{
    public struct Regack
    {
        public byte length; // 0
        public byte messageType; // 1
        public byte[] topicId; //23
        public byte[] messageId; // 45
        public byte ReturnCode; // 6
    }

    public class RegackWrk
    {
        public Regack regack;

        public RegackWrk()
        {
            this.regack = new Regack();
            regack.length = Convert.ToByte("07", 16);
            regack.messageType = Convert.ToByte("0B", 16);
        }

        public RegackWrk(byte[] input)
        {
            this.regack = new Regack();

            regack.length = input[0];
            regack.messageType = input[1];
            regack.topicId = new byte[2];
            regack.messageId = new byte[2];
            System.Buffer.BlockCopy(input, 2, regack.topicId, 0, 2);
            System.Buffer.BlockCopy(input, 4, regack.messageId, 0, 2);
            regack.ReturnCode = input[6];
        }

        public byte[] Serialized
        {
            get
            {
                byte[] messageFull = new byte[regack.length];
                messageFull[0] = regack.length;
                messageFull[1] = regack.messageType;
                System.Buffer.BlockCopy(regack.topicId, 0, messageFull, 2, 2);
                System.Buffer.BlockCopy(regack.messageId, 0, messageFull, 4, 2);

                messageFull[6] = regack.ReturnCode;

                return messageFull;
            }
        }
    }
}
