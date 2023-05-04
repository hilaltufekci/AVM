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

namespace AVMApplication
{
    public partial class KullaniciGiris : Form
    {
        public KullaniciGiris()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-K4EVO3J; Initial Catalog=uygulamaAVM;Integrated Security=true;");
        private void KullaniciGiris_Load(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "KullaniciGiris";
            komut.Parameters.AddWithValue("KullaniciAdi", textBox1.Text);
            komut.Parameters.AddWithValue("Sifre", textBox2.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Hoşgeldiniz.");
                Sekmeler go = new Sekmeler();
                go.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı.Tekrar deneyiniz.");
                textBox1.Clear();
                textBox2.Clear();
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sekmeler go = new Sekmeler();
            go.Show();
            this.Hide();
        }
    }
}
