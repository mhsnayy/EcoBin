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
    public partial class LoginForm : Form

    {
        

        public string ErrorMessage { get; set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        DataBase db = new DataBase();
        public bool statu;

        //databaseden kullanıcı girişi bilgileri sağlanacak public bir statü değerinde kullanıcının main admin kontrol edilecek
        //(TAMAMLANDI)

        private void sButtonLog_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.ToString();
            string password = txtPassword.Text.ToString();
            string query = "SELECT * FROM admins WHERE username = @username AND password = @password";
            
            using (var con = db.connection())
            {
                using (var command = new NpgsqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@username", userName);
                    command.Parameters.AddWithValue("@password", password);
                    
                    using(var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            statu = Convert.ToBoolean(reader["is_superadmin"]);
                            MessageBox.Show("Authentication successful!");
                            HomeForm hfrm = new HomeForm();
                            hfrm._statu = statu;
                            hfrm.Show();
                            this.Hide();
                        }
                        else
                        {
                            ErrorMessage = "Invalid Username or Password.";  // Hata mesajını ErrorMessage özelliğine atıyoruz
                            MessageBox.Show(ErrorMessage);
                        }
                    }
                }
            }
        }

        private void checkRemember_CheckedChanged(object sender, EventArgs e)
        {
            if (checkRemember.Checked == true)
            {
                Properties.Settings.Default.userName = txtUserName.Text;
                Properties.Settings.Default.password = txtPassword.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.userName = "";
                Properties.Settings.Default.password = "";
                Properties.Settings.Default.Save();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.userName != string.Empty)
            {
                txtUserName.Text = Properties.Settings.Default.userName;
                txtPassword.Text = Properties.Settings.Default.password;
                checkRemember.Checked = true;
            }
        }
    }
}
