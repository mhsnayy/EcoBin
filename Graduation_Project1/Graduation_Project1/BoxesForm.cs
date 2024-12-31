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
        private string _city = "";//bu bilgiyi comboboxdan alacak
        int boxCount = 0;
        List<BarCheckItem> checkItems = new List<BarCheckItem>();
        List<string> boxes = new List<string>();

        public BoxesForm()
        {
            InitializeComponent();
        }
        //form açılır açılmaz database listelenecek(TAMAMLANDI)
        private void BoxesForm_Load(object sender, EventArgs e)
        {
            listDb();
        }
        //default tüm databasei getiren bir sorgu(TAMAMLANDI)
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
        //sadece databasede var olan kutuları gösteren bir method(TAMAMLANDI)(şehirleri kaldırabiliriz=sorgu değişir)
        public void showBoxes()
        {
            string query = "SELECT COUNT(*) AS box_count FROM boxes1 WHERE city = @p1 GROUP BY city ; ";//kaç farklı kutu idsi var onu hesaplayan bir query
            using (var con = db.connection())
            {
                using (NpgsqlCommand com = new NpgsqlCommand(query, con))
                {
                    com.Parameters.AddWithValue("@p1", _city);
                    object result = com.ExecuteScalar();
                    boxCount = Convert.ToInt16(result);
                }
            }
            foreach (BarItem item in ribbonControl1.Items)
            {
                if (item is BarCheckItem checkItem)
                {
                    checkItems.Add(checkItem);
                }
            }
            for (int i = 0; i <= boxCount; i++)
            {
                checkItems[i].Visibility = BarItemVisibility.Always;
            }
        }
        //seçilen kutuların string toplamı(TAMAMLANDI)
        public string sumBoxes()
        {
            string sum = "";
            foreach (var box in boxes)
            {
                sum = sum + box + ",";
            }
            if (sum.EndsWith(","))
            {
                sum.Remove(sum.Length - 1);
            }
            sum = "(" + sum + ")";
            return sum;
        }
        //chartlar gösterilecek
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string query = @"
        SELECT
            clothes_type AS kiyafet_turu,
            COUNT(*) AS toplam_adet
        FROM
            clothes
        GROUP BY
            clothes_type
        ORDER BY
            toplam_adet DESC;
    ";
            using (var con = db.connection())
            {
                using (NpgsqlCommand com = new NpgsqlCommand(query, con))
                {
                    NpgsqlDataReader dataReader = com.ExecuteReader();
                    chartControl1.Series.Clear();
                    while (dataReader.Read())
                    {
                        chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dataReader[0]), int.Parse(dataReader[1].ToString()));
                        chartControl2.Series["Series 1"].Points.AddPoint(Convert.ToString(dataReader[0]), int.Parse(dataReader[1].ToString()));
                    }
                }
            }
            
            
        }
        //seçilen boxlara göre listeleme (TAMAMLANDI)
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sum_boxes = sumBoxes();
            string query = "SELECT * FROM boxes1 WHERE box_id IN" + sumBoxes();//tamamlanacak
            listDb(query);
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
            string query = "DELETE FROM boxes1 where box_id in @id";
            string sum_boxes = sumBoxes();
            using (var con = db.connection())
            {
                using (var comDelete = new NpgsqlCommand(query, con))
                {
                    comDelete.Parameters.AddWithValue("@id",sum_boxes);
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
        private void barBox1_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string box = "'box1'";//yunusla database düzeltmemiz gerekebilir
            if (barBox1.Checked==true)
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
            if (barBox1.Checked == true)
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
            if (barBox1.Checked == true)
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
            if (barBox1.Checked == true)
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
            if (barBox1.Checked == true)
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
            if (barBox1.Checked == true)
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
            if (barBox1.Checked == true)
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
            if (barBox1.Checked == true)
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
            if (barBox1.Checked == true)
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
            if (barBox1.Checked == true)
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
