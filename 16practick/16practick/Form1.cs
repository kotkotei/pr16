using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.IO;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace _16practick
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // создаем новый объект Ping для отправки запросов
                Ping ping = new Ping();

                // получаем IP-адрес, который нужно проверить
                string ip = textBox1.Text;

                // отправляем 4 запроса и ждем ответа в течение 1 секунды
                PingReply reply = ping.Send(ip, 1000, new byte[32], new PingOptions(4, true));

                // выводим результаты пинга в текстовое поле
                textBox2.Text = $"Адрес: {ip} \r\n";
                textBox2.AppendText($"Задержка: {reply.RoundtripTime} мс \r\n");
                textBox2.AppendText($"Статус: {reply.Status} \r\n");

                //textBox2.Text = $"Time to live: {reply.Options.Ttl} ms \r\n";
                ////textBox2.AppendText($"Don't fragment: { reply.Options.DontFragment} ms \r\n");
                ////textBox2.AppendText($"Buffer size: {reply.Buffer.Length} ms \r\n");

            }
            catch (PingException ex)
            {
                // если ошибка пинга, выводим сообщение об ошибке
                MessageBox.Show($"Ошибка пинга: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Files (.txt)|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, textBox2.Text);
            }
        }
    }
}
