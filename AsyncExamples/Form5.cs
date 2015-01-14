using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncExamples
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        // Async code calling a blocking method

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

        private async Task<int> DownloadAsync(string url)
        {
            using (var client = new WebClient())
            {
                await Task.Delay(1000);
                Thread.Sleep(1000);
                var bytes = client.DownloadData(url);
                //var bytes = await client.DownloadDataTaskAsync(url);
                return bytes.Length;
            }
        }
    }
}
