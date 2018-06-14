using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Text;

namespace MqttSnBrokerAPI
{
    public class Clients
    {
        private byte[] clientid;
        private bool clientStatus;
        private byte[] keepAlive;
        private DateTime updatedTime;

        public byte[] ClientID
        {
            get
            {
                return clientid;
            }

            set
            {
                clientid = value;
            }


        }
        public bool ClientStatus
        {
            get
            {
                return clientStatus;
            }

            set
            {
                clientStatus = value;
            }


        }

        public byte[] KeepAlive
        {
            get
            {
                return keepAlive;
            }

            set
            {
                keepAlive = value;
            }


        }

        public DateTime UpdatedTime
        {
            get
            {
                return updatedTime;
            }

            set
            {
                updatedTime = value;
            }


        }

        public Clients(MessageInterface.Connect connect) 
            {
            this.clientid = connect.clientId;
            this.keepAlive = connect.duration;
            //TODO:ALl other fields
            }



        public static int Insert(Clients client, SqliteConnection sConnect)
        {
            string sql = "insert into Clients(Client_ID, Status, KeepAlive, UpdateTime) values (@Client_ID, @Status, @KeepAlive, @UpdateTime)";
            SqliteCommand sCommand = new SqliteCommand(sql, sConnect);
            sCommand.Parameters.AddWithValue("@Client_ID", ASCIIEncoding.ASCII.GetString(client.clientid));
            sCommand.Parameters.AddWithValue("@Status", client.clientStatus);
            sCommand.Parameters.AddWithValue("@KeepAlive", client.keepAlive);
            sCommand.Parameters.AddWithValue("@UpdateTime", DateTime.Now);
            sConnect.Open();

            int ret = 0;
            try
            {
               ret  = sCommand.ExecuteNonQuery();
            }
            catch(Exception e)
            {

            }
            sConnect.Close();
            return ret;

        }

        public static void Delete(byte[] clientId, SqliteConnection sConnect)
        {
            string sql = "delete from Clients where Client_ID = @ClientID";
            SqliteCommand sCommand = new SqliteCommand(sql, sConnect);
            sCommand.Parameters.AddWithValue("@ClientID", ASCIIEncoding.ASCII.GetString(clientId));
            sConnect.Open();
            sCommand.ExecuteNonQuery();
            sConnect.Close();
        } 

        //TODO: pingreply on broker
    }
}
