using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;


namespace SQLiteInterface
{
    public class Clients
    {
        private int clientid;
        private bool clientStatus;
        private TimeSpan keepAlive;
        private DateTime updatedTime;

        public int ClientID
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

        public TimeSpan KeepAlive
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


        public static int Insert(Clients client, SqliteConnection sConnect)
        {
            string sql = "insert into Clients(ClientID, ClientStatus, KeepAlive, UpdateTime) values (@ClientID, @ClientStatus, @KeepAlive, @UpdateTime)";
            SqliteCommand sCommand = new SqliteCommand(sql, sConnect);
            sCommand.Parameters.AddWithValue("@ClientID", client.clientid);
            sCommand.Parameters.AddWithValue("@ClientStatus", client.clientStatus);
            sCommand.Parameters.AddWithValue("@KeepAlive", client.keepAlive);
            sCommand.Parameters.AddWithValue("@UpdateTime", DateTime.Now);
            return sCommand.ExecuteNonQuery();

        }

        public static void Delete(Clients client, SqliteConnection sConnect)
        {
            string sql = "delete from Clients where ClientID = @ClientID";
            SqliteCommand sCommand = new SqliteCommand(sql, sConnect);
            sCommand.Parameters.AddWithValue("@ClientID", client.clientid);

            sCommand.ExecuteNonQuery();

        }
    }
}
