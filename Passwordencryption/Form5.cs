using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Passwordencryption
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {


        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {


            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                byte[] key = new byte[32];
                randomNumberGenerator.GetBytes(key);
                textBox1.Text =BitConverter.ToString(key).Replace("*", "");

                using (var hmacsha1 = new HMACSHA1(key))
                {
                    byte[] hashmeHashed = hmacsha1.ComputeHash(Encoding.UTF8.GetBytes(textBox4.Text));
                    string result = BitConverter.ToString(hashmeHashed).Replace("*", "");
                    textBox2.Text =result;
                }
                using (var hmacmd5 = new HMACMD5(key))
                {
                    byte[] hashmeHashed = hmacmd5.ComputeHash(Encoding.UTF8.GetBytes(textBox4.Text));
                    string result = BitConverter.ToString(hashmeHashed).Replace("*", "");
                    textBox3.Text =result;
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
