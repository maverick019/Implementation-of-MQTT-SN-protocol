//using Iot;
//using MQTTClientAPI;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MQTTSnTest
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            RegisterTest();
//        }

//        public static void RegisterTest()
//        {
//            IotApi api = new IotApi();
//            api.RegisterModule(new MQTTSnConnector());

//            Dictionary<string, object> agr = new Dictionary<string, object>();
//            agr.Add("ip", "127.0.0.1");

//            agr.Add("port", 100);

//            api.Open(agr);

//            MessageInterface.RegisterWrk register = new MessageInterface.RegisterWrk();
//            register.register.topicId = ASCIIEncoding.ASCII.GetBytes("15".PadLeft(2, '0'));
//            register.register.topicName = ASCIIEncoding.ASCII.GetBytes("Light");
//            register.register.messageId = ASCIIEncoding.ASCII.GetBytes(Convert.ToString(2).PadLeft(2, '0'));
//            register.register.length = Convert.ToByte(6 + "light".Length);

//            api.SendAsync(register, (succ) =>
//            {
//                //var k =byte.Parse(r.ToString());
//                var k = (byte)succ;
//                string reply = Convert.ToString(k);

//                //convert byte to string 

//            }, (error) =>
//            {

//            });

//        }
//    }
//}
