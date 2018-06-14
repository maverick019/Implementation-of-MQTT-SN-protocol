using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Text;

namespace MqttSnBrokerAPI
{
    public class Register
    {
        private byte[] topicID;
        private string topicNames;
        private byte[] registerID;

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
        public byte[] RegisterID
        {
            get
            {
                return registerID;
            }

            set
            {
                registerID = value;
            }


        }

       

        public static int Insert(MessageInterface.Register register, SqliteConnection sConnect)
        {
            string sql = "insert into Register(TopicID, TopicName) values (@TopicID, @TopicName)";
            SqliteCommand sCommand = new SqliteCommand(sql, sConnect);
            sCommand.Parameters.AddWithValue("@TopicID", ASCIIEncoding.ASCII.GetString(register.topicId));
            sCommand.Parameters.AddWithValue("@TopicName", ASCIIEncoding.ASCII.GetString(register.topicName));
            sConnect.Open();
            int ret = sCommand.ExecuteNonQuery();
            sConnect.Close();
            return ret;
            

        }

        public static void Delete(byte[] topicId, SqliteConnection sConnect)
        {
            string sql = "delete from Register where TopicID = @TopicID";
            SqliteCommand sCommand = new SqliteCommand(sql, sConnect);
            sCommand.Parameters.AddWithValue("@TopicID", ASCIIEncoding.ASCII.GetString(topicId));
            sConnect.Open();
            sCommand.ExecuteNonQuery();
            sConnect.Close();
            


        }

    }
}
