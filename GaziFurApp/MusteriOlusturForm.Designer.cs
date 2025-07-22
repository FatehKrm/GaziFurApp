
namespace GaziFurApp
{
    partial class MusteriOlusturForm
    {
        private System.Windows.Forms.Label labelAd;
        private System.Windows.Forms.Label labelSoyad;
        private System.Windows.Forms.Label labelTelefon;
        private System.Windows.Forms.TextBox textBoxAd;
        private System.Windows.Forms.TextBox textBoxSoyad;
        private System.Windows.Forms.TextBox textBoxTelefon;
        private System.Windows.Forms.Button buttonEkle;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelUlke;
        private System.Windows.Forms.TextBox textBoxUlke;
        private void InitializeComponent()
        {
            labelAd = new Label();
            labelSoyad = new Label();
            labelTelefon = new Label();
            textBoxAd = new TextBox();
            textBoxSoyad = new TextBox();
            textBoxTelefon = new TextBox();
            buttonEkle = new Button();
            dataGridView1 = new DataGridView();
            labelUlke = new Label();
            textBoxUlke = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // labelAd
            // 
            labelAd.AutoSize = true;
            labelAd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelAd.ForeColor = Color.Navy;
            labelAd.Location = new Point(119, 157);
            labelAd.Name = "labelAd";
            labelAd.Size = new Size(104, 23);
            labelAd.TabIndex = 0;
            labelAd.Text = "Müşteri Adı";
            // 
            // labelSoyad
            // 
            labelSoyad.AutoSize = true;
            labelSoyad.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelSoyad.ForeColor = Color.Navy;
            labelSoyad.Location = new Point(119, 237);
            labelSoyad.Name = "labelSoyad";
            labelSoyad.Size = new Size(130, 23);
            labelSoyad.TabIndex = 2;
            labelSoyad.Text = "Müşteri Soyadı";
            // 
            // labelTelefon
            // 
            labelTelefon.AutoSize = true;
            labelTelefon.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelTelefon.ForeColor = Color.Navy;
            labelTelefon.Location = new Point(119, 315);
            labelTelefon.Name = "labelTelefon";
            labelTelefon.Size = new Size(144, 23);
            labelTelefon.TabIndex = 4;
            labelTelefon.Text = "Müşteri Telefonu";
            // 
            // textBoxAd
            // 
            textBoxAd.Location = new Point(119, 198);
            textBoxAd.Name = "textBoxAd";
            textBoxAd.Size = new Size(200, 27);
            textBoxAd.TabIndex = 1;
            textBoxAd.TextChanged += textBoxAd_TextChanged;
            // 
            // textBoxSoyad
            // 
            textBoxSoyad.Location = new Point(119, 275);
            textBoxSoyad.Name = "textBoxSoyad";
            textBoxSoyad.Size = new Size(200, 27);
            textBoxSoyad.TabIndex = 3;
            // 
            // textBoxTelefon
            // 
            textBoxTelefon.Location = new Point(119, 352);
            textBoxTelefon.Name = "textBoxTelefon";
            textBoxTelefon.Size = new Size(200, 27);
            textBoxTelefon.TabIndex = 5;
            // 
            // buttonEkle
            // 
            buttonEkle.BackColor = Color.Gold;
            buttonEkle.FlatStyle = FlatStyle.Flat;
            buttonEkle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonEkle.ForeColor = Color.Navy;
            buttonEkle.Location = new Point(119, 475);
            buttonEkle.Name = "buttonEkle";
            buttonEkle.Size = new Size(200, 40);
            buttonEkle.TabIndex = 8;
            buttonEkle.Text = "Ekle";
            buttonEkle.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(417, 157);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(700, 380);
            dataGridView1.TabIndex = 7;
            // 
            // labelUlke
            // 
            labelUlke.AutoSize = true;
            labelUlke.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelUlke.ForeColor = Color.Navy;
            labelUlke.Location = new Point(119, 391);
            labelUlke.Name = "labelUlke";
            labelUlke.Size = new Size(46, 23);
            labelUlke.TabIndex = 6;
            labelUlke.Text = "Ülke";
            // 
            // textBoxUlke
            // 
            textBoxUlke.Location = new Point(119, 417);
            textBoxUlke.Name = "textBoxUlke";
            textBoxUlke.Size = new Size(200, 27);
            textBoxUlke.TabIndex = 7;
            // 
            // MusteriOlusturForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(1800, 1000);
            Controls.Add(textBoxUlke);
            Controls.Add(labelUlke);
            Controls.Add(dataGridView1);
            Controls.Add(buttonEkle);
            Controls.Add(textBoxTelefon);
            Controls.Add(labelTelefon);
            Controls.Add(textBoxSoyad);
            Controls.Add(labelSoyad);
            Controls.Add(textBoxAd);
            Controls.Add(labelAd);
            Name = "MusteriOlusturForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Müşteri Oluştur";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void textBoxAd_TextChanged(object sender, EventArgs e)
        {
            // Boş bırakıldı, hata fırlatmaz
        }
    }
} 