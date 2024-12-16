using System;
using System.Net;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1a
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "http://localhost:777/SEK4";
            string postData = "x=" + textBoxX.Text + "&y=" + textBoxY.Text;
            byte[] postDataBytes = Encoding.UTF8.GetBytes(postData);

            WebClient client = new WebClient();
            client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            byte[] responseBytes = client.UploadData(url, "POST", postDataBytes); // отправляем пост-запрос и получаем ответ
            string responseString = Encoding.UTF8.GetString(responseBytes);

            textBoxEquals.Text = responseString;
        }
    }
}
