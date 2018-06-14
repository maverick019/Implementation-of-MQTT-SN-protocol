using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQLiteInterface
{
    public class Subscribers
    {
        private int subscriberID;
        private string subscriberTopicName;

        public int SubscriberID
        {
            get
            {
                return subscriberID;
            }

            set
            {
                subscriberID = value;
            }


        }
        public string SubscriberTopicName
        {
            get
            {
                return subscriberTopicName;
            }

            set
            {
                subscriberTopicName = value;
            }


        }
    }
}
