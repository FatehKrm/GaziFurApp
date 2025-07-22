namespace GaziFurApp
{
    partial class MusteriListeleForm
    {
        private System.Windows.Forms.DataGridView dataGridViewMusteriler;
        private System.Windows.Forms.Button buttonSil;
        private System.Windows.Forms.Button buttonGuncelle;
        private System.Windows.Forms.Button buttonYazdir;
        private void InitializeComponent()
        {
            this.dataGridViewMusteriler = new System.Windows.Forms.DataGridView();
            this.buttonSil = new System.Windows.Forms.Button();
            this.buttonGuncelle = new System.Windows.Forms.Button();
            this.buttonYazdir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMusteriler)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewMusteriler
            // 
            this.dataGridViewMusteriler.Location = new System.Drawing.Point(20, 20);
            this.dataGridViewMusteriler.Size = new System.Drawing.Size(900, 600);
            this.dataGridViewMusteriler.Name = "dataGridViewMusteriler";
            this.dataGridViewMusteriler.TabIndex = 0;
            this.dataGridViewMusteriler.ReadOnly = true;
            this.dataGridViewMusteriler.AllowUserToAddRows = false;
            this.dataGridViewMusteriler.AllowUserToDeleteRows = false;
            // 
            // buttonSil
            // 
            this.buttonSil.Location = new System.Drawing.Point(950, 50);
            this.buttonSil.Size = new System.Drawing.Size(200, 50);
            this.buttonSil.Name = "buttonSil";
            this.buttonSil.TabIndex = 1;
            this.buttonSil.Text = "Müşteriyi Sil";
            this.buttonSil.UseVisualStyleBackColor = true;
            this.buttonSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSil.BackColor = System.Drawing.Color.LightCoral;
            this.buttonSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.buttonSil.ForeColor = System.Drawing.Color.Black;
            // 
            // buttonGuncelle
            // 
            this.buttonGuncelle.Location = new System.Drawing.Point(950, 120);
            this.buttonGuncelle.Size = new System.Drawing.Size(200, 50);
            this.buttonGuncelle.Name = "buttonGuncelle";
            this.buttonGuncelle.TabIndex = 2;
            this.buttonGuncelle.Text = "Müşteri Bilgilerini Güncelle";
            this.buttonGuncelle.UseVisualStyleBackColor = true;
            this.buttonGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGuncelle.BackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.buttonGuncelle.ForeColor = System.Drawing.Color.Black;
            // 
            // buttonYazdir
            // 
            this.buttonYazdir.Location = new System.Drawing.Point(950, 190);
            this.buttonYazdir.Size = new System.Drawing.Size(200, 50);
            this.buttonYazdir.Name = "buttonYazdir";
            this.buttonYazdir.TabIndex = 3;
            this.buttonYazdir.Text = "Müşteri Bilgilerini Yazdır";
            this.buttonYazdir.UseVisualStyleBackColor = true;
            this.buttonYazdir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonYazdir.BackColor = System.Drawing.Color.PaleGreen;
            this.buttonYazdir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.buttonYazdir.ForeColor = System.Drawing.Color.Black;
            // 
            // MusteriListeleForm
            // 
            this.Text = "Müşteri Listele";
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.dataGridViewMusteriler);
            this.Controls.Add(this.buttonSil);
            this.Controls.Add(this.buttonGuncelle);
            this.Controls.Add(this.buttonYazdir);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMusteriler)).EndInit();
            this.ResumeLayout(false);
        }
    }
} 