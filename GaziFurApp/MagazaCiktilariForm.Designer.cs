namespace GaziFurApp
{
    partial class MagazaCiktilariForm
    {
        private System.Windows.Forms.Label labelUrun;
        private System.Windows.Forms.ComboBox comboBoxMusteri;
        private System.Windows.Forms.ComboBox comboBoxUrun;
        private System.Windows.Forms.Label labelMiktar;
        private System.Windows.Forms.TextBox textBoxMiktar;
        private System.Windows.Forms.Label labelTutar;
        private System.Windows.Forms.TextBox textBoxTutar;
        private System.Windows.Forms.Label labelTarih;
        private System.Windows.Forms.DateTimePicker dateTimePickerTarih;
        private System.Windows.Forms.Label labelAdres;
        private System.Windows.Forms.TextBox textBoxAdres;
        private System.Windows.Forms.Label labelUlke;
        private System.Windows.Forms.TextBox textBoxUlke;
        private System.Windows.Forms.Button buttonEkle;
        private System.Windows.Forms.Button buttonFaturaYazdir;
        private System.Windows.Forms.DataGridView dataGridViewCiktilar;
        private System.Windows.Forms.Label labelMusteriSec;
        private System.Windows.Forms.DataGridView dataGridViewStokDetay;
        private System.Windows.Forms.Button buttonStokSec;
        private System.Windows.Forms.Label labelAciklama2;
        private System.Windows.Forms.TextBox textBoxAciklama2;
        private void InitializeComponent()
        {
            labelUrun = new Label();
            comboBoxMusteri = new ComboBox();
            comboBoxUrun = new ComboBox();
            labelMiktar = new Label();
            textBoxMiktar = new TextBox();
            labelTutar = new Label();
            textBoxTutar = new TextBox();
            labelTarih = new Label();
            dateTimePickerTarih = new DateTimePicker();
            labelAdres = new Label();
            textBoxAdres = new TextBox();
            labelUlke = new Label();
            textBoxUlke = new TextBox();
            buttonEkle = new Button();
            buttonFaturaYazdir = new Button();
            dataGridViewCiktilar = new DataGridView();
            labelMusteriSec = new Label();
            dataGridViewStokDetay = new DataGridView();
            buttonStokSec = new Button();
            labelAciklama2 = new Label();
            textBoxAciklama2 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCiktilar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStokDetay).BeginInit();
            SuspendLayout();
            // 
            // labelUrun
            // 
            labelUrun.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelUrun.Location = new Point(200, 90);
            labelUrun.Name = "labelUrun";
            labelUrun.Size = new Size(120, 30);
            labelUrun.TabIndex = 104;
            labelUrun.Text = "Ürün";
            // 
            // comboBoxMusteri
            // 
            comboBoxMusteri.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMusteri.Location = new Point(350, 40);
            comboBoxMusteri.Name = "comboBoxMusteri";
            comboBoxMusteri.Size = new Size(400, 28);
            comboBoxMusteri.TabIndex = 103;
            // 
            // comboBoxUrun
            // 
            comboBoxUrun.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxUrun.Location = new Point(350, 90);
            comboBoxUrun.Name = "comboBoxUrun";
            comboBoxUrun.Size = new Size(400, 28);
            comboBoxUrun.TabIndex = 105;
            // 
            // labelMiktar
            // 
            labelMiktar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelMiktar.Location = new Point(200, 140);
            labelMiktar.Name = "labelMiktar";
            labelMiktar.Size = new Size(120, 30);
            labelMiktar.TabIndex = 106;
            labelMiktar.Text = "Miktar";
            // 
            // textBoxMiktar
            // 
            textBoxMiktar.Location = new Point(350, 140);
            textBoxMiktar.Name = "textBoxMiktar";
            textBoxMiktar.Size = new Size(400, 27);
            textBoxMiktar.TabIndex = 107;
            // 
            // labelTutar
            // 
            labelTutar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelTutar.Location = new Point(200, 190);
            labelTutar.Name = "labelTutar";
            labelTutar.Size = new Size(120, 30);
            labelTutar.TabIndex = 108;
            labelTutar.Text = "Satılan Tutar";
            // 
            // textBoxTutar
            // 
            textBoxTutar.Location = new Point(350, 190);
            textBoxTutar.Name = "textBoxTutar";
            textBoxTutar.Size = new Size(400, 27);
            textBoxTutar.TabIndex = 109;
            // 
            // labelTarih
            // 
            labelTarih.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelTarih.Location = new Point(200, 240);
            labelTarih.Name = "labelTarih";
            labelTarih.Size = new Size(120, 30);
            labelTarih.TabIndex = 110;
            labelTarih.Text = "Satış Tarihi";
            // 
            // dateTimePickerTarih
            // 
            dateTimePickerTarih.Format = DateTimePickerFormat.Short;
            dateTimePickerTarih.Location = new Point(350, 240);
            dateTimePickerTarih.Name = "dateTimePickerTarih";
            dateTimePickerTarih.Size = new Size(400, 27);
            dateTimePickerTarih.TabIndex = 111;
            // 
            // labelAdres
            // 
            labelAdres.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelAdres.Location = new Point(200, 290);
            labelAdres.Name = "labelAdres";
            labelAdres.Size = new Size(120, 30);
            labelAdres.TabIndex = 112;
            labelAdres.Text = "Adres";
            // 
            // textBoxAdres
            // 
            textBoxAdres.Location = new Point(350, 290);
            textBoxAdres.Name = "textBoxAdres";
            textBoxAdres.Size = new Size(400, 27);
            textBoxAdres.TabIndex = 113;
            // 
            // labelUlke
            // 
            labelUlke.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelUlke.Location = new Point(200, 370);
            labelUlke.Name = "labelUlke";
            labelUlke.Size = new Size(120, 30);
            labelUlke.TabIndex = 114;
            labelUlke.Text = "Satılan Ülke";
            // 
            // textBoxUlke
            // 
            textBoxUlke.Location = new Point(350, 370);
            textBoxUlke.Name = "textBoxUlke";
            textBoxUlke.Size = new Size(400, 27);
            textBoxUlke.TabIndex = 115;
            // 
            // buttonEkle
            // 
            buttonEkle.BackColor = Color.Gold;
            buttonEkle.FlatStyle = FlatStyle.Flat;
            buttonEkle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonEkle.ForeColor = Color.Navy;
            buttonEkle.Location = new Point(350, 420);
            buttonEkle.Name = "buttonEkle";
            buttonEkle.Size = new Size(120, 40);
            buttonEkle.TabIndex = 116;
            buttonEkle.Text = "Ekle";
            buttonEkle.UseVisualStyleBackColor = false;
            // 
            // buttonFaturaYazdir
            // 
            buttonFaturaYazdir.BackColor = Color.SteelBlue;
            buttonFaturaYazdir.FlatStyle = FlatStyle.Flat;
            buttonFaturaYazdir.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            buttonFaturaYazdir.ForeColor = Color.Black;
            buttonFaturaYazdir.Location = new Point(500, 420);
            buttonFaturaYazdir.Name = "buttonFaturaYazdir";
            buttonFaturaYazdir.Size = new Size(150, 40);
            buttonFaturaYazdir.TabIndex = 117;
            buttonFaturaYazdir.Text = "Faturayı Yazdır";
            buttonFaturaYazdir.UseVisualStyleBackColor = false;
            // 
            // dataGridViewCiktilar
            // 
            dataGridViewCiktilar.AllowUserToAddRows = false;
            dataGridViewCiktilar.AllowUserToDeleteRows = false;
            dataGridViewCiktilar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCiktilar.ColumnHeadersHeight = 29;
            dataGridViewCiktilar.Location = new Point(50, 476);
            dataGridViewCiktilar.Name = "dataGridViewCiktilar";
            dataGridViewCiktilar.ReadOnly = true;
            dataGridViewCiktilar.RowHeadersWidth = 51;
            dataGridViewCiktilar.Size = new Size(1421, 500);
            dataGridViewCiktilar.TabIndex = 0;
            // 
            // labelMusteriSec
            // 
            labelMusteriSec.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelMusteriSec.Location = new Point(200, 40);
            labelMusteriSec.Name = "labelMusteriSec";
            labelMusteriSec.Size = new Size(120, 30);
            labelMusteriSec.TabIndex = 102;
            labelMusteriSec.Text = "Müşteri Seçiniz";
            // 
            // dataGridViewStokDetay
            // 
            dataGridViewStokDetay.AllowUserToAddRows = false;
            dataGridViewStokDetay.AllowUserToDeleteRows = false;
            dataGridViewStokDetay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewStokDetay.ColumnHeadersHeight = 29;
            dataGridViewStokDetay.Location = new Point(800, 90);
            dataGridViewStokDetay.Name = "dataGridViewStokDetay";
            dataGridViewStokDetay.ReadOnly = true;
            dataGridViewStokDetay.RowHeadersWidth = 51;
            dataGridViewStokDetay.Size = new Size(600, 200);
            dataGridViewStokDetay.TabIndex = 100;
            dataGridViewStokDetay.Visible = false;
            // 
            // buttonStokSec
            // 
            buttonStokSec.BackColor = Color.LightSteelBlue;
            buttonStokSec.FlatStyle = FlatStyle.Flat;
            buttonStokSec.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonStokSec.ForeColor = Color.Navy;
            buttonStokSec.Location = new Point(1410, 90);
            buttonStokSec.Name = "buttonStokSec";
            buttonStokSec.Size = new Size(80, 40);
            buttonStokSec.TabIndex = 101;
            buttonStokSec.Text = "Seç";
            buttonStokSec.UseVisualStyleBackColor = false;
            buttonStokSec.Visible = false;
            // 
            // labelAciklama2
            // 
            labelAciklama2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelAciklama2.Location = new Point(200, 330);
            labelAciklama2.Name = "labelAciklama2";
            labelAciklama2.Size = new Size(160, 30);
            labelAciklama2.TabIndex = 1;
            labelAciklama2.Text = "Açıklama (Opsiyonel)";
            // 
            // textBoxAciklama2
            // 
            textBoxAciklama2.Location = new Point(350, 330);
            textBoxAciklama2.Name = "textBoxAciklama2";
            textBoxAciklama2.Size = new Size(400, 27);
            textBoxAciklama2.TabIndex = 0;
            // 
            // MagazaCiktilariForm
            // 
            ClientSize = new Size(1550, 1000);
            Controls.Add(textBoxAciklama2);
            Controls.Add(labelAciklama2);
            Controls.Add(dataGridViewStokDetay);
            Controls.Add(buttonStokSec);
            Controls.Add(labelMusteriSec);
            Controls.Add(comboBoxMusteri);
            Controls.Add(labelUrun);
            Controls.Add(comboBoxUrun);
            Controls.Add(labelMiktar);
            Controls.Add(textBoxMiktar);
            Controls.Add(labelTutar);
            Controls.Add(textBoxTutar);
            Controls.Add(labelTarih);
            Controls.Add(dateTimePickerTarih);
            Controls.Add(labelAdres);
            Controls.Add(textBoxAdres);
            Controls.Add(labelUlke);
            Controls.Add(textBoxUlke);
            Controls.Add(buttonEkle);
            Controls.Add(buttonFaturaYazdir);
            Controls.Add(dataGridViewCiktilar);
            Name = "MagazaCiktilariForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mağaza Çıktıları (Satış)";
            ((System.ComponentModel.ISupportInitialize)dataGridViewCiktilar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStokDetay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
} 