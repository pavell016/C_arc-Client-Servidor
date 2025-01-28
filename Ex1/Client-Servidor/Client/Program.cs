using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //definicio servidor a connectar-se
            IPAddress direccio_server = IPAddress.Parse("127.0.0.1");
            int server_port = 50000;

            //connexió al servidor
            TcpClient client = new TcpClient();
            client.Connect(direccio_server,server_port);
            NetworkStream ns = client.GetStream();
            Console.WriteLine("Connexió Establerta\n\n");

            //string a enviar al servidor
            bool client_functionality = true;

            while (client_functionality) {
                Console.WriteLine("Siusplau entra una frase per a revertir l'ordre: (En cas de voler sortir entra 'q' )");
                string phrase_to_reverse = Console.ReadLine();
                if (phrase_to_reverse == "q")
                {
                    client_functionality = false;
                }
                else { 
                    byte[] buffer = new byte[1024];
                    int bytesRead = ns.Read(buffer, 0, buffer.Length);
                    string serverMessage = Encoding.Unicode.GetString(buffer, 0, bytesRead);
                    bytesRead = ns.Read(buffer, 0, buffer.Length);
                    string reversed_phrase = Encoding.Unicode.GetString(buffer, 0, bytesRead);
                    Console.WriteLine(reversed_phrase);
                }
            }

        }
        
    }
}
