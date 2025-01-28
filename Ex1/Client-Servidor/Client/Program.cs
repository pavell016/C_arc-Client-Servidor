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
                if (phrase_to_reverse != "q")
                {
                    byte[] send = Encoding.UTF8.GetBytes(phrase_to_reverse);
                    ns.Write(send, 0, send.Length);

                    byte[] receiveBuffer = new byte[1024];
                    int bytesRead = ns.Read(receiveBuffer, 0, receiveBuffer.Length);
                    string reversedPhrase = Encoding.UTF8.GetString(receiveBuffer, 0, bytesRead);

                    Console.WriteLine($"Reversed Phrase: {reversedPhrase}\n");
                  
                }
                else { 
                    ns.Close();
                    client.Close();
                    client_functionality = false;
                }
            }

        }
        
    }
}
