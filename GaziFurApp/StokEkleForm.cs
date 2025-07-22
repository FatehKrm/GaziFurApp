using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.IO;

namespace GaziFurApp
{
    public partial class StokEkleForm : Form
    {
        private string connectionString = "Server=DESKTOP-PBR2LIP;Database=GazifurAppDb;Trusted_Connection=True;TrustServerCertificate=True;";
        private string selectedFotoPath = "";

        public StokEkleForm()
        {
            InitializeComponent();
            this.Load += StokEkleForm_Load;
            buttonEkle.Click += ButtonEkle_Click;
            buttonFotoSec.Click += ButtonFotoSec_Click;
        }

        private void StokEkleForm_Load(object sender, EventArgs e)
        {
            EnsureTableExists();
            LoadData();
        }

        private void EnsureTableExists()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string createTableQuery = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Stoklar' AND xtype='U')
                CREATE TABLE Stoklar (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    UrunAdi NVARCHAR(100),
                    Beden NVARCHAR(50),
                    Adet INT,
                    Renk NVARCHAR(50)
                )";
                using (var cmd = new SqlCommand(createTableQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                // Eksik kolonları ekle
                string addFotoPath = "IF COL_LENGTH('Stoklar', 'FotoPath') IS NULL ALTER TABLE Stoklar ADD FotoPath NVARCHAR(300);";
                string addUrunMevcut = "IF COL_LENGTH('Stoklar', 'UrunMevcut') IS NULL ALTER TABLE Stoklar ADD UrunMevcut BIT;";
                string addPrice = "IF COL_LENGTH('Stoklar', 'Price') IS NULL ALTER TABLE Stoklar ADD Price DECIMAL(18,2);";
                using (var cmd = new SqlCommand(addFotoPath, conn)) { cmd.ExecuteNonQuery(); }
                using (var cmd = new SqlCommand(addUrunMevcut, conn)) { cmd.ExecuteNonQuery(); }
                using (var cmd = new SqlCommand(addPrice, conn)) { cmd.ExecuteNonQuery(); }
            }
        }

        private void LoadData()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string selectQuery = "SELECT Id, UrunAdi, Beden, Adet, Renk, FotoPath, UrunMevcut, Price FROM Stoklar ORDER BY Id DESC";
                using (var adapter = new SqlDataAdapter(selectQuery, conn))
                {
                    var dt = new System.Data.DataTable();
                    adapter.Fill(dt);
                    dataGridViewStok.DataSource = dt;
                    if (dataGridViewStok.Columns.Contains("UrunMevcut"))
                        dataGridViewStok.Columns["UrunMevcut"].HeaderText = "Ürün Mevcut mu?";
                    if (dataGridViewStok.Columns.Contains("Price"))
                        dataGridViewStok.Columns["Price"].HeaderText = "Fiyat";
                }
            }
        }

        private void ButtonFotoSec_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedFotoPath = ofd.FileName;
                    pictureBoxFoto.ImageLocation = selectedFotoPath;
                }
            }
        }

        private void ButtonEkle_Click(object sender, EventArgs e)
        {
            string urunAdi = textBoxUrunAdi.Text.Trim();
            string beden = textBoxBeden.Text.Trim();
            string adetStr = textBoxAdet.Text.Trim();
            string renk = textBoxRenk.Text.Trim();
            string priceStr = textBoxPrice.Text.Trim();
            bool urunMevcut = radioMevcutEvet.Checked;
            string fotoPath = selectedFotoPath;

            if (string.IsNullOrEmpty(urunAdi) || string.IsNullOrEmpty(beden) || string.IsNullOrEmpty(adetStr) || string.IsNullOrEmpty(renk) || string.IsNullOrEmpty(priceStr))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(adetStr, out int adet) || adet < 0)
            {
                MessageBox.Show("Adet sayısı pozitif bir sayı olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(priceStr, out decimal price) || price < 0)
            {
                MessageBox.Show("Fiyat geçerli bir sayı olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string insertQuery = @"INSERT INTO Stoklar (UrunAdi, Beden, Adet, Renk, FotoPath, UrunMevcut, Price)
                    VALUES (@urunAdi, @beden, @adet, @renk, @fotoPath, @urunMevcut, @price)";
                using (var cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@urunAdi", urunAdi);
                    cmd.Parameters.AddWithValue("@beden", beden);
                    cmd.Parameters.AddWithValue("@adet", adet);
                    cmd.Parameters.AddWithValue("@renk", renk);
                    cmd.Parameters.AddWithValue("@fotoPath", string.IsNullOrEmpty(fotoPath) ? DBNull.Value : (object)fotoPath);
                    cmd.Parameters.AddWithValue("@urunMevcut", urunMevcut);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.ExecuteNonQuery();
                }
            }
            LoadData();
            textBoxUrunAdi.Text = "";
            textBoxBeden.Text = "";
            textBoxAdet.Text = "";
            textBoxRenk.Text = "";
            textBoxPrice.Text = "";
            pictureBoxFoto.Image = null;
            selectedFotoPath = "";
            radioMevcutEvet.Checked = false;
            radioMevcutHayir.Checked = false;
        }
    }
} 