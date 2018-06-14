//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;
//using Iot;
//using MessageInterface;
//using MQTTClientAPI;

//namespace MQTTSnTest
//{
//    public class MQTTTest
//    {
//        static int subID = 1;
//        static int pubId = 1;
//        static int regId = 1; 

//        [Fact]
//        public void RegisterTest()
//        {
//            IotApi api = new IotApi();
//            api.RegisterModule(new MQTTSnConnector());

//            Dictionary<string, object> agr = new Dictionary<string, object>();
//            agr.Add("ip", "127.0.0.1");

//            agr.Add("port", 100);

//            api.Open(agr);

//            MessageInterface.RegisterWrk register = new MessageInterface.RegisterWrk();
//            register.register.topicId = ASCIIEncoding.ASCII.GetBytes("15". PadLeft(2, '0'));
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

//        [Fact]
//        public void ConnectTest()
//        {
//            IotApi api = new IotApi();
//            api.RegisterModule(new MQTTSnConnector());

//            Dictionary<string, object> agr = new Dictionary<string, object>();
//            agr.Add("ip", "127.0.0.1");

//            agr.Add("port", 100);

//            api.Open(agr);

//            MessageInterface.ConnectWrk connect = new MessageInterface.ConnectWrk();
//            connect.connect.clientId = ASCIIEncoding.ASCII.GetBytes("0100");
//                connect.connect.flags = Flag.cleanSession;

//            api.SendAsync(connect, (succ) =>
//            {
//                //var k =byte.Parse(r.ToString());
//                var k = (byte)succ;
//                string reply = Convert.ToString(k);

//                //convert byte to string 

//            }, (error) =>
//            {

//            });
//        }
        
//        [Fact]
//        public void SubscribeTest()
//        {
//            IotApi api = new IotApi();
//            api.RegisterModule(new MQTTSnConnector());

//            Dictionary<string, object> agr = new Dictionary<string, object>();
//            //agr.Add("ip", "127.0.0.1");

//            //agr.Add("port", 100);

//            //api.Open(agr);

//            MessageInterface.SubscribeWrk subscribe = new MessageInterface.SubscribeWrk();
//            subscribe.subscribe.topicId = ASCIIEncoding.ASCII.GetBytes("15".PadLeft(2, '0'));
//            subscribe.subscribe.messageId = ASCIIEncoding.ASCII.GetBytes(Convert.ToString(subID).PadLeft(2, '0'));

//            api.SendAsync(subscribe, (succ) =>
//            {
//                //var k =byte.Parse(r.ToString());
//                var k = (byte)succ;
//                string reply = Convert.ToString(k);

//                //convert byte to string 

//            }, (error) =>
//            {

//            });
//        }

//        [Fact]
//        public void PublishTest()
//        {
//            IotApi api = new IotApi();
//            api.RegisterModule(new MQTTSnConnector());

//            Dictionary<string, object> agr = new Dictionary<string, object>();
//            //agr.Add("ip", "127.0.0.1");

//            //agr.Add("port", 100);

//            //api.Open(agr);

//            MessageInterface.PublishWrk publish = new MessageInterface.PublishWrk();
//            publish.publish.topicId = ASCIIEncoding.ASCII.GetBytes("15".PadLeft(2, '0')); ;
//            publish.publish.data = ASCIIEncoding.ASCII.GetBytes("lights off");
//            publish.publish.messageId = ASCIIEncoding.ASCII.GetBytes(Convert.ToString(pubId).PadLeft(2, '0'));
//            publish.publish.length = Convert.ToByte(7 + "Lights off".Length);

//            api.SendAsync(publish, (succ) =>
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
