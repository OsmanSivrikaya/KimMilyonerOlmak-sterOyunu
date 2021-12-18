using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace kimmilyonerolmakister
{
    public partial class Form1 : Form
    {

        SqlConnection baglan = new SqlConnection("Data Source=.;Initial Catalog=QuizDB;Trusted_Connection=True");

        public Form1()
        {
            InitializeComponent();
        }
        //int[] sayilar = new int[16];
        //Random r = new Random();
        //int i = 0;
        //public void random()
        //{
           

        //    while (i < 16)
        //    {
        //        int sayi = r.Next(1, 16);
        //        if (sayilar.Contains(sayi))
        //            continue;
        //        sayilar[i] = sayi;

        //        i++;
        //    }
        //    Array.Sort(sayilar);

            
        //}
        
        public void soru()
        {
           
            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT QText FROM Questions where QID = @QID", baglan);
            komut.Parameters.AddWithValue("QID", sayi1);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                btnsoru.Text = (oku["QText"].ToString());
            }
            oku.Close();

            SqlCommand komut2 = new SqlCommand("SELECT AText FROM Answers where QID = @QID order by QID ", baglan);
            komut2.Parameters.AddWithValue("QID", sayi1);
            SqlDataAdapter oku2 = new SqlDataAdapter();
            oku2.SelectCommand = komut2;
            DataTable dt = new DataTable();
            oku2.Fill(dt);

            button1.Text = (dt.Rows[0][0].ToString());
            button2.Text = (dt.Rows[1][0].ToString());
            button3.Text = (dt.Rows[2][0].ToString());
            button4.Text = (dt.Rows[3][0].ToString());
            baglan.Close();
        }
        int sayi1 = 0;
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public string cevap;
        public void dogrucevap()
        {
            SqlCommand komut3 = new SqlCommand("SELECT RightAnswers.QID,Answers.AText FROM RightAnswers join Answers on RightAnswers.AID = Answers.AID where RightAnswers.QID=@QID", baglan);
            komut3.Parameters.AddWithValue("QID", sayi1);
            baglan.Open();
            SqlDataReader oku3 = komut3.ExecuteReader();

            while (oku3.Read())
            {
                cevap = (oku3["AText"].ToString());
            }
            oku3.Close();
            baglan.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dogrucevap();
            DialogResult karar2;
            DialogResult karar;
            karar = MessageBox.Show("Son Kararın Mı ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            dogrucevap();
            if (karar == DialogResult.Yes)
            {
                if (cevap == button2.Text)
                {
                    timer1.Stop();
                    button2.BackColor = Color.Green;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button1.Enabled = false;
                    button5.Enabled = true;


                }
                else
                {
                    karar2 = MessageBox.Show("Soruyu Yanlış Yanıtladığınız İçin Elendiniz Ödülünüz 0TL\nTekar Oynamak İster misiniz?", "ELENDİNİZ", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (karar2 == DialogResult.Yes)
                    {
                        Application.Restart();
                    }
                    else
                    {
                        Application.Exit();
                    }

                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult karar2;
            DialogResult karar;
            karar = MessageBox.Show("Son Kararın Mı ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            dogrucevap();
            if (karar == DialogResult.Yes)
            {
                dogrucevap();
                if (cevap == button1.Text)
                {
                    timer1.Stop();
                    button1.BackColor = Color.Green;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button5.Enabled = true;
                }
                else
                {
                    karar2 = MessageBox.Show("Soruyu Yanlış Yanıtladığınız İçin Elendiniz Ödülünüz 0TL\nTekar Oynamak İster misiniz?", "ELENDİNİZ", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (karar2 == DialogResult.Yes)
                    {
                        Application.Restart();
                    }
                    else
                    {
                        Application.Exit();
                    }

                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult karar2;
            DialogResult karar;
            karar = MessageBox.Show("Son Kararın Mı ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            dogrucevap();
            if (karar == DialogResult.Yes)
            {
                dogrucevap();
                if (cevap == button4.Text)
                {
                    timer1.Stop();
                    button4.BackColor = Color.Green;
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button5.Enabled = true;


                }
                else
                {
                    karar2 = MessageBox.Show("Soruyu Yanlış Yanıtladığınız İçin Elendiniz Ödülünüz 0TL\nTekar Oynamak İster misiniz?", "ELENDİNİZ", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (karar2 == DialogResult.Yes)
                    {
                        Application.Restart();
                    }
                    else
                    {
                        Application.Exit();
                    }

                }

            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult karar2;
            DialogResult karar;
            karar = MessageBox.Show("Son Kararın Mı ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            dogrucevap();
            if (karar == DialogResult.Yes)
            {
                if (cevap == button3.Text)
                {
                    timer1.Stop();
                    button3.BackColor = Color.Green;
                    button1.Enabled = false;
                    button4.Enabled = false;
                    button2.Enabled = false;
                    button5.Enabled = true;
                }
                else
                {
                    karar2 = MessageBox.Show("Soruyu Yanlış Yanıtladığınız İçin Elendiniz Ödülünüz 0TL\nTekar Oynamak İster misiniz?", "ELENDİNİZ", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (karar2 == DialogResult.Yes)
                    {
                        Application.Restart();
                    }
                    else
                    {
                        Application.Exit();
                    }

                }
            }



        }
        public void buttonOzellik()
        {
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
            button4.BackColor = Color.White;
            button1.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button2.Enabled = true;
            button5.Enabled = false;
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            sayi1++;

            if (sayi1 == 1)
            {
                timer1.Start();
                soru();
                button5.Text = "SONRAKİ SORU GELSİN";
                button5.Enabled = false;
                button6.Text = "ÖDÜL: 0";

            }
            else if (sayi1 == 2)
            {
                sayac = 0;
                timer1.Start();
                buttonOzellik();
                soru();
                button6.Text = "ÖDÜL: 1000";
            }
            else if (sayi1 == 3)
            {
                sayac = 0;
                timer1.Start();
                buttonOzellik();
                soru();
                button6.Text = "ÖDÜL: 2000";
            }
            else if (sayi1 == 4)
            {
                sayac = 0;
                timer1.Start();
                buttonOzellik();
                button6.Text = "ÖDÜL: 3000";
                soru();
            }
            else if (sayi1 == 5)
            {
                sayac = 0;
                timer1.Start();
                buttonOzellik();
                soru();
                button6.Text = "ÖDÜL: 5000";
            }
            else if (sayi1 == 6)
            {
                sayac = 0;
                timer1.Start();
                buttonOzellik();
                soru();
                button6.Text = "ÖDÜL: 7500";
            }
            else if (sayi1 == 7)
            {
                sayac = 0;
                timer1.Start();
                buttonOzellik();
                soru();
                button6.Text = "ÖDÜL: 10000";
            }
            else if (sayi1 == 8)
            {
                sayac = 0;
                timer1.Start();
                buttonOzellik();
                soru();
                button6.Text = "ÖDÜL: 30000";
            }
            else if (sayi1 == 9)
            {
                buttonOzellik();
                soru();
                button6.Text = "ÖDÜL: 50000";
            }
            else if (sayi1 == 10)
            {
                buttonOzellik();
                soru();
                button6.Text = "ÖDÜL: 100000";
            }
            else if (sayi1 == 11)
            {
                buttonOzellik();
                soru();
                button6.Text = "ÖDÜL: 200000";
            }
            else if (sayi1 == 12)
            {
                buttonOzellik();
                soru();
                string odul = button6.Text = "ÖDÜL: 300000";
            }
            else if (sayi1 == 13)
            {
                buttonOzellik();
                soru();
                button6.Text = "ÖDÜL: 400000";
            }
            else if (sayi1 == 14)
            {
                buttonOzellik();
                soru();
                button6.Text = "ÖDÜL: 500000";
            }
            else if (sayi1 == 15)
            {
                buttonOzellik();
                soru();
                button6.Text = "ÖDÜL: 600000";
            }
            else if (sayi1 == 16)
            {
                buttonOzellik();
                soru();
                button6.Text = "ÖDÜL: 1000000";
            }




        }
        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sayac == 150)
            {
                timer1.Stop();
                MessageBox.Show("SORUYU ZAMANINDA CEVAPLAYAMADINIZ");
                this.Close();
                FormMain frmmain = new FormMain();
                frmmain.ShowDialog();

            }
            progressBar1.Value = sayac;
            sayac++;

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
