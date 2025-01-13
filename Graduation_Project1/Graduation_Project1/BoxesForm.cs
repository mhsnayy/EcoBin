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
using DevExpress.XtraBars;

namespace Graduation_Project1
{
    public partial class BoxesForm : Form
    {
        DataBase db = new DataBase();
        
        List<BarCheckItem> checkItems = new List<BarCheckItem>();
        List<string> boxes = new List<string>();
        List<string> boxlist = new List<string>();

        public BoxesForm()
        {
            InitializeComponent();
        }
        //form açılır açılmaz database listelenecek boxlar düzenlenecek(TAMAMLANDI)
        private void BoxesForm_Load(object sender, EventArgs e)
        {
            listDb();
            showBoxes();
        }
        //default tüm databasei getiren bir sorgu(TAMAMLANDI)
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
        //sadece databasede var olan kutuları gösteren bir method(TAMAMLANDI)
        public void getBoxes()
        {
            string query = "SELECT box_id from box_info";
            using (var con = db.connection())
            {
                using (NpgsqlCommand com = new NpgsqlCommand(query, con))
                {                
                    
                   using (var reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            boxlist.Add(reader.GetString(0)); //dbdedeki box isimleri listeye eklenir
                        }
                    }
                }
            }
        }        
        public void showBoxes()
        {
            getBoxes();
            // RibbonPageGroup içindeki tüm ItemLinks öğelerini kontrol et
            foreach (DevExpress.XtraBars.BarItemLink itemLink in ribbonPageGroup1.ItemLinks)
            {
                // BarItem öğesine erişim
                var barItem = itemLink.Item;

                if (barItem != null)
                {
                    // Eğer BarItem'in Caption'ı veritabanındaki boxlist'te varsa görünür yap, yoksa gizle
                    barItem.Visibility = boxlist.Contains(barItem.Caption)
                        ? DevExpress.XtraBars.BarItemVisibility.Always 
                        : DevExpress.XtraBars.BarItemVisibility.Never; 
                }
            }
        }

        //chartlar gösterilecek

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string selectedBox = string.Join(",", boxes);
                selectedBox = selectedBox.Replace("'", "");
                string query = "SELECT name,COUNT(*) FROM " + selectedBox + " GROUP BY name";
                using (var con = db.connection())
                {
                    using (NpgsqlCommand com = new NpgsqlCommand(query, con))
                    {
                        NpgsqlDataReader dataReader = com.ExecuteReader();

                        while (dataReader.Read())
                        {
                            chartControl1.Series["Clothes"].Points.AddPoint(Convert.ToString(dataReader[0]), int.Parse(dataReader[1].ToString()));
                            chartControl2.Series["Series 1"].Points.AddPoint(Convert.ToString(dataReader[0]), int.Parse(dataReader[1].ToString()));
                        }
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("tek kutu sorgusu yapabilirsiniz");
            }
            
        }
        //seçilen boxlara göre listeleme (TAMAMLANDI)
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (boxes.Count == 0)
            {
                listDb();
            }
            else
            {
                string selectedBox = string.Join(",", boxes);
                string query = "SELECT * FROM clothes WHERE box_id IN (" + selectedBox + ")";
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
        //xlsx çıktısı alma (TAMAMLANDI)
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
        //delete box (TAMAMLANDI)
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string selectedBox = string.Join(",", boxes);
            selectedBox=selectedBox.Replace("'", "");

            string query = "DELETE FROM "+selectedBox;
            
            using (var con = db.connection())
            {
                using (var comDelete = new NpgsqlCommand(query, con))
                {
                    
                    comDelete.ExecuteNonQuery();
                }
            }
            MessageBox.Show("DELETE PROCESS SUCCESSFULL");
            listDb();
        }
        //go to clothes page
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClothesForm cfrm = new ClothesForm();
            cfrm.Show();
            this.Hide();
        }
        //go to home page
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HomeForm hfrm = new HomeForm();
            hfrm.Show();
            this.Hide();
        }


        //box1
        private void barBox1_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            string box = "'box1'";
            if (barBox1.Checked == true)
            {
                boxes.Add(box);
            }
            else
            {
                boxes.Remove(box);
            }
        }
        //box 2
        private void barBox2_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string box = "'box2'";
            if (barBox2.Checked == true)
            {
                boxes.Add(box);
            }
            else
            {
                boxes.Remove(box);
            }
        }
        //box 3
        private void barBox3_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string box = "'box3'";
            if (barBox3.Checked == true)
            {
                boxes.Add(box);
            }
            else
            {
                boxes.Remove(box);
            }
        }
        //box 4
        private void barBox4_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string box = "'box4'";
            if (barBox4.Checked == true)
            {
                boxes.Add(box);
            }
            else
            {
                boxes.Remove(box);
            }
        }
        //box 5
        private void barBox5_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string box = "'box5'";
            if (barBox5.Checked == true)
            {
                boxes.Add(box);
            }
            else
            {
                boxes.Remove(box);
            }

        }
        //box 6
        private void barBox6_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string box = "'box6'";
            if (barBox6.Checked == true)
            {
                boxes.Add(box);
            }
            else
            {
                boxes.Remove(box);
            }
        }
        //box 7
        private void barBox7_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string box = "'box7'";
            if (barBox7.Checked == true)
            {
                boxes.Add(box);
            }
            else
            {
                boxes.Remove(box);
            }
        }
        //box 8
        private void barBox8_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string box = "'box8'";
            if (barBox8.Checked == true)
            {
                boxes.Add(box);
            }
            else
            {
                boxes.Remove(box);
            }
        }
        //box 9
        private void barBox9_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string box = "'box9'";
            if (barBox9.Checked == true)
            {
                boxes.Add(box);
            }
            else
            {
                boxes.Remove(box);
            }
        }
        //box 10
        private void barBox10_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string box = "'box10'";
            if (barBox10.Checked == true)
            {
                boxes.Add(box);
            }
            else
            {
                boxes.Remove(box);
            }
        }

        
    }
}
