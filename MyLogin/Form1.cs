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

namespace MyLogin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataClasses1DataContext db = new DataClasses1DataContext();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var user = (from s in db.TB_M_USERs where s.Username == txtUsername.Text select s).First();
                if (user.password == txtPassword.Text)
                {
                    this.Hide();
                    MasterProduct a = new MasterProduct();
                    a.Show();
                }
                else
                {
                    MessageBox.Show("Password Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }
    }
}
