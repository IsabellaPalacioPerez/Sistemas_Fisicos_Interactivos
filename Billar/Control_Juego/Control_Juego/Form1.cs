using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Concurrent;
using System.Threading;

namespace Control_Juego
{
    public partial class Form1 : Form
    {

        static ConcurrentQueue<string> values_rx = new ConcurrentQueue<string>();
        ConcurrentQueue<int> values_tx = new ConcurrentQueue<int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread conex_cliente = new Thread(new ThreadStart(cliente));
            conex_cliente.Start();
        }

        private void hSB_fuerza_Scroll(object sender, ScrollEventArgs e)
        {
            txt_valorfuerza.Text = hSB_fuerza.Value.ToString();
            values_tx.Enqueue(hSB_fuerza.Value);
        }

        private void cliente()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");  //ip servidor
            EndPoint remote = new IPEndPoint(ip, 51000); //endpoint del servidor
            Socket socket = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            //Console.WriteLine("Socket configurado");
            socket.Connect(remote);
            //Console.WriteLine("Conectado");

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
                        int var_tx;
                        values_tx.TryDequeue(out var_tx);
                        if (var_tx <1000)
                        {
                            //0x06 0x30 0xNN 0xMM 0x0a
                            byte[] enviar = new byte[5];
                            enviar[0] = (byte)0x06;
                            enviar[1] = (byte)0x30;
                            enviar[4] = (byte)0x0a;
                            enviar[2] = (byte)(var_tx >> 8);
                            enviar[3] = (byte)(var_tx & 0xFF);
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
