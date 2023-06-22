using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Activity_6_PABD
{
    public partial class Form2 : Form
    {
        private string stringConnection = "data source=LAPTOP-GK4TO82F\\CHENDY;" + "database=activity;User ID=sa; Password=123";
        private SqlConnection koneksi;


        public Form2()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();
        }

        private void refreshform()
        {
            nmp.Text = "";
            nmp.Enabled = false;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
        }
        private void dataGridView()
        {
            koneksi.Open();
            string str = "select nama_prodi from dbo.Prodi";
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView();
            btnOpen.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            refreshform();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nmp.Enabled = true;
            btnSave.Enabled = true;
            btnClear.Enabled = true;
        }
        static string GenerateRandomNonRepetitiveString(int size)
        {
            Random random = new Random();
            const string chars = "123456789abcdef";
            char[] hexChars = new char[size];

            for (int i = 0; i < size; i++)
            {
                hexChars[i] = chars[random.Next(chars.Length)];

            }

            return new string(hexChars);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string nmProdi = nmp.Text;
            if (nmProdi == "")
            {
                MessageBox.Show("Masukkan Nama Prodi", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                koneksi.Open();
                string randomCode = GenerateRandomNonRepetitiveString(5);

                string str = "INSERT INTO dbo.Prodi (id_prodi, nama_prodi)" + "VALUES(@randomcode, @namaProdi";
                using (SqlCommand command = new SqlCommand(str, koneksi))
                {
                    command.Parameters.Add("@randomcode", SqlDbType.VarChar).Value = randomCode;
                    command.Parameters.Add("@namaProdi", SqlDbType.VarChar).Value = nmProdi;
                    command.ExecuteNonQuery();
                }

                koneksi.Close();
                MessageBox.Show("Data Have been added", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView();
                refreshform();

            }
        }
        private void Form2_FormClosed()
        {
            Form1 hu = new Form1();
            hu.Show();
            this.Hide();
        }

        private void nmp_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
