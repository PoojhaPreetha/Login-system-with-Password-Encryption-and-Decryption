using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AesEncDec;
using System.IO;

namespace Passwordencryption
{
    public partial class Regform : Form
    {
        public Regform()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (usrTxt.Text.Length < 3 || passTxt.Text.Length < 5)
            {
                MessageBox.Show("Username or password is too short");
            }
            else
            {
                string dir = usrTxt.Text;
                Directory.CreateDirectory("data\\" + dir);

                var sw = new StreamWriter("data\\" + dir + "\\data.ls");

                string encusr = AesCryp.Encrypt(usrTxt.Text);

                string encpass = AesCryp.Encrypt(passTxt.Text);

                sw.WriteLine(encusr);
                sw.WriteLine(encpass);
                sw.Close();

                MessageBox.Show("User was succesfully created", usrTxt.Text);
                this.Close();
            }
        }
    }
}
