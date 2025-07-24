
namespace GaziFurApp
{
    partial class GetirilenKonsiyeForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelGetiren;
        private System.Windows.Forms.Label labelUrun;
        private System.Windows.Forms.Label labelFiyat;
        private System.Windows.Forms.Label labelAdet;
        private System.Windows.Forms.Label labelTarih;
        private System.Windows.Forms.TextBox textBoxGetiren;
        private System.Windows.Forms.TextBox textBoxUrun;
        private System.Windows.Forms.TextBox textBoxFiyat;
        private System.Windows.Forms.TextBox textBoxAdet;
        private System.Windows.Forms.DateTimePicker dateTimePickerTarih;
        private System.Windows.Forms.RadioButton radioOdemeAlindi;
        private System.Windows.Forms.RadioButton radioOdemeAlinmadi;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonEkle;
        private System.Windows.Forms.Button buttonYazdir;
        private System.Windows.Forms.Button buttonSil;
        private System.Windows.Forms.Button buttonGuncelle;
        private System.Windows.Forms.Label labelFiltre;
        private System.Windows.Forms.TextBox textBoxFiltre;
        private System.Windows.Forms.DataGridView dataGridViewFiltre;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            labelGetiren = new Label();
            labelUrun = new Label();
            labelFiyat = new Label();
            labelAdet = new Label();
            labelTarih = new Label();
            textBoxGetiren = new TextBox();
            textBoxUrun = new TextBox();
            textBoxFiyat = new TextBox();
            textBoxAdet = new TextBox();
            dateTimePickerTarih = new DateTimePicker();
            radioOdemeAlindi = new RadioButton();
            radioOdemeAlinmadi = new RadioButton();
            dataGridView1 = new DataGridView();
            buttonEkle = new Button();
            buttonYazdir = new Button();
            buttonSil = new Button();
            buttonGuncelle = new Button();
            labelFiltre = new Label();
            textBoxFiltre = new TextBox();
            dataGridViewFiltre = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFiltre).BeginInit();
            SuspendLayout();
            // 
            // labelGetiren
            // 
            labelGetiren.AutoSize = true;
            labelGetiren.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelGetiren.ForeColor = Color.Navy;
            labelGetiren.Location = new Point(340, 30);
            labelGetiren.Name = "labelGetiren";
            labelGetiren.Size = new Size(117, 23);
            labelGetiren.TabIndex = 0;
            labelGetiren.Text = "Getirenin Adı";
            // 
            // labelUrun
            // 
            labelUrun.AutoSize = true;
            labelUrun.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelUrun.ForeColor = Color.Navy;
            labelUrun.Location = new Point(1040, 90);
            labelUrun.Name = "labelUrun";
            labelUrun.Size = new Size(82, 23);
            labelUrun.TabIndex = 1;
            labelUrun.Text = "Ürün Adı";
            // 
            // labelFiyat
            // 
            labelFiyat.AutoSize = true;
            labelFiyat.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelFiyat.ForeColor = Color.Navy;
            labelFiyat.Location = new Point(698, 32);
            labelFiyat.Name = "labelFiyat";
            labelFiyat.Size = new Size(54, 23);
            labelFiyat.TabIndex = 2;
            labelFiyat.Text = "Fiyatı";
            // 
            // labelAdet
            // 
            labelAdet.AutoSize = true;
            labelAdet.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelAdet.ForeColor = Color.Navy;
            labelAdet.Location = new Point(698, 90);
            labelAdet.Name = "labelAdet";
            labelAdet.Size = new Size(54, 23);
            labelAdet.TabIndex = 3;
            labelAdet.Text = "Adeti";
            // 
            // labelTarih
            // 
            labelTarih.AutoSize = true;
            labelTarih.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelTarih.ForeColor = Color.Navy;
            labelTarih.Location = new Point(346, 90);
            labelTarih.Name = "labelTarih";
            labelTarih.Size = new Size(50, 23);
            labelTarih.TabIndex = 4;
            labelTarih.Text = "Tarih";
            // 
            // textBoxGetiren
            // 
            textBoxGetiren.Location = new Point(466, 31);
            textBoxGetiren.Name = "textBoxGetiren";
            textBoxGetiren.Size = new Size(200, 27);
            textBoxGetiren.TabIndex = 5;
            // 
            // textBoxUrun
            // 
            textBoxUrun.Location = new Point(1138, 87);
            textBoxUrun.Name = "textBoxUrun";
            textBoxUrun.Size = new Size(200, 27);
            textBoxUrun.TabIndex = 6;
            // 
            // textBoxFiyat
            // 
            textBoxFiyat.Location = new Point(787, 32);
            textBoxFiyat.Name = "textBoxFiyat";
            textBoxFiyat.Size = new Size(200, 27);
            textBoxFiyat.TabIndex = 7;
            // 
            // textBoxAdet
            // 
            textBoxAdet.Location = new Point(787, 86);
            textBoxAdet.Name = "textBoxAdet";
            textBoxAdet.Size = new Size(200, 27);
            textBoxAdet.TabIndex = 8;
            // 
            // dateTimePickerTarih
            // 
            dateTimePickerTarih.Location = new Point(402, 90);
            dateTimePickerTarih.Name = "dateTimePickerTarih";
            dateTimePickerTarih.Size = new Size(200, 27);
            dateTimePickerTarih.TabIndex = 9;
            // 
            // radioOdemeAlindi
            // 
            radioOdemeAlindi.AutoSize = true;
            radioOdemeAlindi.Location = new Point(1202, 35);
            radioOdemeAlindi.Name = "radioOdemeAlindi";
            radioOdemeAlindi.Size = new Size(128, 24);
            radioOdemeAlindi.TabIndex = 10;
            radioOdemeAlindi.TabStop = true;
            radioOdemeAlindi.Text = "Ödeme Yapıldı";
            radioOdemeAlindi.UseVisualStyleBackColor = true;
            // 
            // radioOdemeAlinmadi
            // 
            radioOdemeAlinmadi.AutoSize = true;
            radioOdemeAlinmadi.Location = new Point(1040, 35);
            radioOdemeAlinmadi.Name = "radioOdemeAlinmadi";
            radioOdemeAlinmadi.Size = new Size(149, 24);
            radioOdemeAlinmadi.TabIndex = 11;
            radioOdemeAlinmadi.TabStop = true;
            radioOdemeAlinmadi.Text = "Ödeme Yapılmadı";
            radioOdemeAlinmadi.UseVisualStyleBackColor = true;
            radioOdemeAlinmadi.CheckedChanged += radioOdemeAlinmadi_CheckedChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(346, 140);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(997, 400);
            dataGridView1.TabIndex = 13;
            // 
            // buttonEkle
            // 
            buttonEkle.BackColor = Color.LightBlue;
            buttonEkle.FlatStyle = FlatStyle.Flat;
            buttonEkle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonEkle.ForeColor = Color.Navy;
            buttonEkle.Location = new Point(1376, 140);
            buttonEkle.Name = "buttonEkle";
            buttonEkle.Size = new Size(200, 40);
            buttonEkle.TabIndex = 12;
            buttonEkle.Text = "Ekle";
            buttonEkle.UseVisualStyleBackColor = false;
            // 
            // buttonYazdir
            // 
            buttonYazdir.BackColor = Color.LightSteelBlue;
            buttonYazdir.FlatStyle = FlatStyle.Flat;
            buttonYazdir.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonYazdir.ForeColor = Color.Navy;
            buttonYazdir.Location = new Point(103, 257);
            buttonYazdir.Name = "buttonYazdir";
            buttonYazdir.Size = new Size(200, 40);
            buttonYazdir.TabIndex = 14;
            buttonYazdir.Text = "Yazdır";
            buttonYazdir.UseVisualStyleBackColor = false;
            // 
            // buttonSil
            // 
            buttonSil.BackColor = Color.LightSteelBlue;
            buttonSil.FlatStyle = FlatStyle.Flat;
            buttonSil.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonSil.ForeColor = Color.Navy;
            buttonSil.Location = new Point(103, 322);
            buttonSil.Name = "buttonSil";
            buttonSil.Size = new Size(200, 40);
            buttonSil.TabIndex = 15;
            buttonSil.Text = "Sil";
            buttonSil.UseVisualStyleBackColor = false;
            // 
            // buttonGuncelle
            // 
            buttonGuncelle.BackColor = Color.LightSteelBlue;
            buttonGuncelle.FlatStyle = FlatStyle.Flat;
            buttonGuncelle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonGuncelle.ForeColor = Color.Navy;
            buttonGuncelle.Location = new Point(103, 387);
            buttonGuncelle.Name = "buttonGuncelle";
            buttonGuncelle.Size = new Size(200, 40);
            buttonGuncelle.TabIndex = 16;
            buttonGuncelle.Text = "Güncelle";
            buttonGuncelle.UseVisualStyleBackColor = false;
            // 
            // labelFiltre
            // 
            labelFiltre.AutoSize = true;
            labelFiltre.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelFiltre.ForeColor = Color.Navy;
            labelFiltre.Location = new Point(346, 557);
            labelFiltre.Name = "labelFiltre";
            labelFiltre.Size = new Size(128, 23);
            labelFiltre.TabIndex = 17;
            labelFiltre.Text = "İsim ile Filtrele";
            // 
            // textBoxFiltre
            // 
            textBoxFiltre.Location = new Point(491, 557);
            textBoxFiltre.Name = "textBoxFiltre";
            textBoxFiltre.Size = new Size(200, 27);
            textBoxFiltre.TabIndex = 18;
            textBoxFiltre.TextChanged += textBoxFiltre_TextChanged_1;
            // 
            // dataGridViewFiltre
            // 
            dataGridViewFiltre.AllowUserToAddRows = false;
            dataGridViewFiltre.AllowUserToDeleteRows = false;
            dataGridViewFiltre.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewFiltre.Location = new Point(346, 599);
            dataGridViewFiltre.Name = "dataGridViewFiltre";
            dataGridViewFiltre.ReadOnly = true;
            dataGridViewFiltre.RowHeadersWidth = 51;
            dataGridViewFiltre.Size = new Size(997, 159);
            dataGridViewFiltre.TabIndex = 19;
            // 
            // GetirilenKonsiyeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1800, 1000);
            Controls.Add(dataGridViewFiltre);
            Controls.Add(textBoxFiltre);
            Controls.Add(labelFiltre);
            Controls.Add(buttonGuncelle);
            Controls.Add(buttonSil);
            Controls.Add(buttonYazdir);
            Controls.Add(dataGridView1);
            Controls.Add(buttonEkle);
            Controls.Add(radioOdemeAlinmadi);
            Controls.Add(radioOdemeAlindi);
            Controls.Add(dateTimePickerTarih);
            Controls.Add(textBoxAdet);
            Controls.Add(textBoxFiyat);
            Controls.Add(textBoxUrun);
            Controls.Add(textBoxGetiren);
            Controls.Add(labelTarih);
            Controls.Add(labelAdet);
            Controls.Add(labelFiyat);
            Controls.Add(labelUrun);
            Controls.Add(labelGetiren);
            Name = "GetirilenKonsiyeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Getirilen Konsiye (Dışardan)";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFiltre).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


    }
} 