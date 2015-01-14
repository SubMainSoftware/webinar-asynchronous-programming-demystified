using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncExamples
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        // Blocking on async code

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var length = DownloadAsync(textBox1.Text).Result;
                label1.Text = length.ToString();
            }
            catch (Exception ex)
            {
                label1.Text = "Error: " + ex;
            }
        }

        private async Task<int> DownloadAsync(string url)
        {
            using (var client = new HttpClient())
            {
                await Task.Delay(2000);
                var bytes = await client.GetByteArrayAsync(url);
                return bytes.Length;
            }
        }
    }
}
