using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Passwordencryption
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form2 po = new Form2();
            po.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form4 po = new Form4();
            po.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Form5 ui = new Form5();
            ui.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
