using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace SQLiteInterface
{
    public class Publisher
    {
        private int topicID;
        private string topicNames;
        private int publisherID;

        public int TopicID
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
        public string TopicNames
        {
            get
            {
                return topicNames;
            }

            set
            {
                topicNames = value;
            }


        }
        public int PublisherID
        {
            get
            {
                return publisherID;
            }

            set
            {
                publisherID = value;
            }


        }

        public static int Insert(Publisher publish, SqliteConnection sConnect)
        {
            string sql = "insert into Publisher(TopicID, TopicName, PublisherID) values (@TopicID, @TopicName, @PublisherID)";
            SqliteCommand sCommand = new SqliteCommand(sql, sConnect);
            sCommand.Parameters.AddWithValue("@TopicID", publish.topicID);
            sCommand.Parameters.AddWithValue("@TopicName", publish.topicNames);
            sCommand.Parameters.AddWithValue("@PublisherID", publish.publisherID);
            return sCommand.ExecuteNonQuery();

        }



    }
}
