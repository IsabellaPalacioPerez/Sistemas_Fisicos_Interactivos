using System.Net.Sockets;
using System.Net;
using System.Collections.Concurrent;
using System.Text;

namespace TCPServerThreadCola
{
    internal class Program
    {
        static ConcurrentQueue<string> values_rx = new ConcurrentQueue<string>();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Thread server = new Thread(new ThreadStart(servidor));
            server.Start();
            while (true)
            {
                if (values_rx.Count > 5)
                {
                    while (values_rx.Count > 0)
                    {
                        string? elemento;
                        values_rx.TryDequeue(out elemento);
                        Console.WriteLine("Recibido: --> {0}", elemento);
                    }
                }
                Thread.Sleep(1000);
                Console.WriteLine("Ando");
            }
        }

        static void servidor()
        {
            IPAddress ip = IPAddress.Any;  //ip servidor
            EndPoint local = new IPEndPoint(ip, 12345); //endpoint del servidor
            Socket socket = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Socket configurado");

            socket.Bind(local);
            socket.Listen(1);

            Socket handler = socket.Accept();
            try
            {
                while (true)
                {
                    if (handler.Available > 0)
                    {
                        byte[] data = new byte[handler.Available];
                        int len = handler.Receive(data);
                        if (len > 0)
                        {
                            string data_rx = Encoding.ASCII.GetString(data, 0, len);
                            values_rx.Enqueue(data_rx);
                        }
                    }
                    if (handler.Connected == false)
                    {
                        break;
                    }
                    Thread.Sleep(1000);
                    Console.WriteLine("Esperando . . .");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            handler.Close();
        }
    }
}