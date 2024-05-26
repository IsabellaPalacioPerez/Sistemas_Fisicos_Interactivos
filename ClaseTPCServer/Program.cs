using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ClaseTPCServer
{
    public class Program
    {
        static Socket? handler;
        static Socket? socket;
        static EndPoint? local;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Server!");
            configure_socket();
            bind_listen();
            aceptar();
            recibiryenviar();
            cerrar();
        }

        static void configure_socket()
        {
            //IPAddress ip = IPAddress.Parse("127.0.0.1"); //ip servidor de tu computador HOME
            IPAddress ip = IPAddress.Any; //ip cualquier servidor
            local = new IPEndPoint(ip, 12345); //endpoint del servidor
            socket = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Socket configurado");

        }

        static void bind_listen()
        {
            if (local != null && socket != null) 
            {
                socket.Bind(local);
                socket.Listen(1);
                Console.WriteLine("Socket listo escuchando");
            }
        }

        static void aceptar()
        {
            if (socket != null)
            {
                Console.WriteLine("Esperando conexión");
                handler = socket.Accept();
                Console.WriteLine("Conexión aceptada");
            }
        }

        static void recibiryenviar()
        {
           if (handler != null && handler.Connected == true)
            {
                try
                {
                    while (true)
                    {
                        Console.WriteLine("Esperando mensaje --> ");

                        byte[] datos_rx = new byte[128];
                        int cantidad = handler.Receive(datos_rx);
                        string mensaje = Encoding.ASCII.GetString(datos_rx, 0, cantidad);
                        Console.WriteLine(mensaje);
                        Console.WriteLine("Entra un mensaje --> ");
                        string payload = Console.ReadLine() ?? "NoData";
                        byte[] datos_tx = Encoding.ASCII.GetBytes(payload);
                        handler.Send(datos_tx);
                        Console.WriteLine("Dato enviado");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
           }
        }

        static void cerrar()
        {
           
        }
    }
}