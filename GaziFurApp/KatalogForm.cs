using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Drawing.Printing;
using System.Linq;

namespace GaziFurApp
{
    public partial class KatalogForm : Form
    {
        private string connectionString = "Server=DESKTOP-PBR2LIP;Database=GazifurAppDb;Trusted_Connection=True;TrustServerCertificate=True;";
        private PrintDocument printDocument;
        private PrintPreviewDialog printPreviewDialog;

        public KatalogForm()
        {
            InitializeComponent();
            this.Load += KatalogForm_Load;
            buttonFiltrele.Click += ButtonFiltrele_Click;
            buttonYazdir.Click += ButtonYazdir_Click;
            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;
            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;
            EnsureTableHasPriceColumn();
        }

        private void EnsureTableHasPriceColumn()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string addPrice = "IF COL_LENGTH('Stoklar', 'Price') IS NULL ALTER TABLE Stoklar ADD Price DECIMAL(18,2);";
                using (var cmd = new SqlCommand(addPrice, conn)) { cmd.ExecuteNonQuery(); }
            }
        }

        private void KatalogForm_Load(object sender, EventArgs e)
        {
            LoadKatalog();
        }

        private void ButtonFiltrele_Click(object sender, EventArgs e)
        {
            LoadKatalog(textBoxFiltre.Text.Trim());
        }

        private void LoadKatalog(string urunAdi = "")
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT UrunAdi, Beden, Renk, FotoPath, Price FROM Stoklar";
                if (!string.IsNullOrEmpty(urunAdi))
                    query += " WHERE UrunAdi LIKE @urunAdi";
                using (var cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(urunAdi))
                        cmd.Parameters.AddWithValue("@urunAdi", "%" + urunAdi + "%");
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        // Fotoğraf sütunu ekle
                        if (!dt.Columns.Contains("Foto"))
                            dt.Columns.Add("Foto", typeof(Image));
                        foreach (DataRow row in dt.Rows)
                        {
                            string fotoPath = row["FotoPath"]?.ToString();
                            if (!string.IsNullOrEmpty(fotoPath) && File.Exists(fotoPath))
                            {
                                try
                                {
                                    using (var img = Image.FromFile(fotoPath))
                                    {
                                        // Küçük boyutlu bir kopya oluştur
                                        row["Foto"] = new Bitmap(img, new Size(110, 110));
                                    }
                                }
                                catch { row["Foto"] = null; }
                            }
                            else
                            {
                                row["Foto"] = null;
                            }
                        }
                        dataGridViewKatalog.Columns.Clear();
                        dataGridViewKatalog.DataSource = dt;
                        // Fotoğraf sütununu DataGridViewImageColumn olarak ayarla
                        if (dataGridViewKatalog.Columns.Contains("Foto"))
                        {
                            var imgCol = dataGridViewKatalog.Columns["Foto"] as DataGridViewImageColumn;
                            if (imgCol == null)
                            {
                                int idx = dataGridViewKatalog.Columns["Foto"].Index;
                                dataGridViewKatalog.Columns.Remove("Foto");
                                imgCol = new DataGridViewImageColumn();
                                imgCol.Name = "Foto";
                                imgCol.HeaderText = "Fotoğraf";
                                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                                dataGridViewKatalog.Columns.Insert(idx, imgCol);
                            }
                            dataGridViewKatalog.Columns["Foto"].DisplayIndex = 0;
                            dataGridViewKatalog.Columns["Foto"].Width = 120;
                        }
                        // Sadece gerekli sütunlar
                        if (dataGridViewKatalog.Columns.Contains("FotoPath"))
                            dataGridViewKatalog.Columns["FotoPath"].Visible = false;
                        if (dataGridViewKatalog.Columns.Contains("UrunAdi"))
                            dataGridViewKatalog.Columns["UrunAdi"].HeaderText = "Ürün Adı";
                        if (dataGridViewKatalog.Columns.Contains("Beden"))
                            dataGridViewKatalog.Columns["Beden"].HeaderText = "Beden";
                        if (dataGridViewKatalog.Columns.Contains("Renk"))
                            dataGridViewKatalog.Columns["Renk"].HeaderText = "Renk";
                        if (dataGridViewKatalog.Columns.Contains("Price"))
                            dataGridViewKatalog.Columns["Price"].HeaderText = "Fiyat";
                        // Satır yüksekliğini sabit tut
                        dataGridViewKatalog.RowTemplate.Height = 120;
                        dataGridViewKatalog.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                        // Toplam ürün sayısı
                        labelToplam.Text = $"Toplam Ürün: {dt.Rows.Count}";
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
            int startX = 40;
            int startY = 40;
            int offsetY = 0;
            int cellHeight = 120;
            var visibleColumns = dataGridViewKatalog.Columns.Cast<DataGridViewColumn>()
                .Where(c => c.Visible).ToList();
            int colCount = visibleColumns.Count;
            int[] colWidths = new int[colCount];
            int totalWidth = 0;
            for (int i = 0; i < colCount; i++)
            {
                if (visibleColumns[i].Name == "Foto")
                    colWidths[i] = 180; // Sadece yazdırmada geniş olsun
                else
                    colWidths[i] = dataGridViewKatalog.Columns[visibleColumns[i].Name].Width;
                totalWidth += colWidths[i];
            }
            float scale = Math.Min((e.MarginBounds.Width - 2 * startX) / (float)totalWidth, 1f);
            for (int i = 0; i < colCount; i++)
                colWidths[i] = (int)(colWidths[i] * scale);
            int x = startX;
            for (int i = 0; i < colCount; i++)
            {
                e.Graphics.FillRectangle(Brushes.LightGray, x, startY, colWidths[i], cellHeight);
                e.Graphics.DrawRectangle(Pens.Black, x, startY, colWidths[i], cellHeight);
                e.Graphics.DrawString(visibleColumns[i].HeaderText, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, x + 2, startY + 5);
                x += colWidths[i];
            }
            offsetY += cellHeight;
            for (int row = 0; row < dataGridViewKatalog.Rows.Count; row++)
            {
                if (dataGridViewKatalog.Rows[row].IsNewRow) continue;
                x = startX;
                for (int col = 0; col < colCount; col++)
                {
                    e.Graphics.FillRectangle(Brushes.White, x, startY + offsetY, colWidths[col], cellHeight);
                    e.Graphics.DrawRectangle(Pens.Black, x, startY + offsetY, colWidths[col], cellHeight);
                    var value = dataGridViewKatalog.Rows[row].Cells[visibleColumns[col].Name].Value;
                    if (visibleColumns[col].Name == "Foto" && value is Image img)
                    {
                        e.Graphics.DrawImage(img, new Rectangle(x + 2, startY + offsetY + 2, colWidths[col] - 4, cellHeight - 4));
                    }
                    else
                    {
                        e.Graphics.DrawString(value?.ToString() ?? "", new Font("Arial", 10), Brushes.Black, x + 2, startY + offsetY + 5);
                    }
                    x += colWidths[col];
                }
                offsetY += cellHeight;
                if (startY + offsetY + cellHeight > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }
            e.HasMorePages = false;
        }
    }
} 