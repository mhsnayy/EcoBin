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
        // kıyafet listesindeki kıyafetlerin string toplamı (TAMAMLANDI)
        string sumClothes(List<string> clist)
        {
            string sum = "";
            foreach (var i in clist)
            {

                sum = sum + i + ",";
            }
            if (sum.EndsWith(","))
            {
                sum = sum.Remove(sum.Length - 1);
            }
            sum = "(" + sum + ")";
            return sum;
        }
        //tüm ürünleri listeleme methodu  (TAMAMLANDI)
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

        //form yüklenir yüklenmez datagride database gelecek  (TAMAMLANDI)
        private void ClothesForm_Load(object sender, EventArgs e)
        {
            listDb();
        }

        //add product to database  (TAMAMLANDI)
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO boxes1 (box_id, name, size, color, usability, fabric_type, reason, material) " +
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

        //delete product****eksik var box ıdden alırsak hangi ürün silinecek...ürün idsi olmalı (ONUN DIŞINDA TAMAMLANDI)
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM boxes1 where ID= @id";
            using (var con = db.connection())
            {
                using (var comDelete = new NpgsqlCommand(query, con))
                {
                    comDelete.Parameters.AddWithValue("@id", int.Parse(txtBoxID.Text));
                    comDelete.ExecuteNonQuery();
                }
            }
            MessageBox.Show("DELETE PROCESS SUCCESSFULL");
            listDb();
        }

        //datagriddeki verileri textboxda okumak (TAMAMLANDI)
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtID.Text = dr["id"]?.ToString() ?? "";
            txtBoxID.Text = dr["box_id"]?.ToString() ?? "";
            txtName.Text = dr["name"]?.ToString() ?? "";
            txtSize.Text = dr["size"]?.ToString() ?? "";
            txtColor.Text = dr["color"]?.ToString() ?? "";
            txtUsability.Text = dr["usability"]?.ToString() ?? "";
            txtFabricType.Text = dr["fabric_type"]?.ToString() ?? "";
            txtMaterial.Text = dr["material"]?.ToString() ?? "";
            txtReason.Text = dr["reason"]?.ToString() ?? "";
            var selectedValue = dr["decision"]?.ToString(); // Veritabanından "decision" sütunu

            if (selectedValue == "Donation")
            {
                radioGroup1.SelectedIndex = 0; // Donation seçili
                txtReason.Visible = true;
            }
            else if (selectedValue == "Recycle")
            {
                radioGroup1.SelectedIndex = 1; // Recycle seçili
                txtReason.Visible = false;
            }
            else
            {
                radioGroup1.SelectedIndex = -1; // Hiçbir şey seçili değil
                txtReason.Visible = false;
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
        //ürün içerik güncelleme (TAMAMLANDI)
        private void btnEdit_Click(object sender, EventArgs e)
        {
            string query = "UPDATE boxes1 SET box_id = @box_id name = @name, size = @size, color = @color, usability = @usability," +
                "fabric_type = @fabric_type, reason = @reason, material = @material WHERE box_id = @box_id";
            using (var con = db.connection())
            {
                using (var comEdit = new NpgsqlCommand(query, con))
                {
                    comEdit.Parameters.AddWithValue("box_id", txtBoxID.Text.ToString());
                    comEdit.Parameters.AddWithValue("@name", txtName.Text.ToString());
                    comEdit.Parameters.AddWithValue("@size", txtSize.Text.ToString());
                    comEdit.Parameters.AddWithValue("@color", txtColor.Text.ToString());
                    comEdit.Parameters.AddWithValue("@usability", txtUsability.Text.ToString());
                    comEdit.Parameters.AddWithValue("@fabric_type", txtFabricType.Text.ToString());
                    comEdit.Parameters.AddWithValue("@reason", txtReason.Text.ToString());
                    comEdit.Parameters.AddWithValue("@material", txtMaterial.Text.ToString());
                    comEdit.ExecuteNonQuery();
                }
            }
            MessageBox.Show("EDIT PROCESS SUCCESSFULL");
            listDb();
        }
        //seçilen kıyafetlere göre listeleme (TAMAMLANDI)
        private void barBtnList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sum_clothes = sumClothes(clothes);
            string query = "SELECT * FROM boxes1 WHERE name IN" + sum_clothes;
            listDb(query);

        }
        private void checkTshirt_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string cl = "'tshirt'";
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
            string cl = "'shirt'";
            if (checkTshirt.Checked == true)
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
            string cl = "'trouser'";
            if (checkTshirt.Checked == true)
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
            string cl = "'skirt'";
            if (checkTshirt.Checked == true)
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
            string cl = "'sweater'";
            if (checkTshirt.Checked == true)
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
            if (checkTshirt.Checked == true)
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
            string cl = "'shoes'";
            if (checkTshirt.Checked == true)
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
            string cl = "'blanket'";
            if (checkTshirt.Checked == true)
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
            string cl = "'sweatpanth'";
            if (checkTshirt.Checked == true)
            {
                clothes.Add(cl);
            }
            else
            {
                clothes.Remove(cl);
            }
        }
    }
}
