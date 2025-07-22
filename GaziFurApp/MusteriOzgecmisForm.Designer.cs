namespace GaziFurApp
{
    partial class MusteriOzgecmisForm
    {
        private System.Windows.Forms.Label labelMusteri;
        private System.Windows.Forms.ComboBox comboBoxMusteriler;
        private System.Windows.Forms.DataGridView dataGridViewGecmis;
        private System.Windows.Forms.Label labelOpsiyonel;
        private System.Windows.Forms.DateTimePicker dateTimePickerTarih;
        private void InitializeComponent()
        {
            this.labelMusteri = new System.Windows.Forms.Label();
            this.comboBoxMusteriler = new System.Windows.Forms.ComboBox();
            this.dataGridViewGecmis = new System.Windows.Forms.DataGridView();
            this.labelOpsiyonel = new System.Windows.Forms.Label();
            this.dateTimePickerTarih = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGecmis)).BeginInit();
            this.SuspendLayout();
            // labelMusteri
            this.labelMusteri.Text = "Müşteri Seçiniz:";
            this.labelMusteri.Location = new System.Drawing.Point(30, 30);
            this.labelMusteri.Size = new System.Drawing.Size(120, 30);
            this.labelMusteri.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            // comboBoxMusteriler
            this.comboBoxMusteriler.Location = new System.Drawing.Point(160, 30);
            this.comboBoxMusteriler.Size = new System.Drawing.Size(300, 27);
            this.comboBoxMusteriler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMusteriler.Items.Add("Müşteri Seçiniz");
            this.comboBoxMusteriler.SelectedIndex = 0;
            // labelOpsiyonel
            this.labelOpsiyonel.Text = "Opsiyonel";
            this.labelOpsiyonel.Location = new System.Drawing.Point(480, 30);
            this.labelOpsiyonel.Size = new System.Drawing.Size(80, 27);
            this.labelOpsiyonel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.labelOpsiyonel.ForeColor = System.Drawing.Color.Gray;
            // dateTimePickerTarih
            this.dateTimePickerTarih.Location = new System.Drawing.Point(570, 30);
            this.dateTimePickerTarih.Size = new System.Drawing.Size(200, 27);
            this.dateTimePickerTarih.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // dataGridViewGecmis
            this.dataGridViewGecmis.Location = new System.Drawing.Point(30, 80);
            this.dataGridViewGecmis.Size = new System.Drawing.Size(1200, 600);
            this.dataGridViewGecmis.Name = "dataGridViewGecmis";
            this.dataGridViewGecmis.TabIndex = 0;
            this.dataGridViewGecmis.ReadOnly = true;
            this.dataGridViewGecmis.AllowUserToAddRows = false;
            this.dataGridViewGecmis.AllowUserToDeleteRows = false;
            this.dataGridViewGecmis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            // MusteriOzgecmisForm
            this.Text = "Müşteri Özgeçmişi";
            this.ClientSize = new System.Drawing.Size(1300, 750);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.labelMusteri);
            this.Controls.Add(this.comboBoxMusteriler);
            this.Controls.Add(this.labelOpsiyonel);
            this.Controls.Add(this.dateTimePickerTarih);
            this.Controls.Add(this.dataGridViewGecmis);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGecmis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
} 