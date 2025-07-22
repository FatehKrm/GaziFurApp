namespace GaziFurApp
{
    partial class StokListeleForm
    {
        private System.Windows.Forms.DataGridView dataGridViewStok;
        private System.Windows.Forms.DataGridView dataGridViewToplam;
        private System.Windows.Forms.Label labelFiltre;
        private System.Windows.Forms.TextBox textBoxFiltre;
        private System.Windows.Forms.Button buttonFiltrele;
        private System.Windows.Forms.DataGridView dataGridViewFiltreSonuc;
        private System.Windows.Forms.DataGridView dataGridViewFiltreToplam;
        private System.Windows.Forms.Button buttonSil;
        private System.Windows.Forms.Button buttonYazdir;
        private void InitializeComponent()
        {
            this.dataGridViewStok = new System.Windows.Forms.DataGridView();
            this.dataGridViewToplam = new System.Windows.Forms.DataGridView();
            this.labelFiltre = new System.Windows.Forms.Label();
            this.textBoxFiltre = new System.Windows.Forms.TextBox();
            this.buttonFiltrele = new System.Windows.Forms.Button();
            this.dataGridViewFiltreSonuc = new System.Windows.Forms.DataGridView();
            this.dataGridViewFiltreToplam = new System.Windows.Forms.DataGridView();
            this.buttonSil = new System.Windows.Forms.Button();
            this.buttonYazdir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewToplam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiltreSonuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiltreToplam)).BeginInit();
            this.SuspendLayout();
            // dataGridViewStok
            this.dataGridViewStok.Location = new System.Drawing.Point(30, 30);
            this.dataGridViewStok.Size = new System.Drawing.Size(1500, 500);
            this.dataGridViewStok.Name = "dataGridViewStok";
            this.dataGridViewStok.TabIndex = 0;
            this.dataGridViewStok.ReadOnly = true;
            this.dataGridViewStok.AllowUserToAddRows = false;
            this.dataGridViewStok.AllowUserToDeleteRows = false;
            // dataGridViewToplam
            this.dataGridViewToplam.Location = new System.Drawing.Point(30, 650);
            this.dataGridViewToplam.Size = new System.Drawing.Size(400, 60);
            this.dataGridViewToplam.Name = "dataGridViewToplam";
            this.dataGridViewToplam.TabIndex = 1;
            this.dataGridViewToplam.ReadOnly = true;
            this.dataGridViewToplam.AllowUserToAddRows = false;
            this.dataGridViewToplam.AllowUserToDeleteRows = false;
            // labelFiltre
            this.labelFiltre.Text = "Ürün Adı ile Filtrele:";
            this.labelFiltre.Location = new System.Drawing.Point(500, 650);
            this.labelFiltre.Size = new System.Drawing.Size(150, 30);
            // textBoxFiltre
            this.textBoxFiltre.Location = new System.Drawing.Point(650, 650);
            this.textBoxFiltre.Size = new System.Drawing.Size(200, 27);
            // buttonFiltrele
            this.buttonFiltrele.Text = "Filtrele";
            this.buttonFiltrele.Location = new System.Drawing.Point(870, 650);
            this.buttonFiltrele.Size = new System.Drawing.Size(100, 27);
            // dataGridViewFiltreSonuc
            this.dataGridViewFiltreSonuc.Location = new System.Drawing.Point(500, 690);
            this.dataGridViewFiltreSonuc.Size = new System.Drawing.Size(1230, 80); // Yükseklik azıcık artırıldı, genişlik eski haline alındı
            this.dataGridViewFiltreSonuc.Name = "dataGridViewFiltreSonuc";
            this.dataGridViewFiltreSonuc.TabIndex = 2;
            this.dataGridViewFiltreSonuc.ReadOnly = true;
            this.dataGridViewFiltreSonuc.AllowUserToAddRows = false;
            this.dataGridViewFiltreSonuc.AllowUserToDeleteRows = false;
            // dataGridViewFiltreToplam
            this.dataGridViewFiltreToplam.Location = new System.Drawing.Point(500, 790); // Daha alta çekildi, çakışma önlendi
            this.dataGridViewFiltreToplam.Size = new System.Drawing.Size(400, 60);
            this.dataGridViewFiltreToplam.Name = "dataGridViewFiltreToplam";
            this.dataGridViewFiltreToplam.TabIndex = 3;
            this.dataGridViewFiltreToplam.ReadOnly = true;
            this.dataGridViewFiltreToplam.AllowUserToAddRows = false;
            this.dataGridViewFiltreToplam.AllowUserToDeleteRows = false;
            // buttonSil
            this.buttonSil.Location = new System.Drawing.Point(1550, 50);
            this.buttonSil.Size = new System.Drawing.Size(200, 50);
            this.buttonSil.Name = "buttonSil";
            this.buttonSil.TabIndex = 10;
            this.buttonSil.Text = "Sil";
            this.buttonSil.UseVisualStyleBackColor = true;
            this.buttonSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSil.BackColor = System.Drawing.Color.LightCoral;
            this.buttonSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.buttonSil.ForeColor = System.Drawing.Color.Black;
            // buttonYazdir
            this.buttonYazdir.Location = new System.Drawing.Point(1550, 190);
            this.buttonYazdir.Size = new System.Drawing.Size(200, 50);
            this.buttonYazdir.Name = "buttonYazdir";
            this.buttonYazdir.TabIndex = 12;
            this.buttonYazdir.Text = "Yazdır";
            this.buttonYazdir.UseVisualStyleBackColor = true;
            this.buttonYazdir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonYazdir.BackColor = System.Drawing.Color.PaleGreen;
            this.buttonYazdir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.buttonYazdir.ForeColor = System.Drawing.Color.Black;
            // Form ayarları
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1800, 1000);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.dataGridViewStok);
            this.Controls.Add(this.dataGridViewToplam);
            this.Controls.Add(this.labelFiltre);
            this.Controls.Add(this.textBoxFiltre);
            this.Controls.Add(this.buttonFiltrele);
            this.Controls.Add(this.dataGridViewFiltreSonuc);
            this.Controls.Add(this.dataGridViewFiltreToplam);
            this.Controls.Add(this.buttonSil);
            this.Controls.Add(this.buttonYazdir);
            this.Name = "Stok Listele";
            this.Text = "Stok Listele";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewToplam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiltreSonuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiltreToplam)).EndInit();
            this.ResumeLayout(false);
        }
    }
} 