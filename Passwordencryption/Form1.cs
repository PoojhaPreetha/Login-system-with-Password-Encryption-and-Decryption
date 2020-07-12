using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AesEncDec;
using System.IO;

namespace Passwordencryption
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public String md5hash(byte[] val)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(val);
                return Convert.ToBase64String(hash);
            }
        }

        public string MD5hash(byte[] value)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                var hash = md5.ComputeHash(value);
                return Convert.ToBase64String(hash);
            }
        }
        private void Password_TextChanged(object sender, EventArgs e)
        {
            byte[] passtohash = System.Text.Encoding.UTF8.GetBytes(password.Text.ToString());
            hashed.Text = md5hash(passtohash);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
             if (username.Text.Length < 3 || password.Text.Length < 5)
            {
                MessageBox.Show("Username or password is too short");
            }
            else
            {
                string dir = username.Text;
                if (!Directory.Exists("data\\" + dir))
                    MessageBox.Show("User wasn't found", dir);
                else
                    {
               var sr = new StreamReader("data\\" + dir + "\\data.ls");
                    string encusr = sr.ReadLine();
                    string encpass = sr.ReadLine();
                    sr.Close();

                    string decusr = AesCryp.Decrypt(encusr);
                    string decpass = AesCryp.Decrypt(encpass);

                    if (decusr == username.Text && decpass == password.Text)
                        { MessageBox.Show("Welcome to private area" , decusr);
                        Form3 po = new Form3();
                        po.Show();

                    }
                    else
                    { MessageBox.Show("Error. User or password is wrong");
}

                    }
               
            }
           
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Regform rf = new Regform();
            rf.Show();
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
