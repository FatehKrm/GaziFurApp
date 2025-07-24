using System;
using System.Data;
using System.Drawing.Printing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace GaziFurApp
{
    internal partial class GetirilenKonsiyeForm : Form
    {
        private string connectionString = "Server=DESKTOP-PBR2LIP;Database=GazifurAppDb;Trusted_Connection=True;TrustServerCertificate=True;";
        private PrintDocument printDocument;
        private PrintPreviewDialog printPreviewDialog;
        private int guncelleIndex = -1;
        private int? guncelleDbId = null;

        public GetirilenKonsiyeForm()
        {
            InitializeComponent();
            InitDataGrid();
            InitFiltreGrid();
            buttonEkle.Click += ButtonEkle_Click;
            buttonSil.Click += ButtonSil_Click;
            buttonGuncelle.Click += ButtonGuncelle_Click;
            buttonYazdir.Click += ButtonYazdir_Click;
            textBoxFiltre.TextChanged += textBoxFiltre_TextChanged_1;
            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;
            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;
            this.Load += GetirilenKonsiyeForm_Load;
        }

        private void GetirilenKonsiyeForm_Load(object sender, EventArgs e)
        {
            EnsureTableExists();
            LoadData();
        }

        private void EnsureTableExists()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string createTableQuery = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='GetirilenKonsiye' AND xtype='U')
                CREATE TABLE GetirilenKonsiye (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    GetirenAdi NVARCHAR(100),
                    UrunAdi NVARCHAR(100),
                    Fiyat DECIMAL(18,2),
                    Adet INT,
                    Tarih DATE,
                    OdemeAlindi BIT
                )";
                using (var cmd = new SqlCommand(createTableQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string selectQuery = "SELECT Id, GetirenAdi, UrunAdi, Fiyat, Adet, Tarih, OdemeAlindi FROM GetirilenKonsiye ORDER BY Id DESC";
                using (var cmd = new SqlCommand(selectQuery, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(
                            reader[1].ToString(),
                            reader[2].ToString(),
                            reader[3].ToString(),
                            reader[4].ToString(),
                            Convert.ToDateTime(reader[5]).ToShortDateString(),
                            (reader[6] is bool b && b) ? "Alındı" : "Alınmadı"
                        );
                    }
                }
            }
        }

        private void InitDataGrid()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Getiren", "Getirenin Adı");
            dataGridView1.Columns.Add("Urun", "Ürün Adı");
            dataGridView1.Columns.Add("Fiyat", "Fiyatı");
            dataGridView1.Columns.Add("Adet", "Adeti");
            dataGridView1.Columns.Add("Tarih", "Tarih");
            dataGridView1.Columns.Add("Odeme", "Ödeme Durumu");
        }

        private void InitFiltreGrid()
        {
            dataGridViewFiltre.Columns.Clear();
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                dataGridViewFiltre.Columns.Add((DataGridViewColumn)col.Clone());
            }
        }

        private void ButtonEkle_Click(object sender, EventArgs e)
        {
            string odemeDurumu = radioOdemeAlindi.Checked ? "Alındı" : (radioOdemeAlinmadi.Checked ? "Alınmadı" : "");
            string getiren = textBoxGetiren.Text.Trim();
            string urun = textBoxUrun.Text.Trim();
            string fiyatStr = textBoxFiyat.Text.Trim();
            string adetStr = textBoxAdet.Text.Trim();
            DateTime tarih = dateTimePickerTarih.Value.Date;
            bool odemeAlindi = radioOdemeAlindi.Checked;
            if (string.IsNullOrEmpty(getiren) || string.IsNullOrEmpty(urun) || string.IsNullOrEmpty(fiyatStr) || string.IsNullOrEmpty(adetStr))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(fiyatStr, out decimal fiyat) || fiyat < 0)
            {
                MessageBox.Show("Fiyat geçerli bir sayı olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(adetStr, out int adet) || adet < 0)
            {
                MessageBox.Show("Adet pozitif bir sayı olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string insertQuery = @"INSERT INTO GetirilenKonsiye (GetirenAdi, UrunAdi, Fiyat, Adet, Tarih, OdemeAlindi)
                    VALUES (@getiren, @urun, @fiyat, @adet, @tarih, @odemeAlindi)";
                using (var cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@getiren", getiren);
                    cmd.Parameters.AddWithValue("@urun", urun);
                    cmd.Parameters.AddWithValue("@fiyat", fiyat);
                    cmd.Parameters.AddWithValue("@adet", adet);
                    cmd.Parameters.AddWithValue("@tarih", tarih);
                    cmd.Parameters.AddWithValue("@odemeAlindi", odemeAlindi);
                    cmd.ExecuteNonQuery();
                }
            }
            LoadData();
            textBoxGetiren.Text = "";
            textBoxUrun.Text = "";
            textBoxFiyat.Text = "";
            textBoxAdet.Text = "";
            radioOdemeAlindi.Checked = false;
            radioOdemeAlinmadi.Checked = false;
        }

        private void ButtonSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Veritabanından da sil
                string getiren = dataGridView1.SelectedRows[0].Cells[0].Value?.ToString();
                string urun = dataGridView1.SelectedRows[0].Cells[1].Value?.ToString();
                string fiyat = dataGridView1.SelectedRows[0].Cells[2].Value?.ToString();
                string adet = dataGridView1.SelectedRows[0].Cells[3].Value?.ToString();
                string tarih = dataGridView1.SelectedRows[0].Cells[4].Value?.ToString();

                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string deleteQuery = @"DELETE FROM GetirilenKonsiye 
                           WHERE GetirenAdi=@getiren AND UrunAdi=@urun 
                           AND Fiyat=@fiyat AND Adet=@adet AND Tarih=@tarih";

                    using (var cmd = new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@getiren", getiren);
                        cmd.Parameters.AddWithValue("@urun", urun);
                        cmd.Parameters.AddWithValue("@fiyat", decimal.Parse(fiyat)); // Sayısal
                        cmd.Parameters.AddWithValue("@adet", int.Parse(adet));       // Sayısal
                        cmd.Parameters.AddWithValue("@tarih", DateTime.Parse(tarih));

                        cmd.ExecuteNonQuery();
                    }
                }

                LoadData();
            }
        }

        private void ButtonGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];
                textBoxGetiren.Text = row.Cells[0].Value?.ToString();
                textBoxUrun.Text = row.Cells[1].Value?.ToString();
                textBoxFiyat.Text = row.Cells[2].Value?.ToString();
                textBoxAdet.Text = row.Cells[3].Value?.ToString();
                dateTimePickerTarih.Text = row.Cells[4].Value?.ToString();
                string odeme = row.Cells[5].Value?.ToString();
                radioOdemeAlindi.Checked = odeme == "Alındı";
                radioOdemeAlinmadi.Checked = odeme == "Alınmadı";
                guncelleIndex = row.Index;
                // Güncellenecek satırın Id'sini bul
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string selectId = @"SELECT TOP 1 Id FROM GetirilenKonsiye WHERE GetirenAdi=@getiren AND UrunAdi=@urun AND Fiyat=@fiyat AND Adet=@adet AND Tarih=@tarih";
                    using (var cmd = new SqlCommand(selectId, conn))
                    {
                        cmd.Parameters.AddWithValue("@getiren", row.Cells[0].Value);
                        cmd.Parameters.AddWithValue("@urun", row.Cells[1].Value);
                        cmd.Parameters.AddWithValue("@fiyat", row.Cells[2].Value);
                        cmd.Parameters.AddWithValue("@adet", row.Cells[3].Value);
                        cmd.Parameters.AddWithValue("@tarih", DateTime.Parse(row.Cells[4].Value.ToString()));
                        var idObj = cmd.ExecuteScalar();
                        guncelleDbId = idObj != null ? Convert.ToInt32(idObj) : (int?)null;
                    }
                }
            }
        }

        private void ButtonYazdir_Click(object sender, EventArgs e)
        {
            printPreviewDialog.ShowDialog();
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            string printText = "";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        printText += row.Cells[i].Value + "\t";
                    }
                    printText += "\n";
                }
            }
            e.Graphics.DrawString(printText, new System.Drawing.Font("Arial", 10), System.Drawing.Brushes.Black, 10, 10);
        }

        private void textBoxFiltre_TextChanged_1(object sender, EventArgs e)
        {
            dataGridViewFiltre.Rows.Clear();
            string filtre = textBoxFiltre.Text.ToLower();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow && row.Cells[0].Value != null && row.Cells[0].Value.ToString().ToLower().Contains(filtre))
                {
                    int idx = dataGridViewFiltre.Rows.Add();
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        dataGridViewFiltre.Rows[idx].Cells[i].Value = row.Cells[i].Value;
                    }
                }
            }
        }

        private void radioOdemeAlinmadi_CheckedChanged(object sender, EventArgs e)
        {
            // Şimdilik işlev yok, hata engellendi
        }
    }
}