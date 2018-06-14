//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Iot;
//using System.Text;
//using MessageInterface;

//namespace MQTTClientAPI
//{
//    public class Test
//    {
//        public static void Main(string[] agr)
//        {
//            test01();
//        }
//        //example of test but not be here
//        public static void test01()
//        {
//            IotApi api = new IotApi();
//            api.RegisterModule(new MQTTSnConnector());

//            Dictionary<string, object> agr = new Dictionary<string, object>();
//            agr.Add("ip", "127.0.0.1");

//            agr.Add("port", 100);

//            api.Open(agr);

//            MessageInterface.RegisterWrk register = new MessageInterface.RegisterWrk();
//            register.register.topicId = new byte[] { };
//            register.register.topicName = ASCIIEncoding.ASCII.GetBytes("");
//            register.register.messageId = ASCIIEncoding.ASCII.GetBytes(Convert.ToString(2).PadLeft(2, '0'));
//            register.register.length = Convert.ToByte(6 + "ff".Length);

//            api.SendAsync(register);

//        }
//    }
//}
