using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MessageInterface
{
    public struct Register
    {
        public byte length; //0
        public byte messageType; // 1
        public byte[] topicId; // 23
        public byte[] messageId; //45
        public byte[] topicName; //6n
    }
    public class RegisterWrk
    {
        public Register register;

        public RegisterWrk()
        {
            register = new Register();
            register.messageType = Convert.ToByte("0A", 16);
        }

        public RegisterWrk(byte[] input)
        {
            this.register = new Register();

            register.length = input[0];
            register.messageType = input[1];
            register.topicId = new byte[2];
            register.messageId = new byte[2];
            register.topicName = new byte[register.length - 6];
            System.Buffer.BlockCopy(input, 2, register.topicId, 0, 2);
            System.Buffer.BlockCopy(input, 4, register.messageId, 0, 2);
            System.Buffer.BlockCopy(input, 6, register.topicName, 0, register.length - 6);
        }

        public byte[] Serialized
        {
            get
            {
                byte[] messageFull = new byte[register.length];
                messageFull[0] = register.length;
                messageFull[1] = register.messageType;
                System.Buffer.BlockCopy(register.topicId, 0, messageFull, 2, 2);
                System.Buffer.BlockCopy(register.messageId, 0, messageFull, 4, 2);
                System.Buffer.BlockCopy(register.topicName, 0, messageFull, 6, register.length - 6 );

                return messageFull;
            }
        }
    }
}
