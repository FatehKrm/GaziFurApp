using System;
using System.Windows.Forms;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing.Printing;

namespace GaziFurApp
{
    public partial class SenelikRaporForm : Form
    {
        public SenelikRaporForm()
        {
            InitializeComponent();
            comboBoxYear.SelectedIndexChanged += ComboBoxYear_SelectedIndexChanged;
            buttonYazdir = new Button();
            buttonYazdir.Text = "Yazdır";
            buttonYazdir.Location = new System.Drawing.Point(200, 20);
            buttonYazdir.Size = new System.Drawing.Size(120, 35);
            buttonYazdir.BackColor = System.Drawing.Color.PaleGreen;
            buttonYazdir.FlatStyle = FlatStyle.Flat;
            buttonYazdir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            buttonYazdir.ForeColor = System.Drawing.Color.Black;
            buttonYazdir.Click += ButtonYazdir_Click;
            Controls.Add(buttonYazdir);
            labelToplamCikis = new Label();
            labelToplamCikis.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            labelToplamCikis.Location = new System.Drawing.Point(30, 470);
            labelToplamCikis.Size = new System.Drawing.Size(400, 30);
            labelToplamCikis.Text = "Toplam Yıllık Çıkışlar Sayısı: 0";
            Controls.Add(labelToplamCikis);
            dataGridViewSummary = new DataGridView();
            dataGridViewSummary.AllowUserToAddRows = false;
            dataGridViewSummary.AllowUserToDeleteRows = false;
            dataGridViewSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewSummary.ColumnHeadersHeight = 29;
            dataGridViewSummary.Location = new System.Drawing.Point(30, 510);
            dataGridViewSummary.Name = "dataGridViewSummary";
            dataGridViewSummary.ReadOnly = true;
            dataGridViewSummary.RowHeadersWidth = 51;
            dataGridViewSummary.Size = new System.Drawing.Size(700, 100);
            dataGridViewSummary.TabIndex = 5;
            Controls.Add(dataGridViewSummary);
        }

        private void ButtonYazdir_Click(object? sender, EventArgs e)
        {
            if (dataGridView.DataSource == null || lastSelectedYear == 0)
            {
                MessageBox.Show("Lütfen önce bir yıl seçin ve verileri görüntüleyin.");
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
                var dgv = dataGridView;
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
                ev.Graphics.DrawString($"Yıl: {lastSelectedYear}", new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Black, startX, startY);
                ev.Graphics.DrawString($"Toplam Çıkış Miktarı: {lastToplamCikis}", new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Black, startX + 400, startY);
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
                // 2. DataGridView'daki özet
                offsetY += 20;
                ev.Graphics.DrawString("Toplam Çıkış Miktarı:", new System.Drawing.Font("Arial", 11, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Black, startX, startY + offsetY);
                ev.Graphics.DrawString(lastToplamCikis.ToString(), new System.Drawing.Font("Arial", 11, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Black, startX + 250, startY + offsetY);
                ev.HasMorePages = false;
            };
            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = pd;
            preview.ShowDialog();
        }

        private void ComboBoxYear_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (comboBoxYear.SelectedItem == null) return;
            if (!int.TryParse(comboBoxYear.SelectedItem.ToString(), out int year)) return;
            lastSelectedYear = year;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT Satislar.Id, m.Ad + ' ' + m.Soyad AS Musteri, s.UrunAdi, Satislar.Miktar, Satislar.Tutar, Satislar.SatisTarihi, Satislar.Adres, Satislar.Aciklama2, Satislar.Ulke
        FROM Satislar
        LEFT JOIN Musteriler m ON Satislar.MusteriId = m.Id
        LEFT JOIN Stoklar s ON Satislar.UrunId = s.Id
        WHERE YEAR(Satislar.SatisTarihi) = @year
        ORDER BY Satislar.SatisTarihi ASC";
                using (var adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@year", year);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView.DataSource = dt;
                    // Toplam miktar
                    int toplam = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row.Table.Columns.Contains("Miktar") && int.TryParse(row["Miktar"].ToString(), out int miktar))
                            toplam += miktar;
                    }
                    lastToplamCikis = toplam;
                    labelToplamCikis.Text = $"Toplam Yıllık Çıkışlar Sayısı: {toplam}";
                    // 2. DataGridView'a özet ekle
                    DataTable summary = new DataTable();
                    summary.Columns.Add("Açıklama", typeof(string));
                    summary.Columns.Add("Değer", typeof(int));
                    summary.Rows.Add("Toplam Çıkış Miktarı", toplam);
                    dataGridViewSummary.DataSource = summary;
                    dataGridViewSummary.Columns[0].Width = 250;
                    dataGridViewSummary.Columns[1].Width = 100;
                }
            }
        }

        private void InitializeComponent()
        {
            this.dataGridView = new DataGridView();
            this.comboBoxYear = new ComboBox();
            this.SuspendLayout();
            // comboBoxYear
            this.comboBoxYear.Location = new System.Drawing.Point(30, 20);
            this.comboBoxYear.Size = new System.Drawing.Size(120, 27);
            for (int year = DateTime.Now.Year; year >= 2000; year--)
                this.comboBoxYear.Items.Add(year.ToString());
            this.comboBoxYear.SelectedIndex = 0;
            // dataGridView
            this.dataGridView.Location = new System.Drawing.Point(30, 60);
            this.dataGridView.Size = new System.Drawing.Size(700, 400);
            this.dataGridView.ReadOnly = true;
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Form
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.comboBoxYear);
            this.Controls.Add(this.dataGridView);
            this.Text = "Senelik Rapor";
            this.ResumeLayout(false);
        }
        private DataGridView dataGridView;
        private ComboBox comboBoxYear;
        private string connectionString = "Server=DESKTOP-PBR2LIP;Database=GazifurAppDb;Trusted_Connection=True;TrustServerCertificate=True;";
        private int lastToplamCikis = 0;
        private int lastSelectedYear = 0;
        private Button buttonYazdir;
        private Label labelToplamCikis;
        private DataGridView dataGridViewSummary;
    }
} 