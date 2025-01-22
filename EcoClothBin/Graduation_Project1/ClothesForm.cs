using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Graduation_Project1
{
    public partial class ClothesForm : Form
    {
        public ClothesForm()
        {
            InitializeComponent();
            listDb();
        }
        DataBase db = new DataBase();
        List<string> clothes = new List<string>();
        
        //tüm ürünleri listeleme methodu  (TAMAMLANDI)
        void listDb(string query = "SELECT * FROM clothes")
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

        //form yüklenir yüklenmez datagride database gelecek  (TAMAMLANDI)
        private void ClothesForm_Load(object sender, EventArgs e)
        {
            listDb();
            
        }

        //add product to database  (TAMAMLANDI)
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string selectBox = txtBoxID.Text.ToString();
            string query = "INSERT INTO "+selectBox+" (box_id, name, size, color, usability, fabric_type, reason, material) " +
                  "VALUES (@box_id, @name, @size, @color, @usability, @fabric_type, @reason, @material)";
            using (var con = db.connection())
            {
                using (var comAdd = new NpgsqlCommand(query, con))
                {
                    // Parametreleri ekle
                    comAdd.Parameters.AddWithValue("@box_id", txtBoxID.Text);
                    comAdd.Parameters.AddWithValue("@name", txtName.Text);
                    comAdd.Parameters.AddWithValue("@size", txtSize.Text);
                    comAdd.Parameters.AddWithValue("@color", txtColor.Text);
                    comAdd.Parameters.AddWithValue("@usability", int.Parse(txtUsability.Text)); // int değer
                    comAdd.Parameters.AddWithValue("@fabric_type", txtFabricType.Text);
                    comAdd.Parameters.AddWithValue("@reason", txtReason.Text);
                    comAdd.Parameters.AddWithValue("@material", txtMaterial.Text);
                    comAdd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("ADD PROCESS SUCCESSFULL");
            listDb();
        }

        //delete product
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string selectBox = txtBoxID.Text.ToString();
            string query = "DELETE FROM "+selectBox+"  where \"Id\"=@id";
            using (var con = db.connection())
            {
                using (var comDelete = new NpgsqlCommand(query, con))
                {
                    int id = int.Parse(txtID.Text);
                    comDelete.Parameters.AddWithValue("@id",id );
                    comDelete.ExecuteNonQuery();
                }
            }
            MessageBox.Show("DELETE PROCESS SUCCESSFULL");
            listDb();
        }

        //datagriddeki verileri textboxda okumak (TAMAMLANDI)
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtID.Text = "";
            txtBoxID.Text = "";
            txtName.Text = "";
            txtSize.Text = "";
            txtColor.Text = "";
            txtUsability.Text = "";
            txtFabricType.Text = "";
            txtMaterial.Text = "";
            txtReason.Text = "";
            var selectedValue = "reycle";
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtID.Text = dr["Id"]?.ToString() ?? "";
            txtBoxID.Text = dr["box_id"]?.ToString() ?? "";
            txtName.Text = dr["name"]?.ToString() ?? "";
            txtSize.Text = dr["size"]?.ToString() ?? "";
            txtColor.Text = dr["color"]?.ToString() ?? "";
            txtUsability.Text = dr["usability"]?.ToString() ?? "";
            txtFabricType.Text = dr["fabric_type"]?.ToString() ?? "";
            txtMaterial.Text = dr["material"]?.ToString() ?? "";
            txtReason.Text = dr["reason"]?.ToString() ?? "";
            selectedValue = dr["decision"]?.ToString(); // Veritabanından "decision" sütunu

            if (selectedValue == "reycle") // Recycle seçili
            {
                radioGroup1.SelectedIndex = 1;
            }
            else // Donation seçili
            {
                radioGroup1.SelectedIndex = 0;                 
            }
            
        }
        // xlxs çıktısı alma (TAMAMLANDI)
        private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog save = new SaveFileDialog())
            {
                save.Filter = "Excel Files|*.xlsx";
                save.Title = "Export to Excel";
                save.FileName = "ExportedData.xlsx";//varsayılan dosya adı
                if (save.ShowDialog() == DialogResult.OK)
                {
                    gridControl1.ExportToXlsx(save.FileName);
                    MessageBox.Show("Data successfully exported to Excel!");
                }
            }
        }
        string choosen;
        //ürün içerik güncelleme (TAMAMLANDI)
        private void btnEdit_Click(object sender, EventArgs e)
        {
            string selectBox = txtBoxID.Text.ToString();
            string query = "UPDATE "+selectBox+" SET box_id = @box_id, name = @name, size = @size, color = @color, usability = @usability," +
                "fabric_type = @fabric_type, reason = @reason, material = @material WHERE \"Id\" = @id";
            using (var con = db.connection())
            {              
                if (radioGroup1.SelectedIndex == 0)
                {
                    choosen = "Donation";// Donation seçili
                }
                else if (radioGroup1.SelectedIndex == 1)
                {
                    choosen = "Recycle";// Recycle seçili
                }
                using (var comEdit = new NpgsqlCommand(query, con))
                {
                    
                    comEdit.Parameters.AddWithValue("@id", int.Parse(txtID.Text));//int değer
                    comEdit.Parameters.AddWithValue("@box_id", txtBoxID.Text.ToString());
                    comEdit.Parameters.AddWithValue("@name", txtName.Text.ToString());
                    comEdit.Parameters.AddWithValue("@size", txtSize.Text.ToString());
                    comEdit.Parameters.AddWithValue("@color", txtColor.Text.ToString());
                    comEdit.Parameters.AddWithValue("@usability", int.Parse(txtUsability.Text));//int değer
                    comEdit.Parameters.AddWithValue("@fabric_type", txtFabricType.Text.ToString());
                    comEdit.Parameters.AddWithValue("@reason", txtReason.Text.ToString());
                    comEdit.Parameters.AddWithValue("@material", txtMaterial.Text.ToString());
                    comEdit.Parameters.AddWithValue("@decision", choosen.ToString());
                    comEdit.ExecuteNonQuery();
                }
            }
            MessageBox.Show("EDIT PROCESS SUCCESSFULL");
            listDb();
        }
        //seçilen kıyafetlere göre listeleme (TAMAMLANDI)
        private void barBtnList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (clothes.Count == 0) 
            {
                listDb();
            }
            else
            {
                string selectedClothes = string.Join(",", clothes);
                string query = "SELECT * FROM clothes WHERE name IN (" + selectedClothes + ")";
                string a = query;
                try
                {
                    listDb(query);
                }
                catch (Exception)
                {
                    MessageBox.Show("seçimlerinize göre ürün bulunamadı");
                }
            }          
        }
        private void checkTshirt_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string cl = "'t-shirt'";
            if (checkTshirt.Checked == true)
            {
                clothes.Add(cl);
            }
            else
            {
                clothes.Remove(cl);
            }
        }
        private void checkShirt_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string cl = "'Shirts'";
            if (checkShirt.Checked == true)
            {
                clothes.Add(cl);
            }
            else
            {
                clothes.Remove(cl);
            }
        }
        private void checkTrouser_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string cl = "'Trousers'";
            if (checkTrouser.Checked == true)
            {
                clothes.Add(cl);
            }
            else
            {
                clothes.Remove(cl);
            }
        }
        private void checkSkirt_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string cl = "'Skirts'";
            if (checkSkirt.Checked == true)
            {
                clothes.Add(cl);
            }
            else
            {
                clothes.Remove(cl);
            }
        }
        private void checkSweater_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string cl = "'Sweaters'";
            if (checkSweater.Checked == true)
            {
                clothes.Add(cl);
            }
            else
            {
                clothes.Remove(cl);
            }
        }
        private void checkCoat_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string cl = "'coat'";
            if (checkCoat.Checked == true)
            {
                clothes.Add(cl);
            }
            else
            {
                clothes.Remove(cl);
            }
        }
        private void checkShoes_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string cl = "'Shoes'";
            if (checkShoes.Checked == true)
            {
                clothes.Add(cl);
            }
            else
            {
                clothes.Remove(cl);
            }
        }
        private void checkBlanket_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string cl = "'blanket and quilt'";
            if (checkBlanket.Checked == true)
            {
                clothes.Add(cl);
            }
            else
            {
                clothes.Remove(cl);
            }
        }
        private void checkSweatPanth_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string cl = "'sweatpants'";
            if (checkSweatPanth.Checked == true)
            {
                clothes.Add(cl);
            }
            else
            {
                clothes.Remove(cl);
            }
        }

        private void barBtnBoxPage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BoxesForm bfrm = new BoxesForm();
            bfrm.Show();
            this.Hide();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 1)//reycyle seçili
            {
                txtFabricType.Visible = true;
                lblFabricType.Visible = true;
                txtMaterial.Visible = false;
                lblMaterial.Visible = false;
                txtReason.Visible = true;
                lblReason.Visible = true;
                txtSize.Visible = false;
                lblSize.Visible = false;
                txtColor.Visible = false;
                lblColor.Visible = false;
                txtUsability.Visible = false;
                lblUsability.Visible = false;
            }
            else//donation seçili
            {
                txtReason.Visible = false;
                lblReason.Visible = false;
                txtSize.Visible = true;
                lblSize.Visible = true;
                txtColor.Visible = true;
                lblColor.Visible = true;
                txtUsability.Visible = true;
                lblUsability.Visible = true;
                txtFabricType.Visible = false;
                lblFabricType.Visible = false;
                txtMaterial.Visible = false;
                lblMaterial.Visible = false;
            }
        }

        

        private void barBtnHomePage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HomeForm hfrm = new HomeForm();
            hfrm.Show();
            this.Hide();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoginForm lfrm = new LoginForm();
            lfrm.Show();
            this.Hide();
        }
    }
}
