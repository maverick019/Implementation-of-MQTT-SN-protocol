//using MessageInterface;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Sockets;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace MQTTClientAPI
//{
//    public class MQTTSnClient
//    {
//        static IPEndPoint ipEndpoint; //= new IPEndPoint(IPAddress.Parse("127.0.0.1"), 100);
//        private static readonly Socket clientSocket = new Socket
//               (ipEndpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
//        static int portNumber = 0;
//        static string port = "";

//        static int subID = 1;
//        static int pubId = 1;
//        static int regId = 1;

//        public Socket GetClientSocket
//        {
//            get
//            {
//                return clientSocket;
//            }
//        }

//        public MQTTSnClient(string ip, int port)
//        {
//            ipEndpoint = new IPEndPoint(IPAddress.Parse(ip), port);
//        }

//        public MQTTSnClient()
//        { }
//        static void Main()
//        {

//            Console.Title = "Client";
//            Console.WriteLine("Please Indicate the Port number to activate:");
//            port = Console.ReadLine();
//            port = port.PadLeft(4, '0');
//            portNumber = Convert.ToInt32(port);

//            Console.WriteLine("Port activated");
//            //ConnectToServer();

//            Console.WriteLine("Connect clean? ");
//            String read = Console.ReadLine();
//            Boolean clean = (read.ToUpper() == "Y") ? true : false;
//            Console.WriteLine("Connecting");
//            RequestLoop(ASCIIEncoding.ASCII.GetBytes(port), clean);

//            Thread readThread = new Thread(new ThreadStart(ReceiveMessage));
//            readThread.Start();

//            while (true)
//            {
//                Console.Clear();
//                Console.WriteLine("Options: CONNECT: C ,REGISTER: R,PUBLISH: P, SUBSCRIBE: S");
//                Console.WriteLine();
//                Console.WriteLine("Please Indicate the operation: ");
//                string operation = Console.ReadLine();

//                switch (operation.ToUpper())
//                {
//                    case "C":
//                        {
//                            Console.WriteLine("Connect clean? ");
//                            read = Console.ReadLine();
//                            clean = (read.ToUpper() == "Y") ? true : false;
//                            Console.WriteLine("Connecting");
//                            RequestLoop(ASCIIEncoding.ASCII.GetBytes(port), clean);
//                            break;
//                        }
//                    case "R":
//                        {
//                            Console.WriteLine("Enter Topic ID: ");
//                            byte[] topicId = ASCIIEncoding.ASCII.GetBytes(Console.ReadLine().PadLeft(2, '0'));
//                            Console.WriteLine("Enter topic name");
//                            string topicName = Console.ReadLine();
//                            Sendregister(topicId, topicName);
//                            Console.WriteLine("Registration request sent");
//                            break;
//                        }
//                    case "P":
//                        {
//                            Console.WriteLine("Enter Topic ID: ");
//                            byte[] topicId = ASCIIEncoding.ASCII.GetBytes(Console.ReadLine().PadLeft(2, '0'));
//                            Console.WriteLine("Enter message to publish: ");
//                            string message = Console.ReadLine();
//                            SendPublish(topicId, message);
//                            Console.WriteLine("Publish sent");
//                            break;
//                        }
//                    case "S":
//                        {
//                            Console.WriteLine("Enter Topic ID: ");
//                            byte[] topicId = ASCIIEncoding.ASCII.GetBytes(Console.ReadLine().PadLeft(2, '0'));
//                            //Console.WriteLine("Enter Subscriber ID: ");
//                            //int subscriberID = Convert.ToInt32(Console.ReadLine());
//                            //Console.WriteLine("Enter message to subscribe: ");
//                            string message = "";
//                            SendSubscribe(topicId);
//                            Console.WriteLine("Subscription sent");
//                            break;
//                        }
//                }
//                Console.WriteLine("Continue ? ");
//                Console.ReadLine();
//                Console.Clear();
//            }
//        }

//        public void ConnectToServer()
//        {
//            int attempts = 0;

//            while (!clientSocket.Connected)
//            {
//                try
//                {
//                    attempts++;
//                    Console.WriteLine("Connection attempt " + attempts);
//                    // Change IPAddress.Loopback to a remote IP to connect to a remote host.
//                    clientSocket.Connect(IPAddress.Loopback, portNumber);
//                    // The following is to flush out the socket of any prev messages
//                    if (clientSocket.Poll(5000, SelectMode.SelectRead))
//                    {
//                        var buffer = new byte[2048];
//                        clientSocket.Receive(buffer);
//                    }
//                }
//                catch (SocketException ex)
//                {
//                    Console.WriteLine("Exception :" + ex.Message);
//                }
//            }

//            Console.Clear();
//            Console.WriteLine("Connected");
//        }

//        private static void RequestLoop(byte[] clientId, bool clean)
//        {
//            Console.WriteLine(@"<Type ""exit"" to properly disconnect client>");

//            SendRequest(clientId, clean);
//        }

//        /// <summary>
//        // Close socket and exit program.
//        /// </summary>
//        private static void Exit(Socket clientSocket)
//        {
//            clientSocket.Shutdown(SocketShutdown.Both);
//            Environment.Exit(0);
//        }

//        private static void sendrequest(byte[] clientid, bool clean)
//        {
//            messageinterface.connectwrk connect = new messageinterface.connectwrk();
//            connect.connect.clientid = clientid;
//            if (clean)
//                connect.connect.flags = flag.cleansession; //

//            clientsocket.send(connect.serialized, 0, connect.connect.length, socketflags.none);
//        }

//        private static byte ReceiveResponse(byte[] input)
//        {
//            ConnackWrk con = new ConnackWrk(input);
//            return con.connack.returnCode;


