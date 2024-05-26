using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Clase_1_02_23
{
    internal class Program
    {
        static Socket? socket;
        static IPEndPoint? remoto;

        static void Main(string[] args)
        {
            Console.WriteLine("Configurar");
            Configure_Socket();
            Connect_Socket();
            EnviaryRecibir();
            Cerrar();
        }

        //A donde va ir(A local host por el #ip)(Al puerto 12345)
        static void Configure_Socket()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1"); //ip servidor
            remoto = new IPEndPoint(ip, 12345);
            socket = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }
        //Conectar
        static void Connect_Socket()
        {
            try
            {
                if (socket != null && remoto != null)
                {
                    socket.Connect(remoto);
                    Console.WriteLine("Conectado a {0}", socket.RemoteEndPoint.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Enviar lo que diga ela linea 52. El dato se dfedbe convertir a byte.
        static void EnviaryRecibir()
        {
            if (socket != null && socket.Connected == true)
            {
                try
                {
                    while(true)
                    {
                        Console.WriteLine("Entra un mensaje --> ");
                        string payload = Console.ReadLine() ?? "NoData";
                        string ?msg = "S$N" + payload.Length.ToString() + "$M" + payload + "F";
                        byte[] datos_tx = Encoding.ASCII.GetBytes(msg);
                        socket.Send(datos_tx);
                        Console.WriteLine("Dato Enviado");
                        
                        byte[] datos_rx = new byte[64];
                        int cantidad = socket.Receive(datos_rx);
                        if (datos_rx[0] == 'S')
                        {
                            if (datos_rx[cantidad - 1] == 'F')
                            {
                                string mensaje = Encoding.ASCII.GetString(datos_rx,0,cantidad);
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

        //Cerrar la conexión.
        static void Cerrar()
        {
            if(socket != null && socket.Connected == true)   
            {
                socket.Disconnect(false);
                socket.Close();
                socket.Dispose();
                Console.WriteLine("Desconectado");
            }
        }
    }
}