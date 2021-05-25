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
    public partial class MasterProduct : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-6BBLR561;Initial Catalog=MyPractice;Integrated Security=True;");

        public MasterProduct()
        {
            InitializeComponent();
        }
        DataClasses1DataContext db = new DataClasses1DataContext();
        private void btnSave_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            string item = txtItem.Text;
            string design = txtDesign.Text;
            string color = cbColor.Text;
            DateTime expiredDate = DateTime.Parse(dateTimePicker1.Text);
            var data = new TB_M_PRODUCT
            {
                ID = id,
                itemName = item,
                color = color,
                design = design,
                expiredDate = expiredDate
            };
            db.TB_M_PRODUCTs.InsertOnSubmit(data);
            db.SubmitChanges();
            MessageBox.Show("Save Successfully");
            txtDesign.Clear();
            txtItem.Clear();
            cbColor.Items.Clear();
            LoadData();
        }

        void LoadData()
        {
            var st = from tb in db.TB_M_PRODUCTs select tb;
            dataGridView1.DataSource = st;
        }

        private void MasterProduct_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select isnull(max (cast (ID as int)), 0) +1 from TB_M_PRODUCT", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            txtID.Text = dt.Rows[0][0].ToString();
            LoadData();
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var st = from s in db.TB_M_PRODUCTs where s.itemName == txtSearchItemName.Text || s.design == txtSearchDesign.Text select s;
            dataGridView1.DataSource = st;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var delete = from s in db.TB_M_PRODUCTs where s.itemName == txtSearchItemName.Text select s;
            foreach (var t in delete)
            {
                db.TB_M_PRODUCTs.DeleteOnSubmit(t);
            }
            db.SubmitChanges();
            MessageBox.Show("Delete Succesfully");
            txtSearchDesign.Clear();
            txtSearchItemName.Clear();
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string item = txtItem.Text;
            string design = txtDesign.Text;
            string color = cbColor.Text;
            DateTime expiredDate = DateTime.Parse(dateTimePicker1.Text);

            var st = (from s in db.TB_M_PRODUCTs where s.ID == int.Parse(txtID.Text) select s).First();

            st.itemName = item;
            st.color = color;
            st.design = design;
            st.expiredDate = expiredDate;
            db.SubmitChanges();



            MessageBox.Show("Update Succesfuly");
            txtDesign.Clear();
            txtItem.Clear();
            cbColor.SelectedIndex = -1;
        }
    }
}
