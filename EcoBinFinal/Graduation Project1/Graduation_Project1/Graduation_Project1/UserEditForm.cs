using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graduation_Project1
{
    public partial class UserEditForm : Form
    {
        DataBase db = new DataBase();
        public UserEditForm()
        {
            InitializeComponent();
        }
        //tüm kullanıcıları listeleme methodu  (TAMAMLANDI)
        void listDb(string query = "SELECT * FROM admins")
        {
            using (var con = db.connection())
            {
                using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, con))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    gridControl1.DataSource = ds.Tables[0];
                }
            }
        }
        private void UserEditForm_Load(object sender, EventArgs e)
        {
            listDb();
        }
        //seçilen verinin textboxlarda gözükmesi
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtUserID.Text = dr["Id"]?.ToString() ?? "";
            txtUserName.Text = dr["username"]?.ToString() ?? "";
            txtUserPassword.Text = dr["password"]?.ToString() ?? "";
            txtCity.Text = dr["city"]?.ToString()??"";
            txtDistrict.Text = dr["district"]?.ToString() ?? "";


            bool selectedValue = Convert.ToBoolean(dr["is_superadmin"]); // Veritabanından "is_superadmin" sütunu

            if (selectedValue)//admin
            {
                radioGroup1.SelectedIndex = 0;                
            }
            else //user
            {
                radioGroup1.SelectedIndex = 2;               
            }
           
        }
        //kullanıcı ekleme
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "INSERT INTO admins (username, password, is_superadmin, city, district) " +
               "VALUES (@username, @password, @is_superadmin, @city, @district)";
                using (var con = db.connection())
                {
                    using (var comAdd = new NpgsqlCommand(query, con))
                    {
                        LoginForm frmlog = new LoginForm();
                        bool isSuperAdmin = radioGroup1.SelectedIndex == 0; // 0 = Admin, 1 = User
                        comAdd.Parameters.AddWithValue("@username", txtUserName.Text);
                        comAdd.Parameters.AddWithValue("@password", txtUserPassword.Text);
                        comAdd.Parameters.AddWithValue("@city", txtCity.Text);
                        comAdd.Parameters.AddWithValue("@district", txtDistrict.Text);
                        comAdd.Parameters.AddWithValue("@is_superadmin", isSuperAdmin);

                        comAdd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("ADD PROCESS SUCCESSFULL");
                listDb();
            }
            catch (Exception)
            {

                MessageBox.Show("This Member Allready Exist");
            }
            
        }
        //kullanıcı düzenleme
        private void btnEditUser_Click(object sender, EventArgs e)
        {
           
                string query = "UPDATE admins SET username = @username, password = @password, is_superadmin = @is_superadmin, " +
                               "city = @city, district = @district WHERE \"Id\"= @ID";
                string ids = txtUserID.Text.ToString();
                int idint = int.Parse(ids);


                using (var con = db.connection())
                {
                    using (var comEdit = new NpgsqlCommand(query, con))
                    {
                        
                        bool isSuperAdmin = radioGroup1.SelectedIndex == 0; // 0 = Admin, 1 = User
                          // Parametreleri ekle
                        comEdit.Parameters.AddWithValue("@ID",idint);
                        comEdit.Parameters.AddWithValue("@username", txtUserName.Text);
                        comEdit.Parameters.AddWithValue("@password", txtUserPassword.Text);
                        comEdit.Parameters.AddWithValue("@city", txtCity.Text);
                        comEdit.Parameters.AddWithValue("@district", txtDistrict.Text);

                        // is_superadmin radio button kontrolünden alınacak
                       
                        comEdit.Parameters.AddWithValue("@is_superadmin", isSuperAdmin);

                        // Sorguyu çalıştır
                        comEdit.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("EDIT PROCESS SUCCESSFUL");
                listDb(); // Veritabanını yenilemek için çağrılan metot
        }
        //kullanıcı silme 
        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM admins WHERE \"Id\" = @id";// id yi bu şekilde yazmazsak hata aldık
            using (var con = db.connection())
            {
                using (var comDelete = new NpgsqlCommand(query, con))
                {
                    int id = int.Parse(txtUserID.Text);
                    comDelete.Parameters.AddWithValue("@id", id);
                    comDelete.ExecuteNonQuery();
                }
            }
            MessageBox.Show("DELETE PROCESS SUCCESSFULL");
            listDb();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHomePage_Click(object sender, EventArgs e)
        {
            HomeForm hfrm = new HomeForm();
            hfrm.Show();
            this.Hide();
        }
    }
    
}
