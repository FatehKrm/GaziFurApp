namespace GaziFurApp
{
    partial class MusteriGuncelleForm
    {
        private System.Windows.Forms.Label labelAd;
        private System.Windows.Forms.Label labelSoyad;
        private System.Windows.Forms.Label labelTelefon;
        private System.Windows.Forms.Label labelUlke;
        private System.Windows.Forms.TextBox textBoxAd;
        private System.Windows.Forms.TextBox textBoxSoyad;
        private System.Windows.Forms.TextBox textBoxTelefon;
        private System.Windows.Forms.TextBox textBoxUlke;
        private System.Windows.Forms.Button buttonGuncelle;
        private void InitializeComponent()
        {
            this.labelAd = new System.Windows.Forms.Label();
            this.labelSoyad = new System.Windows.Forms.Label();
            this.labelTelefon = new System.Windows.Forms.Label();
            this.labelUlke = new System.Windows.Forms.Label();
            this.textBoxAd = new System.Windows.Forms.TextBox();
            this.textBoxSoyad = new System.Windows.Forms.TextBox();
            this.textBoxTelefon = new System.Windows.Forms.TextBox();
            this.textBoxUlke = new System.Windows.Forms.TextBox();
            this.buttonGuncelle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // labelAd
            this.labelAd.Text = "Ad";
            this.labelAd.Location = new System.Drawing.Point(50, 50);
            this.labelAd.Size = new System.Drawing.Size(100, 30);
            // textBoxAd
            this.textBoxAd.Name = "textBoxAd";
            this.textBoxAd.Location = new System.Drawing.Point(200, 50);
            this.textBoxAd.Size = new System.Drawing.Size(300, 27);
            // labelSoyad
            this.labelSoyad.Text = "Soyad";
            this.labelSoyad.Location = new System.Drawing.Point(50, 100);
            this.labelSoyad.Size = new System.Drawing.Size(100, 30);
            // textBoxSoyad
            this.textBoxSoyad.Name = "textBoxSoyad";
            this.textBoxSoyad.Location = new System.Drawing.Point(200, 100);
            this.textBoxSoyad.Size = new System.Drawing.Size(300, 27);
            // labelTelefon
            this.labelTelefon.Text = "Telefon";
            this.labelTelefon.Location = new System.Drawing.Point(50, 150);
            this.labelTelefon.Size = new System.Drawing.Size(100, 30);
            // textBoxTelefon
            this.textBoxTelefon.Name = "textBoxTelefon";
            this.textBoxTelefon.Location = new System.Drawing.Point(200, 150);
            this.textBoxTelefon.Size = new System.Drawing.Size(300, 27);
            // labelUlke
            this.labelUlke.Text = "Ülke";
            this.labelUlke.Location = new System.Drawing.Point(50, 200);
            this.labelUlke.Size = new System.Drawing.Size(100, 30);
            // textBoxUlke
            this.textBoxUlke.Name = "textBoxUlke";
            this.textBoxUlke.Location = new System.Drawing.Point(200, 200);
            this.textBoxUlke.Size = new System.Drawing.Size(300, 27);
            // buttonGuncelle
            this.buttonGuncelle.Name = "buttonGuncelle";
            this.buttonGuncelle.Text = "Güncelle";
            this.buttonGuncelle.Location = new System.Drawing.Point(200, 260);
            this.buttonGuncelle.Size = new System.Drawing.Size(150, 40);
            this.buttonGuncelle.Click += new System.EventHandler(this.buttonGuncelle_Click);
            // MusteriGuncelleForm
            this.Text = "Müşteri Bilgilerini Güncelle";
            this.ClientSize = new System.Drawing.Size(600, 350);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.labelAd);
            this.Controls.Add(this.textBoxAd);
            this.Controls.Add(this.labelSoyad);
            this.Controls.Add(this.textBoxSoyad);
            this.Controls.Add(this.labelTelefon);
            this.Controls.Add(this.textBoxTelefon);
            this.Controls.Add(this.labelUlke);
            this.Controls.Add(this.textBoxUlke);
            this.Controls.Add(this.buttonGuncelle);
            this.ResumeLayout(false);
        }
    }
} 