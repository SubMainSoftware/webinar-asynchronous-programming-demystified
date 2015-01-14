using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncExamples
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        // Correct approach using IProgress<T>

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var progress = new Progress<int>(update => { label1.Text = update.ToString(); });
                await DownloadAsync(textBox1.Text, progress);
            }
            catch (Exception ex)
            {
                label1.Text = "Error: " + ex;
            }
        }

        private async Task DownloadAsync(string url, IProgress<int> progress)
        {
            using (var client = new HttpClient())
            {
                await Task.Delay(2000);
                var bytes = await client.GetByteArrayAsync(url);
                if (progress != null)
                    progress.Report(bytes.Length);
            }
        }
    }
}
