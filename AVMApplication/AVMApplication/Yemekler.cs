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
    public partial class Yemekler : Form
    {
        public Yemekler()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-K4EVO3J; Initial Catalog=uygulamaAVM;Integrated Security=true;");
        public void Listeleme()
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "YemekListele";

            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listeleme();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "YemekEkle";
            komut.Parameters.AddWithValue("YemekTuru", comboBox2.Text);
            komut.Parameters.AddWithValue("YemekAdi", comboBox1.Text);
            komut.Parameters.AddWithValue("Fiyat", textBox3.Text);
            komut.Parameters.AddWithValue("Adet", textBox4.Text);
            komut.Parameters.AddWithValue("MusteriNo", textBox5.Text);
            komut.ExecuteNonQuery();
            con.Close();
            Listeleme();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "YemekYenile";
            komut.Parameters.AddWithValue("YemekNo", textBox4.Tag);
            komut.Parameters.AddWithValue("YemekTuru", comboBox2.Text);
            komut.Parameters.AddWithValue("YemekAdi", comboBox1.Text);
            komut.Parameters.AddWithValue("Fiyat", textBox3.Text);
            komut.Parameters.AddWithValue("Adet", textBox4.Text);
            komut.Parameters.AddWithValue("MusteriNo", textBox5.Text);
            komut.ExecuteNonQuery();
            con.Close();
            Listeleme();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "YemekSil";
            komut.Parameters.AddWithValue("YemekNo", textBox4.Tag);
            komut.ExecuteNonQuery();
            con.Close();
            Listeleme();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow; //geçerli satırı al 
            textBox4.Tag = satir.Cells["YemekNo"].Value.ToString();  // tag :gizli kalmasını istediği şeyleri
            comboBox2.Text = satir.Cells["YemekTuru"].Value.ToString();//seçtiğin satırın değerlerini yazdır
            comboBox1.Text = satir.Cells["YemekAdi"].Value.ToString();
            textBox3.Text = satir.Cells["Fiyat"].Value.ToString();
            textBox4.Text = satir.Cells["Adet"].Value.ToString();
            textBox5.Text = satir.Cells["MusteriNo"].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Sekmeler go = new Sekmeler();
            go.Show();
            this.Hide();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == "Yiyecek")
            {
                comboBox1.Visible = true;
                comboBox3.Visible = false;
            }
            else if (comboBox2.SelectedItem == "İçecek")
            {
                comboBox3.Visible = true;
                comboBox1.Visible = false;

            }
        }

        private void Yemekler_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem == "Latte")
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = true;
                pictureBox5.Visible = false;

            }

            else if (comboBox3.SelectedItem == "Filtre Kahve")
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = true;

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Döner")
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;

            }

            else if (comboBox1.SelectedItem == "Pizza")
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;

            }

            else if (comboBox1.SelectedItem == "Hamburger")
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = true;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;


            }
        }
    }
}
