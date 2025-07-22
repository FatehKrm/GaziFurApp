using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace GaziFurApp
{
    public partial class MagazaGirdileriForm : Form
    {
        private string connectionString = "Server=DESKTOP-PBR2LIP;Database=GazifurAppDb;Trusted_Connection=True;TrustServerCertificate=True;";

        public MagazaGirdileriForm()
        {
            InitializeComponent();
            this.Load += MagazaGirdileriForm_Load;
            buttonEkle.Click += ButtonEkle_Click;
        }

        private void MagazaGirdileriForm_Load(object sender, EventArgs e)
        {
            EnsureTableExists();
            LoadData();
            LoadTotals();
        }

        private void EnsureTableExists()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string createTableQuery = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='MagazaGirdileri' AND xtype='U')
                CREATE TABLE MagazaGirdileri (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    UrunKodu NVARCHAR(50),
                    UrunAdi NVARCHAR(100),
                    Adet INT,
                    GirisTarihi DATE
                )";
                using (var cmd = new SqlCommand(createTableQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                // Eksik kolonları ekle
                string addMusteriAdi = "IF COL_LENGTH('MagazaGirdileri', 'MusteriAdi') IS NULL ALTER TABLE MagazaGirdileri ADD MusteriAdi NVARCHAR(100);";
                string addUrunDegeri = "IF COL_LENGTH('MagazaGirdileri', 'UrunDegeri') IS NULL ALTER TABLE MagazaGirdileri ADD UrunDegeri DECIMAL(18,2);";
                string addOdemeAlindi = "IF COL_LENGTH('MagazaGirdileri', 'OdemeAlindi') IS NULL ALTER TABLE MagazaGirdileri ADD OdemeAlindi BIT;";
                using (var cmd = new SqlCommand(addMusteriAdi, conn)) { cmd.ExecuteNonQuery(); }
                using (var cmd = new SqlCommand(addUrunDegeri, conn)) { cmd.ExecuteNonQuery(); }
                using (var cmd = new SqlCommand(addOdemeAlindi, conn)) { cmd.ExecuteNonQuery(); }
            }
        }

        private void LoadData()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string selectQuery = "SELECT Id, UrunKodu, UrunAdi, Adet, MusteriAdi, UrunDegeri, OdemeAlindi, GirisTarihi FROM MagazaGirdileri ORDER BY GirisTarihi DESC, Id DESC";
                using (var adapter = new SqlDataAdapter(selectQuery, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewGirdiler.DataSource = dt;
                    if (dataGridViewGirdiler.Columns.Contains("OdemeAlindi"))
                        dataGridViewGirdiler.Columns["OdemeAlindi"].HeaderText = "Ödeme Alındı";
                }
            }
        }

        private void LoadTotals()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string today = DateTime.Now.ToString("yyyy-MM-dd");
                string sumQuery = $@"SELECT 
                    SUM(Adet) AS ToplamAdet, 
                    SUM(UrunDegeri) AS ToplamDeger
                    FROM MagazaGirdileri WHERE GirisTarihi = @tarih";
                using (var cmd = new SqlCommand(sumQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@tarih", today);
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridViewToplam.DataSource = dt;
                        if (dataGridViewToplam.Columns.Contains("ToplamAdet"))
                            dataGridViewToplam.Columns["ToplamAdet"].HeaderText = "Günün Toplam Adedi";
                        if (dataGridViewToplam.Columns.Contains("ToplamDeger"))
                            dataGridViewToplam.Columns["ToplamDeger"].HeaderText = "Günün Toplam Değeri";
                    }
                }
            }
        }

        private void ButtonEkle_Click(object sender, EventArgs e)
        {
            string urunKodu = textBoxUrunKodu.Text.Trim();
            string urunAdi = textBoxUrunAdi.Text.Trim();
            string adetStr = textBoxAdet.Text.Trim();
            string musteriAdi = textBoxMusteri.Text.Trim();
            string degerStr = textBoxDeger.Text.Trim();
            bool odemeAlindi = radioOdemeAlindi.Checked;
            DateTime girisTarihi = dateTimePickerTarih.Value.Date;

            if (string.IsNullOrEmpty(urunKodu) || string.IsNullOrEmpty(urunAdi) || string.IsNullOrEmpty(adetStr) || string.IsNullOrEmpty(musteriAdi) || string.IsNullOrEmpty(degerStr))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(adetStr, out int adet) || adet <= 0)
            {
                MessageBox.Show("Adet sayısı pozitif bir sayı olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(degerStr, out decimal urunDegeri) || urunDegeri < 0)
            {
                MessageBox.Show("Ürün değeri geçerli bir sayı olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string insertQuery = @"INSERT INTO MagazaGirdileri (UrunKodu, UrunAdi, Adet, MusteriAdi, UrunDegeri, OdemeAlindi, GirisTarihi)
                    VALUES (@urunKodu, @urunAdi, @adet, @musteriAdi, @urunDegeri, @odemeAlindi, @girisTarihi)";
                using (var cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@urunKodu", urunKodu);
                    cmd.Parameters.AddWithValue("@urunAdi", urunAdi);
                    cmd.Parameters.AddWithValue("@adet", adet);
                    cmd.Parameters.AddWithValue("@musteriAdi", musteriAdi);
                    cmd.Parameters.AddWithValue("@urunDegeri", urunDegeri);
                    cmd.Parameters.AddWithValue("@odemeAlindi", odemeAlindi);
                    cmd.Parameters.AddWithValue("@girisTarihi", girisTarihi);
                    cmd.ExecuteNonQuery();
                }
            }
            LoadData();
            LoadTotals();
            textBoxUrunKodu.Text = "";
            textBoxUrunAdi.Text = "";
            textBoxAdet.Text = "";
            textBoxMusteri.Text = "";
            textBoxDeger.Text = "";
            radioOdemeAlindi.Checked = false;
            radioOdemeAlinmadi.Checked = false;
            dateTimePickerTarih.Value = DateTime.Now;
        }

        private void radioOdemeAlindi_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
} 