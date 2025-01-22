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
    public partial class HomeForm : Form
    {
        public bool _statu;
        public HomeForm()
        {
            InitializeComponent();
        }
        //go to Clothes Form    
        private void btnClothesForm_Click(object sender, EventArgs e)
        {
            ClothesForm cfrm = new ClothesForm();
            cfrm.Show();
            this.Hide();
        }
        //Go to Box Form
        private void btnBoxForm_Click(object sender, EventArgs e)
        {
            BoxesForm boxfrm = new BoxesForm();
            boxfrm.Show();
            this.Hide();
        }
        //go to edit user form
        private void btnEditUser_Click(object sender, EventArgs e)
        {
            UserEditForm editfrm = new UserEditForm();
            editfrm.Show();
            this.Hide();
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            LoginForm lfrm = new LoginForm();
            
            if (_statu)
            {
                btnEditUser.Visible = true;
                btnEditUser.Enabled = true;
            }
            else
            {
                btnEditUser.Visible = false;
                btnEditUser.Enabled = false;
            }
        }
    }
}
