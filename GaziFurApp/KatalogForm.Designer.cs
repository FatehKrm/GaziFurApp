namespace GaziFurApp
{
    partial class KatalogForm
    {
        private System.Windows.Forms.DataGridView dataGridViewKatalog;
        private System.Windows.Forms.TextBox textBoxFiltre;
        private System.Windows.Forms.Button buttonFiltrele;
        private System.Windows.Forms.Label labelFiltre;
        private System.Windows.Forms.Button buttonYazdir;
        private System.Windows.Forms.Label labelToplam;
        private void InitializeComponent()
        {
            this.dataGridViewKatalog = new System.Windows.Forms.DataGridView();
            this.textBoxFiltre = new System.Windows.Forms.TextBox();
            this.buttonFiltrele = new System.Windows.Forms.Button();
            this.labelFiltre = new System.Windows.Forms.Label();
            this.buttonYazdir = new System.Windows.Forms.Button();
            this.labelToplam = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKatalog)).BeginInit();
            this.SuspendLayout();
            // dataGridViewKatalog
            this.dataGridViewKatalog.Location = new System.Drawing.Point(30, 80);
            this.dataGridViewKatalog.Size = new System.Drawing.Size(1500, 700);
            this.dataGridViewKatalog.Name = "dataGridViewKatalog";
            this.dataGridViewKatalog.TabIndex = 0;
            this.dataGridViewKatalog.ReadOnly = true;
            this.dataGridViewKatalog.AllowUserToAddRows = false;
            this.dataGridViewKatalog.AllowUserToDeleteRows = false;
            this.dataGridViewKatalog.RowTemplate.Height = 60;
            this.dataGridViewKatalog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            // labelFiltre
            this.labelFiltre.Text = "Ürün Adı ile Filtrele:";
            this.labelFiltre.Location = new System.Drawing.Point(30, 30);
            this.labelFiltre.Size = new System.Drawing.Size(150, 30);
            // textBoxFiltre
            this.textBoxFiltre.Location = new System.Drawing.Point(180, 30);
            this.textBoxFiltre.Size = new System.Drawing.Size(300, 27);
            // buttonFiltrele
            this.buttonFiltrele.Text = "Filtrele";
            this.buttonFiltrele.Location = new System.Drawing.Point(500, 30);
            this.buttonFiltrele.Size = new System.Drawing.Size(100, 27);
            // labelToplam
            this.labelToplam.Text = "Toplam Ürün: 0";
            this.labelToplam.Location = new System.Drawing.Point(30, 790);
            this.labelToplam.Size = new System.Drawing.Size(300, 30);
            this.labelToplam.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            // buttonYazdir
            this.buttonYazdir.Text = "Yazdır";
            this.buttonYazdir.Location = new System.Drawing.Point(1550, 100);
            this.buttonYazdir.Size = new System.Drawing.Size(120, 40);
            this.buttonYazdir.Name = "buttonYazdir";
            this.buttonYazdir.TabIndex = 10;
            this.buttonYazdir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonYazdir.BackColor = System.Drawing.Color.PaleGreen;
            this.buttonYazdir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.buttonYazdir.ForeColor = System.Drawing.Color.Black;
            // KatalogForm
            this.Text = "Katalog";
            this.ClientSize = new System.Drawing.Size(1700, 850);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.dataGridViewKatalog);
            this.Controls.Add(this.labelFiltre);
            this.Controls.Add(this.textBoxFiltre);
            this.Controls.Add(this.buttonFiltrele);
            this.Controls.Add(this.buttonYazdir);
            this.Controls.Add(this.labelToplam);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKatalog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
} 