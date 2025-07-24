using System;
using System.Windows.Forms;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing.Printing;

namespace GaziFurApp
{
    public partial class HaftalikGirislerForm : Form
    {
        public HaftalikGirislerForm()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            dataGridView = new DataGridView();
            dataGridViewSummary = new DataGridView();
            dateTimePicker = new DateTimePicker();
            dateTimePickerStart = new DateTimePicker();
            dateTimePickerEnd = new DateTimePicker();
            buttonFiltrele = new Button();
            buttonYazdir = new Button();
            labelToplamGiris = new Label();
            labelTarihAraligi = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSummary).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeight = 29;
            dataGridView.Location = new Point(464, 120);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(914, 346);
            dataGridView.TabIndex = 4;
            // 
            // dataGridViewSummary
            // 
            dataGridViewSummary.AllowUserToAddRows = false;
            dataGridViewSummary.AllowUserToDeleteRows = false;
            dataGridViewSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewSummary.ColumnHeadersHeight = 29;
            dataGridViewSummary.Location = new Point(464, 493);
            dataGridViewSummary.Name = "dataGridViewSummary";
            dataGridViewSummary.ReadOnly = true;
            dataGridViewSummary.RowHeadersWidth = 51;
            dataGridViewSummary.Size = new Size(700, 100);
            dataGridViewSummary.TabIndex = 5;
            dataGridViewSummary.CellContentClick += dataGridViewSummary_CellContentClick;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(0, 0);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(200, 27);
            dateTimePicker.TabIndex = 0;
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Format = DateTimePickerFormat.Short;
            dateTimePickerStart.Location = new Point(617, 45);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(150, 27);
            dateTimePickerStart.TabIndex = 0;
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Format = DateTimePickerFormat.Short;
            dateTimePickerEnd.Location = new Point(784, 45);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(150, 27);
            dateTimePickerEnd.TabIndex = 1;
            // 
            // buttonFiltrele
            // 
            buttonFiltrele.Location = new Point(966, 45);
            buttonFiltrele.Name = "buttonFiltrele";
            buttonFiltrele.Size = new Size(100, 27);
            buttonFiltrele.TabIndex = 2;
            buttonFiltrele.Text = "Filtrele";
            buttonFiltrele.Click += ButtonFiltrele_Click;
            // 
            // buttonYazdir
            // 
            buttonYazdir.BackColor = Color.SteelBlue;
            buttonYazdir.FlatStyle = FlatStyle.Flat;
            buttonYazdir.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonYazdir.ForeColor = Color.Black;
            buttonYazdir.Location = new Point(1276, 39);
            buttonYazdir.Name = "buttonYazdir";
            buttonYazdir.Size = new Size(150, 40);
            buttonYazdir.TabIndex = 3;
            buttonYazdir.Text = "Yazdır";
            buttonYazdir.UseVisualStyleBackColor = false;
            buttonYazdir.Click += ButtonYazdir_Click;
            // 
            // labelToplamGiris
            // 
            labelToplamGiris.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelToplamGiris.Location = new Point(464, 618);
            labelToplamGiris.Name = "labelToplamGiris";
            labelToplamGiris.Size = new Size(400, 30);
            labelToplamGiris.TabIndex = 6;
            labelToplamGiris.Text = "Toplam Haftalık Girişler Sayısı: 0";
            // 
            // labelTarihAraligi
            // 
            labelTarihAraligi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelTarihAraligi.Location = new Point(617, 15);
            labelTarihAraligi.Name = "labelTarihAraligi";
            labelTarihAraligi.Size = new Size(200, 25);
            labelTarihAraligi.TabIndex = 0;
            labelTarihAraligi.Text = "Tarih Aralığı Seçiniz:";
            // 
            // HaftalikGirislerForm
            // 
            ClientSize = new Size(1718, 719);
            Controls.Add(labelTarihAraligi);
            Controls.Add(dateTimePickerStart);
            Controls.Add(dateTimePickerEnd);
            Controls.Add(buttonFiltrele);
            Controls.Add(buttonYazdir);
            Controls.Add(dataGridView);
            Controls.Add(dataGridViewSummary);
            Controls.Add(labelToplamGiris);
            Name = "HaftalikGirislerForm";
            Text = "Haftalık Girişler";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSummary).EndInit();
            ResumeLayout(false);
        }

        private int lastToplamGiris = 0;
        private DateTime lastStartDate;
        private DateTime lastEndDate;

        private void ButtonYazdir_Click(object? sender, EventArgs e)
        {
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
                // Tarih aralığı ve toplam başlık
                string tarihAraligi = $"Tarih Aralığı: {lastStartDate:dd.MM.yyyy} - {lastEndDate:dd.MM.yyyy}";
                string toplamStr = $"Toplam Girilen Mal Sayısı: {lastToplamGiris}";
                ev.Graphics.DrawString(tarihAraligi, new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Black, startX, startY);
                ev.Graphics.DrawString(toplamStr, new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Black, startX + 400, startY);
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
                ev.Graphics.DrawString("Toplam Girilen Mal Sayısı:", new System.Drawing.Font("Arial", 11, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Black, startX, startY + offsetY);
                ev.Graphics.DrawString(lastToplamGiris.ToString(), new System.Drawing.Font("Arial", 11, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Black, startX + 250, startY + offsetY);
                ev.HasMorePages = false;
            };
            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = pd;
            preview.ShowDialog();
        }

        private void ButtonFiltrele_Click(object? sender, EventArgs e)
        {
            DateTime start = dateTimePickerStart.Value.Date;
            DateTime end = dateTimePickerEnd.Value.Date;
            lastStartDate = start;
            lastEndDate = end;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM MagazaGirdileri WHERE GirisTarihi >= @start AND GirisTarihi <= @end";
                using (var adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@start", start);
                    adapter.SelectCommand.Parameters.AddWithValue("@end", end);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView.DataSource = dt;
                    // Toplam adet
                    int toplam = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row.Table.Columns.Contains("Adet") && int.TryParse(row["Adet"].ToString(), out int adet))
                            toplam += adet;
                    }
                    lastToplamGiris = toplam;
                    labelToplamGiris.Text = $"Toplam Haftalık Girişler Sayısı: {toplam}";
                    // 2. DataGridView'a özet ekle
                    DataTable summary = new DataTable();
                    summary.Columns.Add("Açıklama", typeof(string));
                    summary.Columns.Add("Değer", typeof(int));
                    summary.Rows.Add("Toplam Girilen Mal Sayısı", toplam);
                    dataGridViewSummary.DataSource = summary;
                    dataGridViewSummary.Columns[0].Width = 250;
                    dataGridViewSummary.Columns[1].Width = 100;
                }
            }
        }

        private DataGridView dataGridView;
        private DateTimePicker dateTimePicker;
        private Button buttonYazdir;
        private DataGridView dataGridViewSummary;
        private Label labelToplamGiris;
        private DateTimePicker dateTimePickerStart;
        private DateTimePicker dateTimePickerEnd;
        private Button buttonFiltrele;
        private string connectionString = "Server=DESKTOP-PBR2LIP;Database=GazifurAppDb;Trusted_Connection=True;TrustServerCertificate=True;";
        private Label labelTarihAraligi;

        private void dataGridViewSummary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
} 