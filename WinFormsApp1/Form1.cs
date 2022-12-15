using System;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        string text;
        int delay = 0;
        Random r = new Random();
        int fast;
        string encoded;
        string decode;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           text = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(text);
            
            Thread.Sleep(delay);
            char[] b = text.ToArray();
            for (int i = 0; i < b.Length; i++) {
                if (!checkBox1.Checked) { 
                    int rInt = r.Next(3, 7) * 100;
                    System.Threading.Thread.Sleep(rInt);
                }
            SendKeys.Send(Char.ToString(b[i]));
        }
            
        }

  
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clear");
            textBox1.Text = "";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            delay = (int)numericUpDown1.Value;

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            openFileDialog1.ShowDialog();
            string path = openFileDialog1.FileName;

            Byte[] bytes = File.ReadAllBytes(path);
            String file = Convert.ToBase64String(bytes);
            textBox1.Text = file;
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
             
            encoded = EncodeTo64(text);
            textBox1.Text = encoded;

        }
        private string EncodeTo64(string toEncode)

        {

            byte[] toEncodeAsBytes

                  = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);

            string returnValue

                  = System.Convert.ToBase64String(toEncodeAsBytes);

            return returnValue;

        }
        private string DecodeFrom64(string encodedData)

        {

            byte[] encodedDataAsBytes

                = System.Convert.FromBase64String(encodedData);

            string returnValue =

               System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);

            return returnValue;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            decode = DecodeFrom64(text);
            textBox1.Text = decode;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
        
    }
