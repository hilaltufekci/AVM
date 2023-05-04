using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AVMApplication
{
    public partial class Sekmeler : Form
    {
        public Sekmeler()
        {
            InitializeComponent();
        }

        private void BtnMagaza_Click(object sender, EventArgs e)
        {
            Magaza go = new Magaza();
            go.Show();
            this.Hide();
        }

        private void BtnYemek_Click(object sender, EventArgs e)
        {
            Yemekler go = new Yemekler();
            go.Show();
            this.Hide();
        }

        private void BtnMüsteri_Click(object sender, EventArgs e)
        {
            Musteriler go = new Musteriler();
            go.Show();
            this.Hide();
        }

        private void BtnRapor_Click(object sender, EventArgs e)
        {
            Raporlar go = new Raporlar();
            go.Show();
            this.Hide();
        }
    }
}
