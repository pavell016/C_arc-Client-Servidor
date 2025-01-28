using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        private static IPAddress ServerIP;
        private static int PortIP;
        private static IPEndPoint ServerEndPoint;

        static void Main(string[] args)
        {
            int ServerPort = 50000;
            ServerIP = IPAddress.Parse("127.0.0.1");            

            TcpListener Server = new TcpListener(ServerIP,ServerPort);
            Console.WriteLine("Servidor creat");

            Server.Start();
            Console.WriteLine("Servidor iniciat");

            TcpClient Client = Server.AcceptTcpClient();
            Console.WriteLine("Client connectat");

            //Rebem dades del client
            NetworkStream ServerNS = Client.GetStream();
            byte[] BufferLocal = new byte[256];        
            int BytesRebuts = ServerNS.Read(BufferLocal, 0, BufferLocal.Length);

            //Passem de bytes a string
            string s = "";
            s = Encoding.UTF8.GetString(BufferLocal, 0, BytesRebuts);

            string reverseString = ReverseString(s);

            //Passem de string a bytes
            byte[] fraseBytes = Encoding.UTF8.GetBytes(reverseString);

            //Enviem resposta al client
            ServerNS.Write(fraseBytes, 0, fraseBytes.Length);

            Console.WriteLine("Server finalitzat");

            ServerNS.Close();
            Client.Close();

            Server.Stop();

            Console.ReadLine();
        }

        static string ReverseString (string intString)
        {
            char[] charArray = intString.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
