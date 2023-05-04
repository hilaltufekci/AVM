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
    public partial class Musteriler : Form
    {
        public Musteriler()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-K4EVO3J; Initial Catalog=uygulamaAVM;Integrated Security=true;");
        public void Listeleme()
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "MusteriListele";

            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Listeleme();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "MusteriEkle";
            komut.Parameters.AddWithValue("MusteriAdi", textBox1.Text);
            komut.Parameters.AddWithValue("Telefon", textBox2.Text);
            komut.Parameters.AddWithValue("Adres", textBox3.Text);
            komut.Parameters.AddWithValue("Yas", textBox4.Text);
            komut.Parameters.AddWithValue("MagazaNo", textBox5.Text);
            komut.ExecuteNonQuery();
            con.Close();
            Listeleme();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow; //geçerli satırı al 
            textBox1.Tag = satir.Cells["MusteriNo"].Value.ToString();  // tag :gizli kalmasını istediği şeyleri
            textBox1.Text = satir.Cells["MusteriAdi"].Value.ToString();//seçtiğin satırın değerlerini yazdır
            textBox2.Text = satir.Cells["Telefon"].Value.ToString();
            textBox3.Text = satir.Cells["Adres"].Value.ToString();
            textBox4.Text = satir.Cells["Yas"].Value.ToString();
            textBox5.Text = satir.Cells["MagazaNo"].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "MusteriYenile";
            komut.Parameters.AddWithValue("MusteriNo", textBox1.Tag);
            komut.Parameters.AddWithValue("MusteriAdi", textBox1.Text);
            komut.Parameters.AddWithValue("Telefon", textBox2.Text);
            komut.Parameters.AddWithValue("Adres", textBox3.Text);
            komut.Parameters.AddWithValue("Yas", textBox4.Text);
            komut.Parameters.AddWithValue("MagazaNo", textBox5.Text);
            komut.ExecuteNonQuery();
            con.Close();
            Listeleme();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "MusteriSil";
            komut.Parameters.AddWithValue("MusteriNo", textBox1.Tag);
            komut.ExecuteNonQuery();
            con.Close();
            Listeleme();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Sekmeler go = new Sekmeler();
            go.Show();
            this.Hide();
        }
    }
}
