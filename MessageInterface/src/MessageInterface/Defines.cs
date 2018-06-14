using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageInterface
{
    public static class Flag
    {
        public static byte cleanSession = 3;
        public static byte dUP = 2;

    }
    public enum MsgTyp
    {
        AdverTise = 0,
        SearchGw = 1,          //convert to hex
        Connect = 4,
        Connack = 5,
        GwInfo = 2,
        Reserved = 3,
        WillTopicReq = 6,
        WillTopic = 7,
        WillMsgReq = 8,
        WillMsg = 9,
        Register = 10,
        Regack = 11,
        Publish = 12,
        Puback = 13,
        PubComp = 14,
        PubRec = 15,
        PubRel = 16,
        Reserve = 17,
        Subscribe = 18,
        Suback = 19,

    }

    public static class ReturnCodes
    {
        public static byte Accepted = 0x00;
        public static byte Congestion = 0x01;
        public static byte InvaliDtopic = 0x02;
        public static byte NotSupported = 0x03;
    }   

}
