using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyThongTin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=35-LAB402\MISASME2022;Initial Catalog=QLTT;Integrated Security=True;Encrypt=False");
        private void connectionOpen()
        {
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        private void connectionClosed()
        {
            if(con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        private Boolean Exe(string cmd)
        {
            connectionOpen();
            Boolean check;
            try
            {
                SqlCommand sc = new SqlCommand(cmd, con);
                sc.ExecuteNonQuery();
                check = true;
            }
            catch (Exception)
            {
                check = false;
                throw;
            }
            connectionClosed();
            return check;
        }
        private DataTable Red(string cmd)
        {
            connectionOpen();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sc = new SqlCommand(cmd, con);
                SqlDataAdapter sda = new SqlDataAdapter(sc);
                sda.Fill(dt);

            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            connectionClosed();
            return dt;
        }
        private void Load()
        {
            DataTable dt = new DataTable("SELECT * FORM quanlythongtin");
            if(dt != null)
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
