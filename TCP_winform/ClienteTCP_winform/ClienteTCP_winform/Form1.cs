using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Collections.Concurrent;

namespace ClienteTCP_winform
{
    public partial class Form1 : Form
    {

        static ConcurrentQueue<string> values_rx = new ConcurrentQueue<string>();
        static ConcurrentQueue<string> values_tx = new ConcurrentQueue<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_conectar_Click(object sender, EventArgs e)
        {
            Thread client = new Thread(new ThreadStart(cliente));
            client.Start();

        }


        static void cliente()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");  //ip servidor
            EndPoint remote = new IPEndPoint(ip, 12345); //endpoint del servidor
            
            Socket socket = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Socket configurado");

            socket.Connect(remote);
      
            Console.WriteLine("Conectado");

            try
            {
                while (true)
                {
                    //recibiendo
                    if (socket.Available > 0)
                    {
                        byte[] data = new byte[socket.Available];
                        int len = socket.Receive(data);
                        if (len > 0)
                        {
                            string data_rx = Encoding.ASCII.GetString(data, 0, len);
                            values_rx.Enqueue(data_rx);
                        }
                    }
                    if (socket.Connected == false)
                    {
                        break;
                    }

                    //transmitiendo la cola
                    if (values_tx.Count > 0)
                    {
                        string? var_tx;
                        values_tx.TryDequeue(out var_tx);
                        if (var_tx != null)
                        {
                            byte[] enviar = Encoding.ASCII.GetBytes(var_tx);
                            socket.Send(enviar);
                        }
                    }
                    // Thread.Sleep(1000);
                    // Console.WriteLine("Esperando...");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            socket.Close();
            socket.Dispose();
        }

    }
}