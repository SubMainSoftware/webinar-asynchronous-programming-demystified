using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncExamples
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        // Improper use of async void

        private int _byteCount;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Download(textBox1.Text);
                label1.Text = _byteCount.ToString();
            }
            catch (Exception ex)
            {
                label1.Text = "Error: " + ex;
            }
        }

        private async void Download(string url)
        {
            using (var client = new HttpClient())
            {
                await Task.Delay(2000);
                var bytes = await client.GetByteArrayAsync(url);
                _byteCount = bytes.Length;
            }
        }
    }
}
