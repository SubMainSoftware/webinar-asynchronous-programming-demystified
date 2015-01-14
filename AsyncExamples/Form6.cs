using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncExamples
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        // Using Task.Run for fake-asynchronous code

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var length = await DownloadAsync(textBox1.Text);
                label1.Text = length.ToString();
            }
            catch (Exception ex)
            {
                label1.Text = "Error: " + ex;
            }
        }

        private Task<int> DownloadAsync(string url)
        {
            return Task.Run(() =>
            {
                using (var client = new WebClient())
                {
                    Thread.Sleep(2000);
                    var bytes = client.DownloadData(url);
                    return bytes.Length;
                }
            });
        }
    }
}
