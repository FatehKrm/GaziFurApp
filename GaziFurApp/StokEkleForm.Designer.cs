namespace GaziFurApp
{
    partial class StokEkleForm
    {
        private System.Windows.Forms.Label labelUrunAdi;
        private System.Windows.Forms.Label labelBeden;
        private System.Windows.Forms.Label labelAdet;
        private System.Windows.Forms.Label labelRenk;
        private System.Windows.Forms.Label labelFoto;
        private System.Windows.Forms.Label labelMevcut;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.TextBox textBoxUrunAdi;
        private System.Windows.Forms.TextBox textBoxBeden;
        private System.Windows.Forms.TextBox textBoxAdet;
        private System.Windows.Forms.TextBox textBoxRenk;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Button buttonEkle;
        private System.Windows.Forms.DataGridView dataGridViewStok;
        private System.Windows.Forms.Button buttonFotoSec;
        private System.Windows.Forms.PictureBox pictureBoxFoto;
        private System.Windows.Forms.RadioButton radioMevcutEvet;
        private System.Windows.Forms.RadioButton radioMevcutHayir;
        private void InitializeComponent()
        {
            labelUrunAdi = new Label();
            labelBeden = new Label();
            labelAdet = new Label();
            labelRenk = new Label();
            labelFoto = new Label();
            labelMevcut = new Label();
            labelPrice = new Label();
            textBoxUrunAdi = new TextBox();
            textBoxBeden = new TextBox();
            textBoxAdet = new TextBox();
            textBoxRenk = new TextBox();
            textBoxPrice = new TextBox();
            buttonEkle = new Button();
            dataGridViewStok = new DataGridView();
            buttonFotoSec = new Button();
            pictureBoxFoto = new PictureBox();
            radioMevcutEvet = new RadioButton();
            radioMevcutHayir = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStok).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxFoto).BeginInit();
            SuspendLayout();
            // 
            // labelUrunAdi
            // 
            labelUrunAdi.Location = new Point(20, 21);
            labelUrunAdi.Name = "labelUrunAdi";
            labelUrunAdi.Size = new Size(100, 23);
            labelUrunAdi.TabIndex = 0;
            labelUrunAdi.Text = "Ürün Adı";
            // 
            // labelBeden
            // 
            labelBeden.Location = new Point(20, 75);
            labelBeden.Name = "labelBeden";
            labelBeden.Size = new Size(100, 23);
            labelBeden.TabIndex = 2;
            labelBeden.Text = "Beden";
            // 
            // labelAdet
            // 
            labelAdet.Location = new Point(20, 130);
            labelAdet.Name = "labelAdet";
            labelAdet.Size = new Size(100, 23);
            labelAdet.TabIndex = 4;
            labelAdet.Text = "Adet";
            // 
            // labelRenk
            // 
            labelRenk.Location = new Point(20, 185);
            labelRenk.Name = "labelRenk";
            labelRenk.Size = new Size(100, 23);
            labelRenk.TabIndex = 6;
            labelRenk.Text = "Renk";
            // 
            // labelFoto
            // 
            labelFoto.Location = new Point(20, 300);
            labelFoto.Name = "labelFoto";
            labelFoto.Size = new Size(100, 23);
            labelFoto.TabIndex = 8;
            labelFoto.Text = "Fotoğraf";
            // 
            // labelMevcut
            // 
            labelMevcut.Location = new Point(20, 470);
            labelMevcut.Name = "labelMevcut";
            labelMevcut.Size = new Size(100, 23);
            labelMevcut.TabIndex = 11;
            labelMevcut.Text = "Ürün Mevcut mu?";
            // 
            // labelPrice
            // 
            labelPrice.Location = new Point(20, 240);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(100, 30);
            labelPrice.TabIndex = 14;
            labelPrice.Text = "Fiyat";
            // 
            // textBoxUrunAdi
            // 
            textBoxUrunAdi.Location = new Point(20, 40);
            textBoxUrunAdi.Name = "textBoxUrunAdi";
            textBoxUrunAdi.Size = new Size(180, 27);
            textBoxUrunAdi.TabIndex = 1;
            // 
            // textBoxBeden
            // 
            textBoxBeden.Location = new Point(20, 95);
            textBoxBeden.Name = "textBoxBeden";
            textBoxBeden.Size = new Size(180, 27);
            textBoxBeden.TabIndex = 3;
            // 
            // textBoxAdet
            // 
            textBoxAdet.Location = new Point(20, 150);
            textBoxAdet.Name = "textBoxAdet";
            textBoxAdet.Size = new Size(180, 27);
            textBoxAdet.TabIndex = 5;
            // 
            // textBoxRenk
            // 
            textBoxRenk.Location = new Point(20, 205);
            textBoxRenk.Name = "textBoxRenk";
            textBoxRenk.Size = new Size(180, 27);
            textBoxRenk.TabIndex = 7;
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(20, 265);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(180, 27);
            textBoxPrice.TabIndex = 15;
            // 
            // buttonEkle
            // 
            buttonEkle.BackColor = Color.Gold;
            buttonEkle.FlatStyle = FlatStyle.Flat;
            buttonEkle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonEkle.ForeColor = Color.Navy;
            buttonEkle.Location = new Point(20, 530);
            buttonEkle.Name = "buttonEkle";
            buttonEkle.Size = new Size(180, 40);
            buttonEkle.TabIndex = 16;
            buttonEkle.Text = "Ekle";
            buttonEkle.UseVisualStyleBackColor = false;
            // 
            // dataGridViewStok
            // 
            dataGridViewStok.AllowUserToAddRows = false;
            dataGridViewStok.AllowUserToDeleteRows = false;
            dataGridViewStok.ColumnHeadersHeight = 29;
            dataGridViewStok.Location = new Point(220, 40);
            dataGridViewStok.Name = "dataGridViewStok";
            dataGridViewStok.ReadOnly = true;
            dataGridViewStok.RowHeadersWidth = 51;
            dataGridViewStok.Size = new Size(1300, 530);
            dataGridViewStok.TabIndex = 0;
            // 
            // buttonFotoSec
            // 
            buttonFotoSec.Location = new Point(20, 320);
            buttonFotoSec.Name = "buttonFotoSec";
            buttonFotoSec.Size = new Size(180, 27);
            buttonFotoSec.TabIndex = 9;
            buttonFotoSec.Text = "Fotoğraf Seç";
            // 
            // pictureBoxFoto
            // 
            pictureBoxFoto.Location = new Point(20, 355);
            pictureBoxFoto.Name = "pictureBoxFoto";
            pictureBoxFoto.Size = new Size(180, 100);
            pictureBoxFoto.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxFoto.TabIndex = 10;
            pictureBoxFoto.TabStop = false;
            // 
            // radioMevcutEvet
            // 
            radioMevcutEvet.Location = new Point(20, 490);
            radioMevcutEvet.Name = "radioMevcutEvet";
            radioMevcutEvet.Size = new Size(104, 24);
            radioMevcutEvet.TabIndex = 12;
            radioMevcutEvet.Text = "Evet";
            // 
            // radioMevcutHayir
            // 
            radioMevcutHayir.Location = new Point(130, 490);
            radioMevcutHayir.Name = "radioMevcutHayir";
            radioMevcutHayir.Size = new Size(84, 24);
            radioMevcutHayir.TabIndex = 13;
            radioMevcutHayir.Text = "Hayır";
            // 
            // StokEkleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1800, 1000);
            Controls.Add(labelUrunAdi);
            Controls.Add(textBoxUrunAdi);
            Controls.Add(labelBeden);
            Controls.Add(textBoxBeden);
            Controls.Add(labelAdet);
            Controls.Add(textBoxAdet);
            Controls.Add(labelRenk);
            Controls.Add(textBoxRenk);
            Controls.Add(labelFoto);
            Controls.Add(buttonFotoSec);
            Controls.Add(pictureBoxFoto);
            Controls.Add(labelMevcut);
            Controls.Add(radioMevcutEvet);
            Controls.Add(radioMevcutHayir);
            Controls.Add(labelPrice);
            Controls.Add(textBoxPrice);
            Controls.Add(buttonEkle);
            Controls.Add(dataGridViewStok);
            Name = "StokEkleForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Stok Ekle";
            ((System.ComponentModel.ISupportInitialize)dataGridViewStok).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxFoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
} 