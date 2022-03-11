using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AESNEW
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string password;
        private void button2_Click(object sender, EventArgs e)
        {
            password = textBox1.Text;
            string encm = Encriptor.Encript(richTextBox1.Text);
            System.IO.File.WriteAllText(@"C:\Demo\private.txt", encm);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(@"C:\Demo\private.txt");
            string line = sr.ReadLine();

            richTextBox1.Text = Encriptor.Decrypte(Convert.ToString(line));

        }
        public static string verify;
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            verify = textBox2.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            password = textBox1.Text;
        }
    }
}
