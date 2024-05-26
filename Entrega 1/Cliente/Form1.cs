using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Cliente
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_conectar_Click(object sender, EventArgs e)
        {
            Thread client = new Thread(new ThreadStart(cliente));
            client.Start();
            btn_conectar.Enabled = false;
            btn_conectar.BackColor = SystemColors.ButtonShadow;
            tmr_loop.Enabled = true;
        }

        static void cliente()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");  //ip servidor
            IPEndPoint remote = new IPEndPoint(ip, 12345); //endpoint del servidor

            Socket socket = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Socket configurado");

            socket.Connect(remote);

            Console.WriteLine("Conectado");

            NetworkStream stream = new NetworkStream(socket);

            string respuesta = "";


            try
            {
                // Iniciar el juego de adivinación
                values_rx.Enqueue("Adivina un número entre 1 y 100:");

                while (corriendo)
                {
                    // Leer el número ingresado por el usuario
                    string numCliente;
                    if (values_tx.TryDequeue(out numCliente))
                    {
                        // Enviar el número al servidor
                        byte[] data3 = Encoding.ASCII.GetBytes(numCliente);
                        stream.Write(data3, 0, data3.Length);
                        values_rx.Enqueue(numCliente);

                        // Recibir la respuesta del servidor
                        data3 = new byte[256];
                        int bytes = stream.Read(data3, 0, data3.Length);
                        respuesta = Encoding.ASCII.GetString(data3, 0, bytes);
                        values_rx.Enqueue(respuesta);

                        // Verificar si el juego ha terminado
                        if (respuesta.Contains("Felicidades") || respuesta.Contains("límite de intentos"))
                        {
                            corriendo = false;
                        }
                        else
                        {
                            values_rx.Enqueue("Intenta de nuevo:");
                        }
                    }
                    else
                    {
                        Thread.Sleep(100);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            stream.Close();
        }

        private void btn_enviar_click(object sender, EventArgs e)
        {
            string texto = txt_enviar.Text;
            values_tx.Enqueue(texto);
            txt_enviar.Text = "";
        }

        private void Final(object sender, FormClosedEventArgs e)
        {
            corriendo = false;
        }

        private void update(object sender, EventArgs e)
        {
            string datos2;
            if (values_rx.Count > 0)
            {
                values_rx.TryDequeue(out datos2);
                txt_recibido.Text += datos2 + "\r\n";
            }
        }
    }
}
