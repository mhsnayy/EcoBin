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
        public LoginForm()
        {
            InitializeComponent();
        }
        DataBase db = new DataBase();
        public bool statu=true;
        public string city = "";//bunu yunusla bi konuşmak gerek
        //databaseden kullanıcı girişi bilgileri sağlanacak public bir statü değerinde kullanıcının main admin kontrol edilecek
        //(TAMAMLANDI)
        private void sButtonLog_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.ToString();
            string password = txtPassword.Text.ToString();
            string query = "SELECT * FROM users WHERE username = @username AND password = @password";
            
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
                            hfrm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show(" Invalid Username or Password.");
                        }
                    }
                }
            }
        }
    }
}
