using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncExamples
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        // Using ContinueWith instead of await

        private void button1_Click(object sender, EventArgs e)
        {
            var uiTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            var downloadTask = DownloadAsync(textBox1.Text);
            downloadTask.ContinueWith(t =>
            {
                var length = t.Result;
                label1.Text = length.ToString();
            }, CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, uiTaskScheduler);
            downloadTask.ContinueWith(t =>
            {
                label1.Text = "Error: " + t.Exception.InnerException;
            }, CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, uiTaskScheduler);
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
