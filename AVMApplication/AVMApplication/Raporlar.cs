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
    public partial class Raporlar : Form
    {
        public Raporlar()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-K4EVO3J; Initial Catalog=uygulamaAVM;Integrated Security=true;");

        private void Raporlar_Load(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            button3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "MusteriSirala";
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "MasaSayisiSirala";
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Müşteri")
            {

                con.Open();
                SqlCommand komut = new SqlCommand();
                komut.Connection = con;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "MusteriAra";
                komut.Parameters.AddWithValue("MusteriAdi", textBox1.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();

            }
            else if (comboBox1.SelectedItem == "Mağaza")
            {

                con.Open();
                SqlCommand komut = new SqlCommand();
                komut.Connection = con;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "MagazaAra";
                komut.Parameters.AddWithValue("MagazaAdi", textBox1.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            else if (comboBox1.SelectedItem == "Yemek")
            {
                con.Open();
                SqlCommand komut = new SqlCommand();
                komut.Connection = con;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "YemekAra";
                komut.Parameters.AddWithValue("YemekAdi", textBox1.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Müşteri")
            {
                textBox1.Visible = true;
                button3.Visible = true;
            }
            else if (comboBox1.SelectedItem == "Mağaza")
            {
                textBox1.Visible = true;
                button3.Visible = true;
            }
            else if (comboBox1.SelectedItem == "Yemek")
            {
                textBox1.Visible = true;
                button3.Visible = true;
            }
        }
    }
}
