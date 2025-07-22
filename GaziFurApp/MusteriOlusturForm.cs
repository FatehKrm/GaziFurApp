using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace GaziFurApp
{
    public partial class MusteriOlusturForm : Form
    {
        private string connectionString = "Server=DESKTOP-PBR2LIP;Database=GazifurAppDb;Trusted_Connection=True;TrustServerCertificate=True;";

        public MusteriOlusturForm()
        {
            InitializeComponent();
            this.Load += MusteriOlusturForm_Load;
            buttonEkle.Click += ButtonEkle_Click;
        }

        private void MusteriOlusturForm_Load(object sender, EventArgs e)
        {
            EnsureTableExists();
            LoadData();
        }

        private void EnsureTableExists()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string createTableQuery = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Musteriler' AND xtype='U')
                CREATE TABLE Musteriler (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    Ad NVARCHAR(50),
                    Soyad NVARCHAR(50),
                    Telefon NVARCHAR(20)
                )";
                using (var cmd = new SqlCommand(createTableQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                // Eksik kolonları ekle
                string addUlke = "IF COL_LENGTH('Musteriler', 'Ulke') IS NULL ALTER TABLE Musteriler ADD Ulke NVARCHAR(50);";
                using (var cmd = new SqlCommand(addUlke, conn)) { cmd.ExecuteNonQuery(); }
            }
        }

        private void LoadData()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string selectQuery = "SELECT Id, Ad, Soyad, Telefon, Ulke FROM Musteriler";
                using (var adapter = new SqlDataAdapter(selectQuery, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    if (dataGridView1.Columns.Contains("Id"))
                    {
                        dataGridView1.Columns["Id"].HeaderText = "Müşteri ID";
                        dataGridView1.Columns["Id"].DisplayIndex = 0;
                        dataGridView1.Columns["Id"].ReadOnly = true;
                    }
                }
            }
        }

        private void ButtonEkle_Click(object sender, EventArgs e)
        {
            string ad = textBoxAd.Text.Trim();
            string soyad = textBoxSoyad.Text.Trim();
            string telefon = textBoxTelefon.Text.Trim();
            string ulke = textBoxUlke.Text.Trim();
            if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad) || string.IsNullOrEmpty(telefon) || string.IsNullOrEmpty(ulke))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string insertQuery = "INSERT INTO Musteriler (Ad, Soyad, Telefon, Ulke) VALUES (@ad, @soyad, @telefon, @ulke)";
                using (var cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ad", ad);
                    cmd.Parameters.AddWithValue("@soyad", soyad);
                    cmd.Parameters.AddWithValue("@telefon", telefon);
                    cmd.Parameters.AddWithValue("@ulke", ulke);
                    cmd.ExecuteNonQuery();
                }
            }
            LoadData();
            textBoxAd.Text = "";
            textBoxSoyad.Text = "";
            textBoxTelefon.Text = "";
            textBoxUlke.Text = "";
        }
    }
} 