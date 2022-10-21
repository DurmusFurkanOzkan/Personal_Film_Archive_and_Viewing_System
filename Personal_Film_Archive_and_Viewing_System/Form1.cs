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
using System.Diagnostics;
using CefSharp.WinForms;


namespace Masaüstü_Kişisel_Film_Arşiv_ve_İzleme_Sistemi
{
    public partial class Form1 : Form
    {
        string url;
        ChromiumWebBrowser chrome;
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-48MHJFV;Initial Catalog=FilmArsivi;Integrated Security=True");
        void Film_göster()
        {
            SqlDataAdapter dr = new SqlDataAdapter("Select * From Filmler",baglanti);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Film_göster();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand command = new SqlCommand("insert into Filmler (Adı,Kategori,Link) values (@P1,@P2,@P3)", baglanti);
            command.Parameters.AddWithValue("@P1", txt_filmadi.Text);
            command.Parameters.AddWithValue("@P2", txt_kategori.Text);
            command.Parameters.AddWithValue("@P3", txt_link.Text);
            command.ExecuteNonQuery();
            baglanti.Close();
            Film_göster();
        }
        
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int cellInfo = dataGridView1.SelectedCells[0].RowIndex;
            url = dataGridView1.Rows[cellInfo].Cells[3].Value.ToString();
            string html = "<html><head>";
            html += "<meta content='IE=Edge' http-equiv='X-UA-Compatible'/>";
            html += "<iframe id='video' src= 'https://www.youtube.com/embed/{0}' width='600' height='400' frameborder='0' allowfullscreen  </iframe>";
            html += "</head></html>";
            this.webBrowser1.DocumentText = string.Format(html, url.Split('=')[1]);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This software is created by Durmus Furkan Ozkan","Hakkımızda");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int num1;
            int num2;
            int num3;
            num1 = rnd.Next(0, 255);
            num2 = rnd.Next(0, 255);
            num3 = rnd.Next(0, 255);
            this.BackColor = Color.FromArgb(num1, num2, num3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.url = url;
            frm2.Show();
            

        }
    }
}
