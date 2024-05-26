using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace ServidorTCP_winform
{
    public partial class Form1 : Form
    {

        static ConcurrentQueue<string> values_rx = new ConcurrentQueue<string>();
        static ConcurrentQueue<string> values_tx = new ConcurrentQueue<string>();
        static bool corriendo = true;

        public Form1()
        {
            InitializeComponent();

        }

        private void Entromouseaboton(object sender, EventArgs e)
        {
            btn_saludo.Text = "Dale...dale!!";
        }

        private void Saliomouseboton(object sender, EventArgs e)
        {
            btn_saludo.Text = "Presioname!!!";
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
            Console.WriteLine("Conectado");
            corriendo = true;
            try
            {
                while (true)
                {
                    //recibiendo
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

                    //transmitiendo la cola
                    if (values_tx.Count > 0)
                    {
                        string? var_tx;
                        values_tx.TryDequeue(out var_tx);
                        if (var_tx != null)
                        {
                            byte[] enviar = Encoding.ASCII.GetBytes(var_tx);
                            handler.Send(enviar);
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

            handler.Close();
            handler.Dispose();
        }

        private void arrancar_servidor(object sender, EventArgs e)
        {
            Thread server = new Thread(new ThreadStart(servidor));
            server.Start();
            btn_saludo.Enabled = false;
            tmr_loop.Enabled = true;
        }


        private void final(object sender, FormClosedEventArgs e)
        {
            corriendo = false;
        }

        private void update(object sender, EventArgs e)
        {
            string? datos;
            if (values_rx.Count > 0)
            {
                values_rx.TryDequeue(out datos);
                txt_recibido.Text += datos + "\r\n";
                if (datos != null)
                {
                    if (datos.StartsWith("web://"))
                    {
                        try
                        {
                            Process.Start("notepad.exe");
                        } catch(Exception ex) { 
                            Console.WriteLine(ex.Message); 
                        }
                    }
                }
            }
        }

        private void txt_recibido_TextChanged(object sender, EventArgs e)
        {

        }
    }
}