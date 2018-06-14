using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Text;

namespace MqttSnBrokerAPI
{
    public class Subscriber
    {
        private byte[] subscriberID;
        private string subscriberTopicName;

        public byte[] SubscriberID
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

        public static int Insert(MessageInterface.Subscribe subscribe, SqliteConnection sConnect, byte[] clientId)
        {
            string sql = "insert into Subscriber(SubscriberID, SubscriberTopicID) values (@SubscriberID, @SubscriberTopicID)";
            SqliteCommand sCommand = new SqliteCommand(sql, sConnect);
            sCommand.Parameters.AddWithValue("@SubscriberID", ASCIIEncoding.ASCII.GetString(clientId));
            sCommand.Parameters.AddWithValue("@SubscriberTopicID", ASCIIEncoding.ASCII.GetString(subscribe.topicId)); //TODO: Replace with Client ID
            sConnect.Open();
            int ret =  sCommand.ExecuteNonQuery();
            sConnect.Close();
            return ret;

        }

        internal static List<Subscriber> GetSubscribersbyTopic(byte[] topicId, SqliteConnection sConnect)
        {  //TODO: By me based on query datareader, build each object
            string sql = "select subscriberID from Subscriber where SubscriberTopicID = @topicID";
            SqliteCommand sCommand = new SqliteCommand(sql, sConnect);
            sCommand.Parameters.AddWithValue("@topicID", ASCIIEncoding.ASCII.GetString( topicId));
            sConnect.Open();
            SqliteDataReader reader = sCommand.ExecuteReader();
            List<Subscriber> retSubscribers = new List<Subscriber>(); 
            while (reader.Read())
            {
                Subscriber subs = new Subscriber();
                subs.SubscriberID = Encoding.ASCII.GetBytes(reader.GetString(0));
                retSubscribers.Add(subs);
            }

            sConnect.Close();
            return retSubscribers;
        }

        public static void Delete(byte[] clientId, SqliteConnection sConnect)
        {
            string sql = "delete from Subscriber where SubscriberID = @ClientID";
            SqliteCommand sCommand = new SqliteCommand(sql, sConnect);
            sCommand.Parameters.AddWithValue("@ClientID", ASCIIEncoding.ASCII.GetString(clientId));
            sConnect.Open();
            sCommand.ExecuteNonQuery();
            sConnect.Close();



        }
    }
}
