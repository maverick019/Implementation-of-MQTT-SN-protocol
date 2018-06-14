using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQLiteInterface
{
    public class MessageInformation
    {
        private string message;
        private string topicName;
        private int subscriberPendingID;

        public string Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
            }


        }

        public string TopicName
        {
            get
            {
                return topicName;
            }

            set
            {
                topicName = value;
            }


        }

        public int SubscriberPendingID
        {
            get
            {
                return subscriberPendingID;
            }

            set
            {
                subscriberPendingID = value;
            }


        }

    }
}
