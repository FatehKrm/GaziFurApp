using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace GaziFurApp
{
    public partial class MusteriGuncelleForm : Form
    {
        private string connectionString = "Server=DESKTOP-PBR2LIP;Database=GazifurAppDb;Trusted_Connection=True;TrustServerCertificate=True;";
        private int musteriId;
        public MusteriGuncelleForm(int musteriId)
        {
            InitializeComponent();
            this.musteriId = musteriId;
            this.Load += MusteriGuncelleForm_Load;
        }

        public MusteriGuncelleForm()
        {
        }

        private void MusteriGuncelleForm_Load(object sender, EventArgs e)
        {
            LoadMusteri();
        }

        private void LoadMusteri()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string selectQuery = "SELECT Ad, Soyad, Telefon, Ulke FROM Musteriler WHERE Id = @id";
                using (var cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@id", musteriId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Formda uygun TextBox'lar varsa doldur
                            if (Controls["textBoxAd"] is TextBox tbAd) tbAd.Text = reader["Ad"].ToString();
                            if (Controls["textBoxSoyad"] is TextBox tbSoyad) tbSoyad.Text = reader["Soyad"].ToString();
                            if (Controls["textBoxTelefon"] is TextBox tbTelefon) tbTelefon.Text = reader["Telefon"].ToString();
                            if (Controls["textBoxUlke"] is TextBox tbUlke) tbUlke.Text = reader["Ulke"].ToString();
                        }
                    }
                }
            }
        }

        // Güncelle butonu eklenmeli ve işlevi
        private void buttonGuncelle_Click(object sender, EventArgs e)
        {
            if (!(Controls["textBoxAd"] is TextBox tbAd) ||
                !(Controls["textBoxSoyad"] is TextBox tbSoyad) ||
                !(Controls["textBoxTelefon"] is TextBox tbTelefon) ||
                !(Controls["textBoxUlke"] is TextBox tbUlke))
            {
                MessageBox.Show("Formda eksik alanlar var.");
                return;
            }
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string updateQuery = "UPDATE Musteriler SET Ad=@ad, Soyad=@soyad, Telefon=@telefon, Ulke=@ulke WHERE Id=@id";
                using (var cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ad", tbAd.Text.Trim());
                    cmd.Parameters.AddWithValue("@soyad", tbSoyad.Text.Trim());
                    cmd.Parameters.AddWithValue("@telefon", tbTelefon.Text.Trim());
                    cmd.Parameters.AddWithValue("@ulke", tbUlke.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", musteriId);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Müşteri bilgileri güncellendi.");
            this.Close();
        }
    }
} 