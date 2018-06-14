using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Text;

namespace MqttSnBrokerAPI
{
    public class Publisher
    {
        private string message;
        private string topicName;
        private byte[] topicID;
        private byte[] subscriberPendingID;

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

        public byte[] SubscriberPendingID
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

        public byte[] TopicID
        {
            get
            {
                return topicID;
            }

            set
            {
                topicID = value;
            }


        }

        public static int Insert(MessageInterface.Publish publish, SqliteConnection sConnect)
        {
            string sql = "insert into Publisher(Messages, TopicID, TopicName, SubscriberPendingID) values (@Messages, @TopicID, '', @SubscriberPendingID)";
            

            List<Subscriber> subscribers = Subscriber.GetSubscribersbyTopic(publish.topicId, sConnect);
            foreach (Subscriber s in  subscribers)
            {
                SqliteCommand sCommand = new SqliteCommand(sql, sConnect);
                sCommand.Parameters.AddWithValue("@TopicID", ASCIIEncoding.ASCII.GetString(publish.topicId));
                sCommand.Parameters.AddWithValue("@Messages", ASCIIEncoding.ASCII.GetString(publish.data));
                sCommand.Parameters.AddWithValue("@SubscriberPendingID", ASCIIEncoding.ASCII.GetString(s.SubscriberID));
                sConnect.Open();
                sCommand.ExecuteNonQuery();
                sConnect.Close();
            }
            return 1;

        }

        public static List<MessageInterface.PublishWrk> GetPublishbyClient(byte[] clientId, SqliteConnection sConnect)
        {
            string sql = "select * from Publisher where SubscriberPendingID = @ClientID";
            SqliteCommand sCommand = new SqliteCommand(sql, sConnect);
            sCommand.Parameters.AddWithValue("@ClientID", ASCIIEncoding.ASCII.GetString(clientId));
            sConnect.Open();
            SqliteDataReader reader = sCommand.ExecuteReader();
            List<MessageInterface.PublishWrk> retPublishers = new List<MessageInterface.PublishWrk>();
            while (reader.Read())
            {
                MessageInterface.PublishWrk pubs = new MessageInterface.PublishWrk();
                pubs.publish.topicId = Encoding.ASCII.GetBytes(reader.GetString(0));
                pubs.publish.data = Encoding.ASCII.GetBytes(reader.GetString(2));
                pubs.publish.messageId = new byte[] { 0,0};
                retPublishers.Add(pubs);
            }

            sConnect.Close();
            return retPublishers;
        }

        public static void DeleteEntry(byte[] topicId, byte[] clientId,  SqliteConnection sConnect)
        {
            string sql = "delete from Publisher where topicId = @topicID and SubscriberPendingID = @ClientId";
            SqliteCommand sCommand = new SqliteCommand(sql, sConnect);
            sCommand.Parameters.AddWithValue("@topicID", ASCIIEncoding.ASCII.GetString(topicId));
            sCommand.Parameters.AddWithValue("@ClientId", ASCIIEncoding.ASCII.GetString(clientId));
            sConnect.Open();
            sCommand.ExecuteNonQuery();
            sConnect.Close();


        }

        public static void Delete(byte[] clientId, SqliteConnection sConnect)
        {
            string sql = "delete from Publisher where SubscriberPendingID = @ClientID";
            SqliteCommand sCommand = new SqliteCommand(sql, sConnect);
            sCommand.Parameters.AddWithValue("@ClientID", ASCIIEncoding.ASCII.GetString(clientId));
            sConnect.Open();
            sCommand.ExecuteNonQuery();
            sConnect.Close();
        }



    }
}
