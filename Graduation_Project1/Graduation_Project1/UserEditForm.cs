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
        void listDb(string query = "SELECT * FROM boxes1")
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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtUserID.Text = dr["ID"]?.ToString() ?? "";//bunu yunusla konuşacaz id yaparız
            txtUserName.Text = dr["username"]?.ToString() ?? "";
            txtUserPassword.Text = dr["password"]?.ToString() ?? "";
            
            var selectedValue = dr["is_superadmin"]?.ToString(); // Veritabanından "decision" sütunu

            if (selectedValue == "Donation")
            {
                radioGroup1.SelectedIndex = 0; // admin
                
            }
            else if (selectedValue == "Recycle")
            {
                radioGroup1.SelectedIndex = 1; // user seçili
                
            }
            else
            {
                radioGroup1.SelectedIndex = -1; // hiçbir şey seçili değil
                
            }
        }
        //kullanıcı ekleme
        private void btnAddUser_Click(object sender, EventArgs e)
        {  //yunusla database düzeltilecek ıd kısmı için
            string query = "INSERT INTO admins (ID, username, password, is_superadmin, city, district,) " +
                  "VALUES (@ID, @username, @password, @is_superadmin, @city, @district)";//yunusla database düzeltilecek
            using (var con = db.connection())
            {
                using (var comAdd = new NpgsqlCommand(query, con))
                {
                    // Parametreleri ekle
                    comAdd.Parameters.AddWithValue("@ID", txtUserID.Text);
                    comAdd.Parameters.AddWithValue("@username", txtUserName.Text);
                    comAdd.Parameters.AddWithValue("@password", txtUserPassword.Text);        
                    comAdd.Parameters.AddWithValue("@city", txtCity.Text); // int değer
                    comAdd.Parameters.AddWithValue("@district", txtDistrict.Text);

                    comAdd.Parameters.AddWithValue("@is_superadmin", );//buraya bakılacak

                    comAdd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("ADD PROCESS SUCCESSFULL");
            listDb();
        }
        //kullanıcı düzenleme
        private void btnEditUser_Click(object sender, EventArgs e)
        {
            string query = "UPDATE admins SET ID = @ID username = @username, password = @password, is_superadmin = @is_superadmin, " +
                "city=@city, district=@district";
            using (var con = db.connection())
            {
                using (var comEdit = new NpgsqlCommand(query, con))
                {
                    // Parametreleri ekle
                    comEdit.Parameters.AddWithValue("@ID", txtUserID.Text);
                    comEdit.Parameters.AddWithValue("@username", txtUserName.Text);
                    comEdit.Parameters.AddWithValue("@password", txtUserPassword.Text);
                    comEdit.Parameters.AddWithValue("@city", txtCity.Text); // int değer
                    comEdit.Parameters.AddWithValue("@district", txtDistrict.Text);

                    comEdit.Parameters.AddWithValue("@is_superadmin", );//buraya bakılacak admşn kısmını radio buttona alma
                    comEdit.ExecuteNonQuery();
                }
            }
            MessageBox.Show("EDIT PROCESS SUCCESSFULL");
            listDb();
        }
        //kullanıcı silme 
        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM admins where ID= @id";
            using (var con = db.connection())
            {
                using (var comDelete = new NpgsqlCommand(query, con))
                {
                    comDelete.Parameters.AddWithValue("@id", int.Parse(txtUserID.Text));
                    comDelete.ExecuteNonQuery();
                }
            }
            MessageBox.Show("DELETE PROCESS SUCCESSFULL");
            listDb();
        }

    
    }
    
}
