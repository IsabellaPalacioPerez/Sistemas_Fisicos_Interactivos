using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ClaseTCPserver
{
    internal class Program
    {
        static Socket? handler;
        static Socket? socket;
        static EndPoint? local;
        static Thread? hilo;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Server!");
            configure_socket();
            bind_listen();
            aceptar();
            hilo = new Thread(new ThreadStart(recibir));
            hilo.Start();
            enviar();
            cerrar();
        }

        static void configure_socket()
        {
            IPAddress ip = IPAddress.Any;  //ip servidor
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
                Console.WriteLine("esperando conexión");
                handler = socket.Accept();
                Console.WriteLine("Conexion aceptada");
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
                        Console.Write("Esperando mensaje-->");

                        byte[] datos_rx = new byte[128];
                        int cantidad = handler.Receive(datos_rx);
                        string mensaje = Encoding.ASCII.GetString(datos_rx, 0, cantidad);
                        Console.WriteLine(mensaje);
                        
                        if (datos_rx[0] == 'S')
                        {
                            if (datos_rx[cantidad - 1] == 'F')
                            {
                                mensaje = Encoding.ASCII.GetString(datos_rx, 0, cantidad);
                                int startM = mensaje.IndexOf("$M");
                                string rx_payload = mensaje.Substring(startM, cantidad - startM - 1);
                                Console.WriteLine("Msg -> {0}", rx_payload);
                                int startN = mensaje.IndexOf("$N");
                                string rx_size = mensaje.Substring(startN, startM - startN);
                                Console.WriteLine("Tamaño --> {0}", rx_size);
                            }
                        }
                        Console.Write("Entra un mensaje -->");
                        string payload = Console.ReadLine() ?? "NoData";
                        string msg = "S$N" + payload.Length.ToString() + "$M" + payload + "F";
                        byte[] datos_tx = Encoding.ASCII.GetBytes(msg);
                        //byte[] datos_tx = Encoding.ASCII.GetBytes(payload);
                        handler.Send(datos_tx);
                        Console.WriteLine("Dato Enviado");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void enviar()
        {
            if (handler != null && handler.Connected == true)
            {
                try
                {
                    while (true)
                    {
                        Console.Write("Entra un mensaje -->");
                        string payload = Console.ReadLine() ?? "NoData";
                        string msg = "S$N" + payload.Length.ToString() + "$M" + payload + "F";
                        byte[] datos_tx = Encoding.ASCII.GetBytes(msg);
                        handler.Send(datos_tx);
                        Console.WriteLine("Dato Enviado");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void recibir()
        {
            if (handler != null && handler.Connected == true)
            {
                try
                {
                    while (true)
                    {
                        Console.Write("Esperando mensaje-->");


                        byte[] datos_rx = new byte[128];
                        int cantidad = handler.Receive(datos_rx);
                        if (cantidad == 0)
                        {
                            break;
                        }
                        string mensaje = Encoding.ASCII.GetString(datos_rx, 0, cantidad);
                        Console.WriteLine(mensaje);

                        if (datos_rx[0] == 'S')
                        {
                            if (datos_rx[cantidad - 1] == 'F')
                            {
                                mensaje = Encoding.ASCII.GetString(datos_rx, 0, cantidad);
                                int startM = mensaje.IndexOf("$M");
                                string rx_payload = mensaje.Substring(startM, cantidad - startM - 1);
                                Console.WriteLine("Msg -> {0}", rx_payload);
                                int startN = mensaje.IndexOf("$N");
                                string rx_size = mensaje.Substring(startN, startM - startN);
                                Console.WriteLine("Tamaño --> {0}", rx_size);
                            }
                        }
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
            if (socket != null && handler != null)
            {
                handler.Disconnect(false);
                handler.Close();
                handler.Dispose();
                Console.WriteLine("Desconectado");
            }
        }

    }
}