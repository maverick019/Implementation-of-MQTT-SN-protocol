using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MessageInterface
{
    public struct Subscribe
    {
        public byte length; //0
        public byte messageType; // 1
        public byte flags; // 2
        public byte[] messageId; //34
        public byte[] topicId; //56
    }

    public class SubscribeWrk
    {
        public Subscribe subscribe;

        public SubscribeWrk()
        {
            subscribe = new Subscribe();
            subscribe.length = 7;
            subscribe.messageType = Convert.ToByte("12", 16);
        }

        public SubscribeWrk(byte[] input)
        {
            this.subscribe = new Subscribe();

            subscribe.length = input[0];
            subscribe.messageType = input[1];
            subscribe.flags = input[2];
            subscribe.topicId = new byte[2];
            subscribe.messageId = new byte[2];
            System.Buffer.BlockCopy(input, 3, subscribe.messageId, 0, 2);
            System.Buffer.BlockCopy(input, 5, subscribe.topicId, 0, 2);
        }

        public byte[] Serialized
        {
            get
            {
                byte[] messageFull = new byte[subscribe.length];
                messageFull[0] = subscribe.length;
                messageFull[1] = subscribe.messageType;
                messageFull[2] = subscribe.flags;
                System.Buffer.BlockCopy(subscribe.messageId, 0, messageFull, 3, 2);
                System.Buffer.BlockCopy(subscribe.topicId, 0, messageFull, 5, 2);

                return messageFull;
            }
        }
    }
}

