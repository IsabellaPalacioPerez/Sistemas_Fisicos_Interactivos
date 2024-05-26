using System.Text;

namespace test_billar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void update_Tick(object sender, EventArgs e)
        {
            update_radios();
            update_progress();
        }


        void update_radios()
        {
            int valordec = 0;
            byte[] vect_dec = Encoding.ASCII.GetBytes(txt_radios.Text);
            for (int i = 0; i < vect_dec.Length; i++)
            {
                //Conversion de ASCII a decimal
                valordec *= 10;
                valordec += (int)(vect_dec[i] - 0x30);
            }

            //validar bit 0
            if ((valordec & 0b01) != 0)
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
            //validar bit 1
            if ((valordec & 0b010) != 0)
            {
                checkBox2.Checked = true;
            }
            else
            {
                checkBox2.Checked = false;
            }
            //validar bit 1
            if ((valordec & 0b0100) != 0)
            {
                checkBox3.Checked = true;
            }
            else
            {
                checkBox3.Checked = false;
            }
            if ((valordec & 0b01000) != 0)
            {
                checkBox4.Checked = true;
            }
            else
            {
                checkBox4.Checked = false;
            }
            if ((valordec & 0b010000) != 0)
            {
                checkBox5.Checked = true;
            }
            else
            {
                checkBox5.Checked = false;
            }
        }
        void update_progress()
        {
            int valordec = 0;
            byte[] vect_dec = Encoding.ASCII.GetBytes(txt_progress.Text);
            for (int i = 0; i < vect_dec.Length; i++)
            {
                //Conversion de ASCII a decimal
                valordec *= 10;
                valordec += (int)(vect_dec[i] - 0x30);
            }
            progressBar1.Value = valordec;
        }
    }
}