using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Drawing.Printing;
using System.Linq;

namespace GaziFurApp
{
    public partial class StokListeleForm : Form
    {
        private string connectionString = "Server=DESKTOP-PBR2LIP;Database=GazifurAppDb;Trusted_Connection=True;TrustServerCertificate=True;";

        private PrintDocument printDocument;
        private PrintPreviewDialog printPreviewDialog;

        public StokListeleForm()
        {
            InitializeComponent();
            this.Load += StokListeleForm_Load;
            buttonSil.Click += ButtonSil_Click;
            buttonYazdir.Click += ButtonYazdir_Click;
            buttonFiltrele.Click += ButtonFiltrele_Click;
            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;
            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;
        }

        private void StokListeleForm_Load(object sender, EventArgs e)
        {
            LoadStoklar();
            LoadToplamAdet();
        }

        private void LoadStoklar()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string selectQuery = "SELECT Id, UrunAdi, Beden, Adet, Renk, FotoPath, UrunMevcut, Price FROM Stoklar ORDER BY Id DESC";
                using (var adapter = new SqlDataAdapter(selectQuery, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewStok.DataSource = dt;
                    if (dataGridViewStok.Columns.Contains("Id"))
                    {
                        dataGridViewStok.Columns["Id"].HeaderText = "Stok ID";
                        dataGridViewStok.Columns["Id"].DisplayIndex = 0;
                        dataGridViewStok.Columns["Id"].ReadOnly = true;
                    }
                    if (dataGridViewStok.Columns.Contains("Price"))
                        dataGridViewStok.Columns["Price"].HeaderText = "Fiyat";
                }
            }
        }

        private void LoadToplamAdet()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sumQuery = "SELECT SUM(Adet) AS ToplamAdet FROM Stoklar";
                using (var adapter = new SqlDataAdapter(sumQuery, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewToplam.DataSource = dt;
                    if (dataGridViewToplam.Columns.Contains("ToplamAdet"))
                        dataGridViewToplam.Columns["ToplamAdet"].HeaderText = "Toplam Ürün Adeti";
                }
            }
        }

        private void ButtonSil_Click(object sender, EventArgs e)
        {
            if (dataGridViewStok.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir stok seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var row = dataGridViewStok.SelectedRows[0];
            int stokId = (int)row.Cells["Id"].Value;
            var result = MessageBox.Show("Seçili ürünü silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM Stoklar WHERE Id = @id";
                    using (var cmd = new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", stokId);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadStoklar();
                LoadToplamAdet();
            }
        }

        private void ButtonYazdir_Click(object sender, EventArgs e)
        {
            printPreviewDialog.ShowDialog();
        }

        private void ButtonFiltrele_Click(object sender, EventArgs e)
        {
            string urunAdi = textBoxFiltre.Text.Trim();
            if (string.IsNullOrEmpty(urunAdi))
            {
                MessageBox.Show("Lütfen filtrelemek için bir ürün adı girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string filterQuery = "SELECT Id, UrunAdi, Beden, Adet, Renk, FotoPath, UrunMevcut FROM Stoklar WHERE UrunAdi LIKE @urunAdi ORDER BY Id DESC";
                using (var adapter = new SqlDataAdapter(filterQuery, conn))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@urunAdi", "%" + urunAdi + "%");
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewFiltreSonuc.DataSource = dt;
                }
                // Filtrelenen toplam adet
                string sumQuery = "SELECT SUM(Adet) AS FiltreToplamAdet FROM Stoklar WHERE UrunAdi LIKE @urunAdi";
                using (var cmd = new SqlCommand(sumQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@urunAdi", "%" + urunAdi + "%");
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridViewFiltreToplam.DataSource = dt;
                        if (dataGridViewFiltreToplam.Columns.Contains("FiltreToplamAdet"))
                            dataGridViewFiltreToplam.Columns["FiltreToplamAdet"].HeaderText = "Filtrelenen Toplam Adet";
                    }
                }
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            int startX = 40;
            int startY = 40;
            int offsetY = 0;
            int cellHeight = 30;
            // FotoPath hariç sütunları bul
            var visibleColumns = dataGridViewStok.Columns.Cast<DataGridViewColumn>()
                .Where(c => c.Visible && c.Name != "FotoPath").ToList();
            int colCount = visibleColumns.Count;
            int[] colWidths = new int[colCount];
            int totalWidth = 0;
            for (int i = 0; i < colCount; i++)
            {
                colWidths[i] = visibleColumns[i].Width;
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
            for (int row = 0; row < dataGridViewStok.Rows.Count; row++)
            {
                if (dataGridViewStok.Rows[row].IsNewRow) continue;
                x = startX;
                for (int col = 0; col < colCount; col++)
                {
                    e.Graphics.FillRectangle(Brushes.White, x, startY + offsetY, colWidths[col], cellHeight);
                    e.Graphics.DrawRectangle(Pens.Black, x, startY + offsetY, colWidths[col], cellHeight);
                    var value = dataGridViewStok.Rows[row].Cells[visibleColumns[col].Name].Value?.ToString() ?? "";
                    e.Graphics.DrawString(value, new Font("Arial", 10), Brushes.Black, x + 2, startY + offsetY + 5);
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