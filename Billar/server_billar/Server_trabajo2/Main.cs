using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Server_trabajo2
{
    public partial class main : Form
    {
        DateTime startTime;
        Hole hole;
        Ball ball;

        bool win = false;

        public main()
        {
            InitializeComponent();
        }

        Rectangle last_ball;

        private void finish_load(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(put.Width, put.Height);
            Graphics gr = Graphics.FromImage(bm);
            hole = new Hole(980, 580);
            ball = new Ball();

            Rectangle recthole = new Rectangle(hole.GetX(), hole.GetY(), 15, 15);
            Rectangle rectball = new Rectangle(ball.GetX(), ball.GetY(), 12, 12);
            gr.FillEllipse(Brushes.Black, recthole);
            gr.FillEllipse(Brushes.White, rectball);
            last_ball = rectball;
            put.Image = bm;
            this.Refresh();
            Thread server = new Thread(new ThreadStart(StartServer));
            server.Start();
        }

        private void shot(object sender, EventArgs e)
        {
            if (win == true)
            {
                return;
            }
            if (ball.Playing == false)
            {
                int valor = int.Parse(force.Text);
                ball.Force = valor;
                ball.Angle = int.Parse(angle.Text);
                mover.Enabled = true;
                startTime = DateTime.Now;
            }
        }

        private void moveball(object sender, EventArgs e)
        {
            if (ball.Move() == false)
            {
                mover.Enabled = false;
                Graphics gr = Graphics.FromImage(put.Image);
                Rectangle rect = new Rectangle(hole.GetX(), hole.GetY(), 15, 15);
                Rectangle rectball = new Rectangle(ball.GetX(), ball.GetY(), 12, 12);
                gr.FillEllipse(Brushes.Black, rect);
                gr.FillEllipse(Brushes.PaleGreen, last_ball);
                gr.FillEllipse(Brushes.White, rectball);
                last_ball = rectball;
                this.Refresh();
            }
            var lapsedTime = DateTime.Now.Subtract(startTime).TotalMilliseconds;
            if (lapsedTime > 40)
            {
                startTime = DateTime.Now;
                Graphics gr = Graphics.FromImage(put.Image);
                Rectangle recthole = new Rectangle(hole.GetX(), hole.GetY(), 15, 15);
                Rectangle rectball = new Rectangle(ball.GetX(), ball.GetY(), 12, 12);
                gr.FillEllipse(Brushes.Black, recthole);
                gr.FillEllipse(Brushes.PaleGreen, last_ball);
                gr.FillEllipse(Brushes.White, rectball);
                last_ball = rectball;
                this.Refresh();
            }
            int error_x = (ball.GetX() - hole.GetX());
            int error_y = (ball.GetY() - hole.GetY());
            if (0 < error_x && error_x < 4 && 0 < error_y && error_y < 4 && ball.Force < 20)
            {
                //didWin
                win = true;
                lbl_win.Text = "WIN!!";
            }
        }


        private void cmd_restart(object sender, EventArgs e)
        {
            lbl_win.Text = "";
            win = false;

            put.Image.Dispose();
            put.Image = null;

            hole.Delete();
            ball.Delete();

            Bitmap bm = new Bitmap(put.Width, put.Height);
            Graphics gr = Graphics.FromImage(bm);
            hole = new Hole(980, 580);
            ball = new Ball();

            Rectangle recthole = new Rectangle(hole.GetX(), hole.GetY(), 15, 15);
            Rectangle rectball = new Rectangle(ball.GetX(), ball.GetY(), 12, 12);
            gr.FillEllipse(Brushes.Black, recthole);
            gr.FillEllipse(Brushes.White, rectball);
            last_ball = rectball;
            put.Image = bm;
            this.Refresh();
        }

        public void StartServer()
        {

            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = host.AddressList[1];
            ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 51000);
            try
            {
                Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                listener.Bind(localEndPoint);
                listener.Listen(0);

                Socket handler = listener.Accept();

                byte[] bytes = null;
                while (true)
                {

                    bytes = new byte[64];
                    int bytesRec = handler.Receive(bytes);
                    if (bytesRec == 0)
                    {
                        break;
                    }
                    byte[] msg = Analizar(bytes);
                    handler.Send(msg);

                }

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        private byte[] Analizar(byte[] data)
        {
            byte[] resp = { 0x07, 0xff, 0x00, 0x00, 0x0a };
            if (data[0] != 0x06)
            {
                return resp;
            }
            byte command = (byte)(data[1]);
            switch (command)
            {
                case (byte)0x10:

                    break;

                case (byte)0x20:  //set force
                    //data = 0x06 0x20 [0...2000]=>byte2,byte3 0x0a
                    //
                    int valor = (int)((data[2] << 8) + data[3]);
                    if (valor >= 0 && valor <= 2000)
                    {
                        this.Invoke(new MethodInvoker(delegate
                        {
                            force.Text = valor.ToString();
                        }));
                        resp[2] = 0;
                        resp[3] = 0;
                        resp[1] = 0x00;
                    }
                    else
                    {

                    }
                    break;



                //0x06 0x30 0xNN 0xMM 0x0a
                case (byte)0x30:
                    int valordec = 0;
                    for (int i = 2; i < 4; i++)
                    {
                        //Conversion de bytes en INT
                        valordec = (int)((int)valordec << 8);
                        valordec |= (int)(data[i]);
                    }

                    this.Invoke(new MethodInvoker(delegate
                    {
                        progressBar1.Value = valordec;
                    }));

                    break;

                case (byte)0x40:
                    break;


                case (byte)0x50:

                    break;

                case (byte)0x60:
                    break;

            }

            return resp;
        }

    }
}
