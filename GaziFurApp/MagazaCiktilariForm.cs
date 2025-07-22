using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Drawing.Printing;
using System.Drawing; // Added for Color

namespace GaziFurApp
{
    public partial class MagazaCiktilariForm : Form
    {
        private string connectionString = "Server=DESKTOP-PBR2LIP;Database=GazifurAppDb;Trusted_Connection=True;TrustServerCertificate=True;";
        private int? seciliStokId = null;
        public MagazaCiktilariForm()
        {
            InitializeComponent();
            this.Load += MagazaCiktilariForm_Load;
            buttonEkle.Click += ButtonEkle_Click;
            buttonFaturaYazdir.Click += ButtonFaturaYazdir_Click;
            comboBoxUrun.SelectedIndexChanged += ComboBoxUrun_SelectedIndexChanged;
            buttonStokSec.Click += ButtonStokSec_Click;
        }

        private void EnsureSatislarTableExists()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string createTable = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Satislar' AND xtype='U')
                CREATE TABLE Satislar (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    MusteriId INT,
                    UrunId INT,
                    Miktar INT,
                    Tutar DECIMAL(18,2),
                    SatisTarihi DATE,
                    Adres NVARCHAR(200),
                    Ulke NVARCHAR(100)
                )";
                using (var cmd = new SqlCommand(createTable, conn)) { cmd.ExecuteNonQuery(); }
                // Yeni sütun ekle
                string addAciklama2 = "IF COL_LENGTH('Satislar', 'Aciklama2') IS NULL ALTER TABLE Satislar ADD Aciklama2 NVARCHAR(200);";
                using (var cmd = new SqlCommand(addAciklama2, conn)) { cmd.ExecuteNonQuery(); }
            }
        }

        private void ComboBoxUrun_SelectedIndexChanged(object sender, EventArgs e)
        {
            seciliStokId = null;
            dataGridViewStokDetay.DataSource = null;
            dataGridViewStokDetay.Visible = false;
            buttonStokSec.Visible = false;
            if (comboBoxUrun.SelectedIndex >= 0)
            {
                int urunId;
                if (comboBoxUrun.SelectedValue is System.Data.DataRowView drv)
                    urunId = Convert.ToInt32(drv["Id"]);
                else
                    urunId = Convert.ToInt32(comboBoxUrun.SelectedValue);
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Id, UrunAdi, Beden, Renk, Adet FROM Stoklar WHERE Id = @urunId";
                    using (var adapter = new SqlDataAdapter(query, conn))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@urunId", urunId);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            dataGridViewStokDetay.DataSource = dt;
                            dataGridViewStokDetay.Visible = true;
                            buttonStokSec.Visible = true;
                        }
                    }
                }
            }
        }

        private void ButtonStokSec_Click(object sender, EventArgs e)
        {
            if (dataGridViewStokDetay.SelectedRows.Count > 0)
            {
                seciliStokId = Convert.ToInt32(dataGridViewStokDetay.SelectedRows[0].Cells["Id"].Value);
                MessageBox.Show("Stok seçildi! Satış işlemini tamamlayabilirsiniz.");
            }
            else
            {
                MessageBox.Show("Lütfen bir stok satırı seçin.");
            }
        }

        private void ButtonEkle_Click(object sender, EventArgs e)
        {
            if (comboBoxMusteri.SelectedIndex < 0 || comboBoxUrun.SelectedIndex < 0)
            {
                MessageBox.Show("Lütfen müşteri ve ürün seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(textBoxMiktar.Text.Trim(), out int miktar) || miktar <= 0)
            {
                MessageBox.Show("Miktar pozitif bir sayı olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(textBoxTutar.Text.Trim(), out decimal tutar) || tutar < 0)
            {
                MessageBox.Show("Tutar geçerli bir sayı olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!seciliStokId.HasValue)
            {
                MessageBox.Show("Lütfen stok listesinden bir ürün seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int musteriId = (int)comboBoxMusteri.SelectedValue;
            int urunId;
            if (comboBoxUrun.SelectedValue is System.Data.DataRowView drv)
                urunId = Convert.ToInt32(drv["Id"]);
            else
                urunId = Convert.ToInt32(comboBoxUrun.SelectedValue);
            string adres = textBoxAdres.Text.Trim();
            string ulke = textBoxUlke.Text.Trim();
            DateTime satisTarihi = dateTimePickerTarih.Value.Date;
            string aciklama2 = textBoxAciklama2.Text.Trim();

            EnsureSatislarTableExists(); // Tabloyu eklemeden önce kontrol et
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Satış ekle
                string insert = @"INSERT INTO Satislar (MusteriId, UrunId, Miktar, Tutar, SatisTarihi, Adres, Ulke, Aciklama2)
                    VALUES (@musteriId, @urunId, @miktar, @tutar, @tarih, @adres, @ulke, @aciklama2)";
                using (var cmd = new SqlCommand(insert, conn))
                {
                    cmd.Parameters.AddWithValue("@musteriId", musteriId);
                    cmd.Parameters.AddWithValue("@urunId", urunId);
                    cmd.Parameters.AddWithValue("@miktar", miktar);
                    cmd.Parameters.AddWithValue("@tutar", tutar);
                    cmd.Parameters.AddWithValue("@tarih", satisTarihi);
                    cmd.Parameters.AddWithValue("@adres", adres);
                    cmd.Parameters.AddWithValue("@ulke", ulke);
                    cmd.Parameters.AddWithValue("@aciklama2", aciklama2);
                    cmd.ExecuteNonQuery();
                }
                // Stoktan düş
                string update = "UPDATE Stoklar SET Adet = Adet - @satilan WHERE Id = @id";
                using (var cmd = new SqlCommand(update, conn))
                {
                    cmd.Parameters.AddWithValue("@satilan", miktar);
                    cmd.Parameters.AddWithValue("@id", seciliStokId.Value);
                    cmd.ExecuteNonQuery();
                }
            }
            LoadSatislar();
            textBoxMiktar.Text = "";
            textBoxTutar.Text = "";
            textBoxAdres.Text = "";
            textBoxUlke.Text = "";
            textBoxAciklama2.Text = "";
            seciliStokId = null;
            dataGridViewStokDetay.DataSource = null;
            dataGridViewStokDetay.Visible = false;
            buttonStokSec.Visible = false;
        }

        private void ButtonFaturaYazdir_Click(object sender, EventArgs e)
        {
            if (dataGridViewCiktilar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen yazdırmak için bir satış seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var row = dataGridViewCiktilar.SelectedRows[0];
            string musteri = row.Cells["Musteri"].Value?.ToString() ?? "";
            string urun = row.Cells["UrunAdi"].Value?.ToString() ?? "";
            string miktar = row.Cells["Miktar"].Value?.ToString() ?? "";
            string tutar = row.Cells["Tutar"].Value?.ToString() ?? "";
            string tarih = row.Cells["SatisTarihi"].Value?.ToString() ?? DateTime.Now.ToShortDateString();
            string adres = row.Cells["Adres"].Value?.ToString() ?? "";
            string ulke = row.Cells["Ulke"].Value?.ToString() ?? "";
            // Ticari fatura için örnek veriler
            string vergiDairesi = "Merkez";
            string vergiNo = "1234567890";
            string faturaNo = "FTR-" + DateTime.Now.ToString("yyyyMMddHHmmss");
            string birimFiyat = "";
            if (decimal.TryParse(tutar, out decimal tutarDecimal) && int.TryParse(miktar, out int miktarInt) && miktarInt > 0)
                birimFiyat = (tutarDecimal / miktarInt).ToString("N2");
            else
                birimFiyat = tutar;
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += (s, ev) =>
            {
                float y = 80;
                float x = 100;
                Font fBaslik = new Font("Segoe UI", 20, FontStyle.Bold);
                Font f = new Font("Segoe UI", 12);
                Font fBold = new Font("Segoe UI", 12, FontStyle.Bold);
                Pen pen = new Pen(Color.Black, 1);
                // Başlık
                ev.Graphics.DrawString("TİCARİ FATURA", fBaslik, Brushes.Black, x + 200, y); y += 50;
                // Fatura ve müşteri bilgileri
                ev.Graphics.DrawString($"Fatura No: {faturaNo}", f, Brushes.Black, x, y);
                ev.Graphics.DrawString($"Tarih: {tarih}", f, Brushes.Black, x + 350, y); y += 30;
                ev.Graphics.DrawString($"Müşteri: {musteri}", f, Brushes.Black, x, y); y += 25;
                ev.Graphics.DrawString($"Adres: {adres}", f, Brushes.Black, x, y); y += 25;
                ev.Graphics.DrawString($"Ülke: {ulke}", f, Brushes.Black, x, y); y += 25;
                ev.Graphics.DrawString($"Vergi Dairesi: {vergiDairesi}", f, Brushes.Black, x, y);
                ev.Graphics.DrawString($"Vergi No: {vergiNo}", f, Brushes.Black, x + 350, y); y += 40;
                // Tablo başlıkları
                float tableY = y;
                ev.Graphics.DrawLine(pen, x, tableY, x + 600, tableY);
                ev.Graphics.DrawString("Ürün", fBold, Brushes.Black, x + 10, tableY + 5);
                ev.Graphics.DrawString("Miktar", fBold, Brushes.Black, x + 210, tableY + 5);
                ev.Graphics.DrawString("Birim Fiyat", fBold, Brushes.Black, x + 310, tableY + 5);
                ev.Graphics.DrawString("Tutar", fBold, Brushes.Black, x + 460, tableY + 5);
                tableY += 30;
                ev.Graphics.DrawLine(pen, x, tableY, x + 600, tableY);
                // Satır
                ev.Graphics.DrawString(urun, f, Brushes.Black, x + 10, tableY + 5);
                ev.Graphics.DrawString(miktar, f, Brushes.Black, x + 210, tableY + 5);
                ev.Graphics.DrawString(birimFiyat, f, Brushes.Black, x + 310, tableY + 5);
                ev.Graphics.DrawString(tutar + " €", f, Brushes.Black, x + 460, tableY + 5);
                tableY += 30;
                ev.Graphics.DrawLine(pen, x, tableY, x + 600, tableY);
                // Toplam
                tableY += 20;
                ev.Graphics.DrawString("GENEL TOPLAM:", fBold, Brushes.Black, x + 310, tableY);
                ev.Graphics.DrawString(tutar + " €", fBold, Brushes.Black, x + 460, tableY);
                // Alt bilgi
                tableY += 50;
                ev.Graphics.DrawString("Bu fatura bilgisayar ortamında üretilmiştir.", f, Brushes.Black, x, tableY);
            };
            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = pd;
            preview.ShowDialog();
        }

        private void MagazaCiktilariForm_Load(object sender, EventArgs e)
        {
            EnsureSatislarTableExists(); // Form yüklenirken tabloyu kontrol et
            LoadMusteriler();
            LoadUrunler();
            LoadSatislar();
        }

        private void LoadMusteriler()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Id, Ad, Soyad FROM Musteriler ORDER BY Ad, Soyad";
                using (var adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (!dt.Columns.Contains("AdSoyad"))
                        dt.Columns.Add("AdSoyad", typeof(string));
                    foreach (DataRow row in dt.Rows)
                        row["AdSoyad"] = row["Ad"] + " " + row["Soyad"];
                    comboBoxMusteri.DataSource = dt;
                    comboBoxMusteri.DisplayMember = "AdSoyad";
                    comboBoxMusteri.ValueMember = "Id";
                    comboBoxMusteri.SelectedIndex = -1;
                }
            }
        }

        private void LoadUrunler()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Id, UrunAdi FROM Stoklar ORDER BY UrunAdi";
                using (var adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    comboBoxUrun.DataSource = dt;
                    comboBoxUrun.DisplayMember = "UrunAdi";
                    comboBoxUrun.ValueMember = "Id";
                    comboBoxUrun.SelectedIndex = -1;
                }
            }
        }

        private void LoadSatislar()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT Satislar.Id, m.Ad + ' ' + m.Soyad AS Musteri, s.UrunAdi, Satislar.Miktar, Satislar.Tutar, Satislar.SatisTarihi, Satislar.Adres, Satislar.Aciklama2, Satislar.Ulke
                FROM Satislar
                LEFT JOIN Musteriler m ON Satislar.MusteriId = m.Id
                LEFT JOIN Stoklar s ON Satislar.UrunId = s.Id
                ORDER BY Satislar.Id DESC";
                using (var adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewCiktilar.DataSource = dt;
                    if (dataGridViewCiktilar.Columns.Contains("Musteri"))
                        dataGridViewCiktilar.Columns["Musteri"].HeaderText = "Müşteri";
                    if (dataGridViewCiktilar.Columns.Contains("UrunAdi"))
                        dataGridViewCiktilar.Columns["UrunAdi"].HeaderText = "Ürün";
                    if (dataGridViewCiktilar.Columns.Contains("Miktar"))
                        dataGridViewCiktilar.Columns["Miktar"].HeaderText = "Miktar";
                    if (dataGridViewCiktilar.Columns.Contains("Tutar"))
                        dataGridViewCiktilar.Columns["Tutar"].HeaderText = "Tutar";
                    if (dataGridViewCiktilar.Columns.Contains("SatisTarihi"))
                        dataGridViewCiktilar.Columns["SatisTarihi"].HeaderText = "Satış Tarihi";
                    if (dataGridViewCiktilar.Columns.Contains("Adres"))
                        dataGridViewCiktilar.Columns["Adres"].HeaderText = "Adres";
                    if (dataGridViewCiktilar.Columns.Contains("Aciklama2"))
                        dataGridViewCiktilar.Columns["Aciklama2"].HeaderText = "Açıklama";
                    if (dataGridViewCiktilar.Columns.Contains("Ulke"))
                        dataGridViewCiktilar.Columns["Ulke"].HeaderText = "Ülke";
                }
            }
        }
    }
} 