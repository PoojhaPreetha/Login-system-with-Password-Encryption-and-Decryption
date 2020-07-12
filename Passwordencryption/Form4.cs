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
    public partial class Form4 : Form

    {

        string cipherData;
        byte[] cipherbytes;
        byte[] plainbytes;
        byte[] plainbytes2;
        byte[] plainKey;


        SymmetricAlgorithm desObj;
        public Form4()
        {
            InitializeComponent();
            desObj = Rijndael.Create();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            cipherData = textBox_Plain_text.Text;
            plainbytes = Encoding.ASCII.GetBytes(cipherData);
            plainKey = Encoding.ASCII.GetBytes("0123456789abcdef");
            desObj.Key = plainKey;
            desObj.Mode = CipherMode.CBC;
            desObj.Padding = PaddingMode.PKCS7;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, desObj.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(plainbytes, 0, plainbytes.Length);
            cs.Close();
            cipherbytes = ms.ToArray();
            ms.Close();
            textBox_Encrypted_text.Text = Encoding.ASCII.GetString(cipherbytes);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            System.IO.MemoryStream ms1 = new System.IO.MemoryStream(cipherbytes);
            CryptoStream cs1 = new CryptoStream(ms1, desObj.CreateDecryptor(), CryptoStreamMode.Read);
            cs1.Read(cipherbytes, 0, cipherbytes.Length);
            plainbytes2 = ms1.ToArray();
            cs1.Close();
            ms1.Close();
            textBox_decrypted_text.Text = Encoding.ASCII.GetString(plainbytes2);
        }
    }
}
