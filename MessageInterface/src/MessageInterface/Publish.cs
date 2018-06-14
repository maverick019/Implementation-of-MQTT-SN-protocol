using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MessageInterface
{
    public struct Publish
    {
        public byte length; //0
        public byte messageType; // 1
        public byte flags; // 2
        public byte[] topicId; // 34
        public byte[] messageId; // 56
        public byte[] data; // 7n
    }

    public class PublishWrk
    {
        public Publish publish;

        public PublishWrk()
        {
            publish = new Publish();
            publish.length = Convert.ToByte("A", 16);
            publish.messageType = Convert.ToByte("0C", 16);
        }

        public PublishWrk(byte[] input)
        {
            this.publish = new Publish();

            publish.length = input[0];
            publish.messageType = input[1];
            publish.flags = input[2];
            publish.topicId = new byte[2];
            publish.messageId = new byte[2];
            publish.data = new byte[publish.length - 7];
            System.Buffer.BlockCopy(input, 3, publish.topicId, 0, 2);
            System.Buffer.BlockCopy(input, 5, publish.messageId, 0, 2);
            System.Buffer.BlockCopy(input, 7, publish.data, 0, publish.length - 7);
        }

        public byte[] Serialized
        {
            get
            {
                byte[] messageFull = new byte[publish.length];
                messageFull[0] = publish.length;
                messageFull[1] = publish.messageType;
                messageFull[2] = publish.flags;
                System.Buffer.BlockCopy(publish.topicId, 0, messageFull, 3, 2);
                System.Buffer.BlockCopy(publish.messageId, 0, messageFull, 5, 2);
                System.Buffer.BlockCopy(publish.data, 0, messageFull, 7, publish.length - 7);

                return messageFull;
            }
        }
    }
}

