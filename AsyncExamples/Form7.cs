using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncExamples
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        // Using Invoke instead of IProgress<T> for progress updates.

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                await DownloadAsync(textBox1.Text);
            }
            catch (Exception ex)
            {
                label1.Text = "Error: " + ex;
            }
        }

        private async Task DownloadAsync(string url)
        {
            using (var client = new HttpClient())
            {
                await Task.Delay(2000);
                var bytes = await client.GetByteArrayAsync(url);
                label1.Invoke((Action)(() => label1.Text = bytes.Length.ToString()));
            }
        }
    }
}
