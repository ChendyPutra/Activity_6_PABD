using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Activity_6_PABD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 fm = new Form2();
            fm.Show();
            this.Hide();
        }
        

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void bnMahasiswa_Click(object sender, EventArgs e)
        {
            Form3 fmx = new Form3();
            fmx.Show();
            this.Hide();
        }

        private void dataStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 fmt = new Form4();
            fmt.Show();
            this.Hide();
        }
    }
}
