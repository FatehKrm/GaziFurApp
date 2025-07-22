namespace GaziFurApp
{
    partial class MagazaGirdileriForm
    {
        private System.Windows.Forms.Label labelUrunKodu;
        private System.Windows.Forms.Label labelUrunAdi;
        private System.Windows.Forms.Label labelAdet;
        private System.Windows.Forms.Label labelMusteri;
        private System.Windows.Forms.Label labelDeger;
        private System.Windows.Forms.Label labelOdeme;
        private System.Windows.Forms.Label labelTarih;
        private System.Windows.Forms.TextBox textBoxUrunKodu;
        private System.Windows.Forms.TextBox textBoxUrunAdi;
        private System.Windows.Forms.TextBox textBoxAdet;
        private System.Windows.Forms.TextBox textBoxMusteri;
        private System.Windows.Forms.TextBox textBoxDeger;
        private System.Windows.Forms.RadioButton radioOdemeAlindi;
        private System.Windows.Forms.RadioButton radioOdemeAlinmadi;
        private System.Windows.Forms.DateTimePicker dateTimePickerTarih;
        private System.Windows.Forms.Button buttonEkle;
        private System.Windows.Forms.DataGridView dataGridViewGirdiler;
        private System.Windows.Forms.DataGridView dataGridViewToplam;
        private void InitializeComponent()
        {
            labelUrunKodu = new Label();
            labelUrunAdi = new Label();
            labelAdet = new Label();
            labelMusteri = new Label();
            labelDeger = new Label();
            labelOdeme = new Label();
            labelTarih = new Label();
            textBoxUrunKodu = new TextBox();
            textBoxUrunAdi = new TextBox();
            textBoxAdet = new TextBox();
            textBoxMusteri = new TextBox();
            textBoxDeger = new TextBox();
            radioOdemeAlindi = new RadioButton();
            radioOdemeAlinmadi = new RadioButton();
            dateTimePickerTarih = new DateTimePicker();
            buttonEkle = new Button();
            dataGridViewGirdiler = new DataGridView();
            dataGridViewToplam = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewGirdiler).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewToplam).BeginInit();
            SuspendLayout();
            // 
            // labelUrunKodu
            // 
            labelUrunKodu.Location = new Point(356, 45);
            labelUrunKodu.Name = "labelUrunKodu";
            labelUrunKodu.Size = new Size(100, 23);
            labelUrunKodu.TabIndex = 0;
            labelUrunKodu.Text = "Ürün Kodu";
            // 
            // labelUrunAdi
            // 
            labelUrunAdi.Location = new Point(356, 124);
            labelUrunAdi.Name = "labelUrunAdi";
            labelUrunAdi.Size = new Size(100, 23);
            labelUrunAdi.TabIndex = 2;
            labelUrunAdi.Text = "Ürün Adı";
            // 
            // labelAdet
            // 
            labelAdet.Location = new Point(356, 209);
            labelAdet.Name = "labelAdet";
            labelAdet.Size = new Size(100, 23);
            labelAdet.TabIndex = 4;
            labelAdet.Text = "Adet";
            // 
            // labelMusteri
            // 
            labelMusteri.Location = new Point(356, 289);
            labelMusteri.Name = "labelMusteri";
            labelMusteri.Size = new Size(100, 23);
            labelMusteri.TabIndex = 6;
            labelMusteri.Text = "Getiren Müşteri";
            // 
            // labelDeger
            // 
            labelDeger.Location = new Point(356, 384);
            labelDeger.Name = "labelDeger";
            labelDeger.Size = new Size(100, 23);
            labelDeger.TabIndex = 8;
            labelDeger.Text = "Ürün Değeri";
            // 
            // labelOdeme
            // 
            labelOdeme.Location = new Point(356, 463);
            labelOdeme.Name = "labelOdeme";
            labelOdeme.Size = new Size(100, 23);
            labelOdeme.TabIndex = 10;
            labelOdeme.Text = "Ödeme Alındı mı?";
            // 
            // labelTarih
            // 
            labelTarih.Location = new Point(284, 565);
            labelTarih.Name = "labelTarih";
            labelTarih.Size = new Size(47, 23);
            labelTarih.TabIndex = 13;
            labelTarih.Text = "Tarih";
            // 
            // textBoxUrunKodu
            // 
            textBoxUrunKodu.Location = new Point(356, 71);
            textBoxUrunKodu.Name = "textBoxUrunKodu";
            textBoxUrunKodu.Size = new Size(180, 27);
            textBoxUrunKodu.TabIndex = 1;
            // 
            // textBoxUrunAdi
            // 
            textBoxUrunAdi.Location = new Point(356, 150);
            textBoxUrunAdi.Name = "textBoxUrunAdi";
            textBoxUrunAdi.Size = new Size(180, 27);
            textBoxUrunAdi.TabIndex = 3;
            // 
            // textBoxAdet
            // 
            textBoxAdet.Location = new Point(356, 237);
            textBoxAdet.Name = "textBoxAdet";
            textBoxAdet.Size = new Size(180, 27);
            textBoxAdet.TabIndex = 5;
            // 
            // textBoxMusteri
            // 
            textBoxMusteri.Location = new Point(356, 315);
            textBoxMusteri.Name = "textBoxMusteri";
            textBoxMusteri.Size = new Size(180, 27);
            textBoxMusteri.TabIndex = 7;
            // 
            // textBoxDeger
            // 
            textBoxDeger.Location = new Point(356, 410);
            textBoxDeger.Name = "textBoxDeger";
            textBoxDeger.Size = new Size(180, 27);
            textBoxDeger.TabIndex = 9;
            // 
            // radioOdemeAlindi
            // 
            radioOdemeAlindi.Location = new Point(337, 496);
            radioOdemeAlindi.Name = "radioOdemeAlindi";
            radioOdemeAlindi.Size = new Size(104, 24);
            radioOdemeAlindi.TabIndex = 11;
            radioOdemeAlindi.Text = "Evet";
            radioOdemeAlindi.CheckedChanged += radioOdemeAlindi_CheckedChanged;
            // 
            // radioOdemeAlinmadi
            // 
            radioOdemeAlinmadi.Location = new Point(447, 496);
            radioOdemeAlinmadi.Name = "radioOdemeAlinmadi";
            radioOdemeAlinmadi.Size = new Size(104, 24);
            radioOdemeAlinmadi.TabIndex = 12;
            radioOdemeAlinmadi.Text = "Hayır";
            // 
            // dateTimePickerTarih
            // 
            dateTimePickerTarih.Location = new Point(337, 560);
            dateTimePickerTarih.Name = "dateTimePickerTarih";
            dateTimePickerTarih.Size = new Size(180, 27);
            dateTimePickerTarih.TabIndex = 14;
            // 
            // buttonEkle
            // 
            buttonEkle.BackColor = Color.Gold;
            buttonEkle.FlatStyle = FlatStyle.Flat;
            buttonEkle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonEkle.ForeColor = Color.Navy;
            buttonEkle.Location = new Point(337, 617);
            buttonEkle.Name = "buttonEkle";
            buttonEkle.Size = new Size(180, 40);
            buttonEkle.TabIndex = 15;
            buttonEkle.Text = "Ekle";
            buttonEkle.UseVisualStyleBackColor = false;
            // 
            // dataGridViewGirdiler
            // 
            dataGridViewGirdiler.AllowUserToAddRows = false;
            dataGridViewGirdiler.AllowUserToDeleteRows = false;
            dataGridViewGirdiler.ColumnHeadersHeight = 29;
            dataGridViewGirdiler.Location = new Point(557, 20);
            dataGridViewGirdiler.Name = "dataGridViewGirdiler";
            dataGridViewGirdiler.ReadOnly = true;
            dataGridViewGirdiler.RowHeadersWidth = 51;
            dataGridViewGirdiler.Size = new Size(1100, 500);
            dataGridViewGirdiler.TabIndex = 0;
            // 
            // dataGridViewToplam
            // 
            dataGridViewToplam.AllowUserToAddRows = false;
            dataGridViewToplam.AllowUserToDeleteRows = false;
            dataGridViewToplam.ColumnHeadersHeight = 29;
            dataGridViewToplam.Location = new Point(557, 560);
            dataGridViewToplam.Name = "dataGridViewToplam";
            dataGridViewToplam.ReadOnly = true;
            dataGridViewToplam.RowHeadersWidth = 51;
            dataGridViewToplam.Size = new Size(1100, 80);
            dataGridViewToplam.TabIndex = 1;
            // 
            // MagazaGirdileriForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1800, 1000);
            Controls.Add(labelUrunKodu);
            Controls.Add(textBoxUrunKodu);
            Controls.Add(labelUrunAdi);
            Controls.Add(textBoxUrunAdi);
            Controls.Add(labelAdet);
            Controls.Add(textBoxAdet);
            Controls.Add(labelMusteri);
            Controls.Add(textBoxMusteri);
            Controls.Add(labelDeger);
            Controls.Add(textBoxDeger);
            Controls.Add(labelOdeme);
            Controls.Add(radioOdemeAlindi);
            Controls.Add(radioOdemeAlinmadi);
            Controls.Add(labelTarih);
            Controls.Add(dateTimePickerTarih);
            Controls.Add(buttonEkle);
            Controls.Add(dataGridViewGirdiler);
            Controls.Add(dataGridViewToplam);
            Name = "MagazaGirdileriForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mağaza Girdileri";
            ((System.ComponentModel.ISupportInitialize)dataGridViewGirdiler).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewToplam).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
} 