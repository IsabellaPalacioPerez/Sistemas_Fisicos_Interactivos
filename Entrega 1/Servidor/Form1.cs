using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Concurrent;

namespace Servidor
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
        private void EntroMouse(object sender, EventArgs e)
        {
            btn_conectar.Text = "Iniciar";
        }
        private void SalioMouse(object sender, EventArgs e)
        {
            btn_conectar.Text = "Iniciar Servidor";
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

            NetworkStream stream = new NetworkStream(handler);

            // Generar un número aleatorio entre 1 y 100
            Random rnd = new Random();
            int numAdivinar = rnd.Next(1, 101);
            // Iniciar el juego de adivinación
            byte[] data1 = new byte[256];
            string respuesta = "";
            int intentos = 0;
            try
            {
                while (corriendo)
                {
                    // Leer el número ingresado por el cliente
                    int bytes = stream.Read(data1, 0, data1.Length);
                    string numCliente = Encoding.ASCII.GetString(data1, 0, bytes);
                    values_rx.Enqueue(numCliente);

                    // Verificar si el número ingresado es el número a adivinar
                    int intentoCliente = Int32.Parse(numCliente);
                    if (intentoCliente == numAdivinar)
                    {
                        respuesta = "¡Felicidades! Adivinaste el numero.";
                        corriendo = false;
                    }
                    else if (intentoCliente < numAdivinar)
                    {
                        respuesta = "El numero a adivinar es mayor.";
                    }
                    else if (intentoCliente > numAdivinar)
                    {
                        respuesta = "El numero a adivinar es menor.";
                    }

                    // Incrementar el contador de intentos
                    intentos++;

                    // Verificar si se ha alcanzado el límite de intentos
                    if (intentos >= 10)
                    {
                        respuesta = "Se ha alcanzado el límite de intentos. El numero a adivinar era " + numAdivinar;
                        corriendo = false;
                    }

                    // Enviar la respuesta al cliente
                    byte[] bytes1= Encoding.ASCII.GetBytes(respuesta);
                    stream.Write(bytes1,0,bytes1.Length);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            handler.Close();
            handler.Dispose();
        }

        private void ArrancarServidor(object sender, EventArgs e)
        {
            Thread server = new Thread(new ThreadStart(servidor));
            server.Start();
            btn_conectar.Enabled = false;
            btn_conectar.BackColor = SystemColors.ButtonShadow;
            tmr_loop.Enabled = true;

        }
        private void Final(object sender, FormClosedEventArgs e)
        {
            corriendo = false;
        }

        private void update(object sender, EventArgs e)
        {
            string datos;
            if (values_rx.Count > 0)
            {
                values_rx.TryDequeue(out datos);
                txt_recibido.Text += datos + "\r\n";                
            }
        }
        private void txt_recibido_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