//        }

//        private static void Sendregister(byte[] topicId, string topicName)
//        {
//            MessageInterface.RegisterWrk register = new MessageInterface.RegisterWrk();
//            register.register.topicId = topicId;
//            register.register.topicName = ASCIIEncoding.ASCII.GetBytes(topicName);
//            register.register.messageId = ASCIIEncoding.ASCII.GetBytes(Convert.ToString(regId).PadLeft(2, '0'));
//            register.register.length = Convert.ToByte(6 + topicName.Length);
//            clientSocket.Send(register.Serialized, 0, register.register.length, SocketFlags.None);
//        }

//        private static void SendPublish(byte[] topicId, string message)
//        {

//            MessageInterface.PublishWrk publish = new MessageInterface.PublishWrk();
//            publish.publish.topicId = topicId;
//            publish.publish.data = ASCIIEncoding.ASCII.GetBytes(message);
//            publish.publish.messageId = ASCIIEncoding.ASCII.GetBytes(Convert.ToString(pubId).PadLeft(2, '0'));
//            publish.publish.length = Convert.ToByte(7 + message.Length);
//            clientSocket.Send(publish.Serialized, 0, publish.publish.length, SocketFlags.None);
//        }

//        private static void RegisterResponse(byte[] input)
//        {
//            RegackWrk reg = new RegackWrk(input);
//            Console.WriteLine("\t\t\t\t\t\t Regack: " + reg.regack.ReturnCode);
//        }

//        private static void PublishResponse(byte[] input)
//        {
//            PubackWrk pub = new PubackWrk(input);
//            Console.WriteLine("\t\t\t\t\t\t Puback: " + pub.puback.ReturnCode);
//        }

//        private static void SendSubscribe(byte[] topicId)
//        {
//            MessageInterface.SubscribeWrk subscribe = new MessageInterface.SubscribeWrk();
//            subscribe.subscribe.topicId = topicId;
//            subscribe.subscribe.messageId = ASCIIEncoding.ASCII.GetBytes(Convert.ToString(subID).PadLeft(2, '0'));

//            clientSocket.Send(subscribe.Serialized, 0, subscribe.subscribe.length, SocketFlags.None);
//        }

//        private static void SubscribeResponse(byte[] input)
//        {
//            MessageInterface.SubackWrk sub = new SubackWrk(input);
//            Console.WriteLine("\t\t\t\t\t\t Suback: " + sub.suback.ReturnCode);
//        }

//        public static byte ReceiveMessage(Socket clientSocket)
//        {
//            byte[] header = new byte[2];
//            byte[] messageBody;
//            int length = 0;
//            while (!clientSocket.Poll(1000, SelectMode.SelectRead))
//            {
//                Thread.Sleep(100);
//            }
//            while (true)
//            {
//                int received = clientSocket.Receive(header, SocketFlags.None);

//                MsgTyp type = GetMsgType(header, ref length);
//                if (length == 0)
//                    continue;
//                messageBody = new byte[length - 2];
//                clientSocket.Receive(messageBody, SocketFlags.None);

//                // Create the full message
//                byte[] messageFull = new byte[length];
//                System.Buffer.BlockCopy(header, 0, messageFull, 0, 2);
//                System.Buffer.BlockCopy(messageBody, 0, messageFull, 2, length - 2);

//                switch (type)
//                {
//                    case MsgTyp.Suback:
//                        SubscribeResponse(messageFull);
//                        break;
//                    case MsgTyp.Puback:
//                        PublishResponse(messageFull);
//                        break;
//                    case MsgTyp.Regack:
//                        RegisterResponse(messageFull);
//                        break;
//                    case MsgTyp.Connack:
//                        return ReceiveResponse(messageFull);
//                        break;
//                    case MsgTyp.Publish:

//                        MessageInterface.PublishWrk publ = new PublishWrk(messageFull);

//                        MessageInterface.PubackWrk pubAck = new PubackWrk();
//                        pubAck.puback.topicId = publ.publish.topicId;
//                        pubAck.puback.messageId = publ.publish.messageId;

//                        clientSocket.Send(pubAck.Serialized, 0, pubAck.puback.length, SocketFlags.None);

//                        Console.WriteLine("REceived a message published by the server");
//                        Console.WriteLine("TopicID: " + ASCIIEncoding.ASCII.GetString(publ.publish.topicId));
//                        Console.WriteLine("MsgId: " + ASCIIEncoding.ASCII.GetString(publ.publish.messageId));
//                        Console.WriteLine("Message from the server: " + ASCIIEncoding.ASCII.GetString(publ.publish.data));
//                        Console.WriteLine("Continue ?");
//                        Console.ReadLine();

//                        Console.Clear();
//                        break;

//                }
//                //Thread.Sleep(100);
//            }
//        }


//        public static MsgTyp GetMsgType(byte[] input, ref int length)
//        {
//            byte msgType = input[1];
//            length = Convert.ToInt32(input[0]);

//            switch (msgType)
//            {
//                case (byte)05:
//                    return MsgTyp.Connack;
//                case (byte)11:
//                    return MsgTyp.Regack;
//                case (byte)13:
//                    return MsgTyp.Puback;
//                case (byte)19:
//                    return MsgTyp.Suback;
//                case (byte)04:
//                    return MsgTyp.Connect;
//                case (byte)10:
//                    return MsgTyp.Register;
//                case (byte)12:
//                    return MsgTyp.Publish;
//                case (byte)18:
//                    return MsgTyp.Subscribe;
//                default:
//                    return MsgTyp.Connect;
//            }
//        }
//    }
//}
