using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Drawing.Printing;

namespace GaziFurApp
{
    public partial class MusteriOzgecmisForm : Form
    {
        private string connectionString = "Server=DESKTOP-PBR2LIP;Database=GazifurAppDb;Trusted_Connection=True;TrustServerCertificate=True;";
        private int? selectedMusteriId = null;
        private Button buttonYazdir;
        public MusteriOzgecmisForm()
        {
            InitializeComponent();
            this.Load += MusteriOzgecmisForm_Load;
            comboBoxMusteriler.SelectedIndexChanged += ComboBoxMusteriler_SelectedIndexChanged;
            buttonYazdir = new Button();
            buttonYazdir.Text = "Yazdır";
            buttonYazdir.Location = new System.Drawing.Point(1100, 30);
            buttonYazdir.Size = new System.Drawing.Size(120, 35);
            buttonYazdir.BackColor = System.Drawing.Color.PaleGreen;
            buttonYazdir.FlatStyle = FlatStyle.Flat;
            buttonYazdir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            buttonYazdir.ForeColor = System.Drawing.Color.Black;
            buttonYazdir.Click += ButtonYazdir_Click;
            Controls.Add(buttonYazdir);
        }

        private void MusteriOzgecmisForm_Load(object sender, EventArgs e)
        {
            LoadMusteriler();
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
                    // AdSoyad kolonu oluştur
                    if (!dt.Columns.Contains("AdSoyad"))
                        dt.Columns.Add("AdSoyad", typeof(string));
                    foreach (DataRow row in dt.Rows)
                        row["AdSoyad"] = row["Ad"] + " " + row["Soyad"];
                    // ComboBox'a önce 'Müşteri Seçiniz' ekle
                    DataRow firstRow = dt.NewRow();
                    firstRow["Id"] = DBNull.Value;
                    firstRow["AdSoyad"] = "Müşteri Seçiniz";
                    dt.Rows.InsertAt(firstRow, 0);
                    comboBoxMusteriler.DataSource = dt;
                    comboBoxMusteriler.DisplayMember = "AdSoyad";
                    comboBoxMusteriler.ValueMember = "Id";
                    comboBoxMusteriler.SelectedIndex = 0;
                }
            }
        }

        private void ComboBoxMusteriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMusteriler.SelectedValue == null || comboBoxMusteriler.SelectedValue == DBNull.Value)
            {
                dataGridViewGecmis.DataSource = null;
                selectedMusteriId = null;
                return;
            }
            if (int.TryParse(comboBoxMusteriler.SelectedValue.ToString(), out int musteriId))
            {
                selectedMusteriId = musteriId;
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT Satislar.Id, s.UrunAdi, Satislar.Miktar, Satislar.Tutar, Satislar.SatisTarihi, Satislar.Adres, Satislar.Aciklama2, Satislar.Ulke
            FROM Satislar
            LEFT JOIN Stoklar s ON Satislar.UrunId = s.Id
            WHERE Satislar.MusteriId = @musteriId
            ORDER BY Satislar.SatisTarihi DESC";
                    using (var adapter = new SqlDataAdapter(query, conn))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@musteriId", musteriId);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridViewGecmis.DataSource = dt;
                    }
                }
            }
            else
            {
                dataGridViewGecmis.DataSource = null;
                selectedMusteriId = null;
            }
        }

        private void ButtonYazdir_Click(object? sender, EventArgs e)
        {
            if (dataGridViewGecmis.DataSource == null || selectedMusteriId == null)
            {
                MessageBox.Show("Lütfen önce bir müşteri seçin ve verileri görüntüleyin.");
                return;
            }
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.Landscape = true;
            pd.PrintPage += (s, ev) =>
            {
                int startX = 40;
                int startY = 40;
                int offsetY = 0;
                int cellHeight = 32;
                int headerHeight = 40;
                var dgv = dataGridViewGecmis;
                int colCount = dgv.Columns.Count;
                int[] colWidths = new int[colCount];
                int totalWidth = 0;
                for (int i = 0; i < colCount; i++)
                {
                    colWidths[i] = Math.Max(120, dgv.Columns[i].Width); // min 120px
                    totalWidth += colWidths[i];
                }
                float scale = Math.Min((ev.MarginBounds.Width - 2 * startX) / (float)totalWidth, 1f);
                for (int i = 0; i < colCount; i++)
                    colWidths[i] = (int)(colWidths[i] * scale);
                // Başlık
                string musteriAdSoyad = comboBoxMusteriler.Text;
                ev.Graphics.DrawString($"Müşteri: {musteriAdSoyad}", new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Black, startX, startY);
                offsetY += headerHeight;
                // Sütun başlıkları
                int x = startX;
                for (int i = 0; i < colCount; i++)
                {
                    ev.Graphics.FillRectangle(System.Drawing.Brushes.LightGray, x, startY + offsetY, colWidths[i], cellHeight);
                    ev.Graphics.DrawRectangle(System.Drawing.Pens.Black, x, startY + offsetY, colWidths[i], cellHeight);
                    ev.Graphics.DrawString(dgv.Columns[i].HeaderText, new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Black, x + 2, startY + offsetY + 5);
                    x += colWidths[i];
                }
                offsetY += cellHeight;
                // Satırlar
                for (int row = 0; row < dgv.Rows.Count; row++)
                {
                    if (dgv.Rows[row].IsNewRow) continue;
                    x = startX;
                    for (int col = 0; col < colCount; col++)
                    {
                        ev.Graphics.FillRectangle(System.Drawing.Brushes.White, x, startY + offsetY, colWidths[col], cellHeight);
                        ev.Graphics.DrawRectangle(System.Drawing.Pens.Black, x, startY + offsetY, colWidths[col], cellHeight);
                        var value = dgv.Rows[row].Cells[col].Value?.ToString() ?? "";
                        ev.Graphics.DrawString(value, new System.Drawing.Font("Arial", 10), System.Drawing.Brushes.Black, x + 2, startY + offsetY + 5);
                        x += colWidths[col];
                    }
                    offsetY += cellHeight;
                    if (startY + offsetY + cellHeight > ev.MarginBounds.Bottom)
                    {
                        ev.HasMorePages = true;
                        return;
                    }
                }
                ev.HasMorePages = false;
            };
            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = pd;
            preview.ShowDialog();
        }
    }
} 