using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Passwordencryption;
using System.IO;
namespace Passwordencryption
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "SHA256":
                    textBox2.Text = Hashing.ComputeHash(textBox1.Text, Supported_HA.SHA256, null);
                    break;
                case "SHA384":
                    textBox2.Text = Hashing.ComputeHash(textBox1.Text, Supported_HA.SHA384, null);
                    break;
                case "SHA512":
                    textBox2.Text = Hashing.ComputeHash(textBox1.Text, Supported_HA.SHA512, null);
                    break;
            }
        }


        private void Button3_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "SHA256":
                    label4.Text = (Hashing.Confirm(textBox1.Text, textBox2.Text, Supported_HA.SHA256)) ? "Status: Correct" : "Status: Incorrect";
                    break;
                case "SHA384":
                    label4.Text = (Hashing.Confirm(textBox1.Text, textBox2.Text, Supported_HA.SHA384)) ? "Status: Correct" : "Status: Incorrect";
                    break;
                case "SHA512":
                    label4.Text = (Hashing.Confirm(textBox1.Text, textBox2.Text, Supported_HA.SHA512)) ? "Status: Correct" : "Status: Incorrect";
                    break;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
