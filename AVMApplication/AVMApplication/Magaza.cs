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
    public partial class Magaza : Form
    {
        public Magaza()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-K4EVO3J; Initial Catalog=uygulamaAVM;Integrated Security=true;");

        public void Listeleme()
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "MagazaListele";

            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            dataGridView1.DataSource = dt;
        }

       

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Sekmeler go = new Sekmeler();
            go.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Listeleme();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "MagazaEkle";
            komut.Parameters.AddWithValue("MagazaAdi", textBox1.Text);
            komut.Parameters.AddWithValue("KatNo", textBox2.Text);
            komut.Parameters.AddWithValue("MasaSayisi", textBox3.Text);
            komut.Parameters.AddWithValue("CalisanSayisi", textBox4.Text);
            komut.ExecuteNonQuery();
            con.Close();
            Listeleme();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "MagazaYenile";
            komut.Parameters.AddWithValue("MagazaNo", textBox1.Tag);
            komut.Parameters.AddWithValue("MagazaAdi", textBox1.Text);
            komut.Parameters.AddWithValue("KatNo", textBox2.Text);
            komut.Parameters.AddWithValue("MasaSayisi", textBox3.Text);
            komut.Parameters.AddWithValue("CalisanSayisi", textBox4.Text);
            komut.ExecuteNonQuery();
            con.Close();
            Listeleme();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "MagazaSil";
            komut.Parameters.AddWithValue("MagazaNo", textBox1.Tag);
            komut.ExecuteNonQuery();
            con.Close();
            Listeleme();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow; //geçerli satırı al 
            textBox1.Tag = satir.Cells["MagazaNo"].Value.ToString();  // tag :gizli kalmasını istediği şeyleri
            textBox1.Text = satir.Cells["MagazaAdi"].Value.ToString();//seçtiğin satırın değerlerini yazdır
            textBox2.Text = satir.Cells["KatNo"].Value.ToString();
            textBox3.Text = satir.Cells["MasaSayisi"].Value.ToString();
            textBox4.Text = satir.Cells["CalisanSayisi"].Value.ToString();
        }
    }
}
