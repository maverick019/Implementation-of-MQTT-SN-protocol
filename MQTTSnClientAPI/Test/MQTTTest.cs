using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class MQTTTest
    {
        public static void RegisterTest()
        {
            IotApi api = new IotApi();
            api.RegisterModule(new MQTTSnConnector());

            Dictionary<string, object> agr = new Dictionary<string, object>();
            agr.Add("ip", "127.0.0.1");

            agr.Add("port", 100);

            api.Open(agr);

            MessageInterface.RegisterWrk register = new MessageInterface.RegisterWrk();
            register.register.topicId = new byte[] { };
            register.register.topicName = ASCIIEncoding.ASCII.GetBytes("");
            register.register.messageId = ASCIIEncoding.ASCII.GetBytes(Convert.ToString(2).PadLeft(2, '0'));
            register.register.length = Convert.ToByte(6 + "ff".Length);

            api.SendAsync(register);

        }
    }
}
