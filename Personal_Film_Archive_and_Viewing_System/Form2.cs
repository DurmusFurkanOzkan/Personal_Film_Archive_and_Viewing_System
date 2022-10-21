using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Masaüstü_Kişisel_Film_Arşiv_ve_İzleme_Sistemi
{
    public partial class Form2 : Form
    {
        public string url;

        public Form2()
        {
            InitializeComponent();
        }

        

        private void Form2_Load(object sender, EventArgs e)
        {
            string html = "<html><head>";
            html += "<meta content='IE=Edge' http-equiv='X-UA-Compatible'/>";
            html += "<iframe id='video' src= 'https://www.youtube.com/embed/{0}' width='1920' height='1080' frameborder='0' allowfullscreen  </iframe>";
            html += "</head></html>";
            this.webBrowser3.DocumentText = string.Format(html, url.Split('=')[1]);
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
        }
    }
}
