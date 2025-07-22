using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace GaziFurApp
{
    public partial class MusteriListeleForm : Form
    {
        private string connectionString = "Server=DESKTOP-PBR2LIP;Database=GazifurAppDb;Trusted_Connection=True;TrustServerCertificate=True;";
        private PrintDocument printDocument;
        private PrintPreviewDialog printPreviewDialog;

        public MusteriListeleForm()
        {
            InitializeComponent();
            this.Load += MusteriListeleForm_Load;
            buttonSil.Click += ButtonSil_Click;
            buttonGuncelle.Click += ButtonGuncelle_Click;
            buttonYazdir.Click += ButtonYazdir_Click;
            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;
            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;
        }

        private void MusteriListeleForm_Load(object sender, EventArgs e)
        {
            LoadMusteriler();
        }

        private void LoadMusteriler()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string selectQuery = "SELECT Id, Ad, Soyad, Telefon, Ulke FROM Musteriler";
                using (var adapter = new SqlDataAdapter(selectQuery, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewMusteriler.DataSource = dt;
                    if (dataGridViewMusteriler.Columns.Contains("Id"))
                    {
                        dataGridViewMusteriler.Columns["Id"].HeaderText = "Müşteri ID";
                        dataGridViewMusteriler.Columns["Id"].DisplayIndex = 0;
                        dataGridViewMusteriler.Columns["Id"].ReadOnly = true;
                    }
                }
            }
        }

        private void ButtonSil_Click(object sender, EventArgs e)
        {
            if (dataGridViewMusteriler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir müşteri seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var row = dataGridViewMusteriler.SelectedRows[0];
            int musteriId = (int)row.Cells["Id"].Value;
            var result = MessageBox.Show("Seçili müşteriyi silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM Musteriler WHERE Id = @id";
                    using (var cmd = new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", musteriId);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadMusteriler();
            }
        }

        private void ButtonGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridViewMusteriler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellemek için bir müşteri seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var row = dataGridViewMusteriler.SelectedRows[0];
            int musteriId = (int)row.Cells["Id"].Value;
            MusteriGuncelleForm guncelleForm = new MusteriGuncelleForm(musteriId);
            guncelleForm.ShowDialog();
            LoadMusteriler();
        }

        private void ButtonYazdir_Click(object sender, EventArgs e)
        {
            printPreviewDialog.ShowDialog();
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // DataGridView'i tablo olarak yazdır
            int startX = 40;
            int startY = 40;
            int offsetY = 0;
            int cellHeight = 30;
            int colCount = dataGridViewMusteriler.Columns.Count;
            int[] colWidths = new int[colCount];
            int totalWidth = 0;
            for (int i = 0; i < colCount; i++)
            {
                colWidths[i] = dataGridViewMusteriler.Columns[i].Width;
                totalWidth += colWidths[i];
            }
            // Sığdırmak için oranla
            float scale = Math.Min((e.MarginBounds.Width - 2 * startX) / (float)totalWidth, 1f);
            for (int i = 0; i < colCount; i++)
                colWidths[i] = (int)(colWidths[i] * scale);
            // Sütun başlıkları
            int x = startX;
            for (int i = 0; i < colCount; i++)
            {
                e.Graphics.FillRectangle(Brushes.LightGray, x, startY, colWidths[i], cellHeight);
                e.Graphics.DrawRectangle(Pens.Black, x, startY, colWidths[i], cellHeight);
                e.Graphics.DrawString(dataGridViewMusteriler.Columns[i].HeaderText, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, x + 2, startY + 5);
                x += colWidths[i];
            }
            offsetY += cellHeight;
            // Satırlar
            for (int row = 0; row < dataGridViewMusteriler.Rows.Count; row++)
            {
                if (dataGridViewMusteriler.Rows[row].IsNewRow) continue;
                x = startX;
                for (int col = 0; col < colCount; col++)
                {
                    e.Graphics.FillRectangle(Brushes.White, x, startY + offsetY, colWidths[col], cellHeight);
                    e.Graphics.DrawRectangle(Pens.Black, x, startY + offsetY, colWidths[col], cellHeight);
                    var value = dataGridViewMusteriler.Rows[row].Cells[col].Value?.ToString() ?? "";
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