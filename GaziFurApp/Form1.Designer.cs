namespace GaziFurApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            magazaGirdileriMenuItem = new ToolStripMenuItem();
            magazaCiktilariMenuItem = new ToolStripMenuItem();
            musteriOlusturMenuItem = new ToolStripMenuItem();
            musteriOlusturAltMenuItem = new ToolStripMenuItem();
            musteriListeleAltMenuItem = new ToolStripMenuItem();
            stokTakibiMenuItem = new ToolStripMenuItem();
            stokEkleAltMenuItem = new ToolStripMenuItem();
            stokListeleAltMenuItem = new ToolStripMenuItem();
            konsiyeMenuItem = new ToolStripMenuItem();
            kasaIslemleriMenuItem = new ToolStripMenuItem();
            katalogMenuItem = new ToolStripMenuItem();
            musteriOzgecmisMenuItem = new ToolStripMenuItem();
            haftalikGirislerMenuItem = new ToolStripMenuItem();
            haftalikCiktilarMenuItem = new ToolStripMenuItem();
            senelikRaporMenuItem = new ToolStripMenuItem();
            stokGuncelleAltMenuItem = new ToolStripMenuItem();
            stokSilAltMenuItem = new ToolStripMenuItem();
            mainPanel = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { magazaGirdileriMenuItem, magazaCiktilariMenuItem, musteriOlusturMenuItem, stokTakibiMenuItem, konsiyeMenuItem, kasaIslemleriMenuItem, katalogMenuItem, musteriOzgecmisMenuItem, haftalikGirislerMenuItem, haftalikCiktilarMenuItem, senelikRaporMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1674, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // magazaGirdileriMenuItem
            // 
            magazaGirdileriMenuItem.Name = "magazaGirdileriMenuItem";
            magazaGirdileriMenuItem.Size = new Size(133, 24);
            magazaGirdileriMenuItem.Text = "Mağaza Girdileri";
            // 
            // magazaCiktilariMenuItem
            // 
            magazaCiktilariMenuItem.Name = "magazaCiktilariMenuItem";
            magazaCiktilariMenuItem.Size = new Size(130, 24);
            magazaCiktilariMenuItem.Text = "Mağaza Çıktıları";
            // 
            // musteriOlusturMenuItem
            // 
            musteriOlusturMenuItem.DropDownItems.AddRange(new ToolStripItem[] { musteriOlusturAltMenuItem, musteriListeleAltMenuItem });
            musteriOlusturMenuItem.Name = "musteriOlusturMenuItem";
            musteriOlusturMenuItem.Size = new Size(132, 24);
            musteriOlusturMenuItem.Text = "Müşteri işlemleri";
            // 
            // musteriOlusturAltMenuItem
            // 
            musteriOlusturAltMenuItem.Name = "musteriOlusturAltMenuItem";
            musteriOlusturAltMenuItem.Size = new Size(192, 26);
            musteriOlusturAltMenuItem.Text = "Müşteri Oluştur";
            // 
            // musteriListeleAltMenuItem
            // 
            musteriListeleAltMenuItem.Name = "musteriListeleAltMenuItem";
            musteriListeleAltMenuItem.Size = new Size(192, 26);
            musteriListeleAltMenuItem.Text = "Müşteri Listele";
            // 
            // stokTakibiMenuItem
            // 
            stokTakibiMenuItem.DropDownItems.AddRange(new ToolStripItem[] { stokEkleAltMenuItem, stokListeleAltMenuItem });
            stokTakibiMenuItem.Name = "stokTakibiMenuItem";
            stokTakibiMenuItem.Size = new Size(112, 24);
            stokTakibiMenuItem.Text = "Stok işlemleri";
            // 
            // stokEkleAltMenuItem
            // 
            stokEkleAltMenuItem.Name = "stokEkleAltMenuItem";
            stokEkleAltMenuItem.Size = new Size(167, 26);
            stokEkleAltMenuItem.Text = "Stok Ekle";
            // 
            // stokListeleAltMenuItem
            // 
            stokListeleAltMenuItem.Name = "stokListeleAltMenuItem";
            stokListeleAltMenuItem.Size = new Size(167, 26);
            stokListeleAltMenuItem.Text = "Stok Listele";
            // 
            // konsiyeMenuItem
            // 
            konsiyeMenuItem.Name = "konsiyeMenuItem";
            konsiyeMenuItem.Size = new Size(74, 24);
            konsiyeMenuItem.Text = "Konsiye";
            // 
            // kasaIslemleriMenuItem
            // 
            kasaIslemleriMenuItem.Name = "kasaIslemleriMenuItem";
            kasaIslemleriMenuItem.Size = new Size(114, 24);
            kasaIslemleriMenuItem.Text = "Kasa İşlemleri";
            // 
            // katalogMenuItem
            // 
            katalogMenuItem.Name = "katalogMenuItem";
            katalogMenuItem.Size = new Size(75, 24);
            katalogMenuItem.Text = "Katalog";
            // 
            // musteriOzgecmisMenuItem
            // 
            musteriOzgecmisMenuItem.Name = "musteriOzgecmisMenuItem";
            musteriOzgecmisMenuItem.Size = new Size(145, 24);
            musteriOzgecmisMenuItem.Text = "Müşteri Özgeçmişi";
            // 
            // haftalikGirislerMenuItem
            // 
            haftalikGirislerMenuItem.Name = "haftalikGirislerMenuItem";
            haftalikGirislerMenuItem.Size = new Size(125, 24);
            haftalikGirislerMenuItem.Text = "Haftalık Girişler";
            // 
            // haftalikCiktilarMenuItem
            // 
            haftalikCiktilarMenuItem.Name = "haftalikCiktilarMenuItem";
            haftalikCiktilarMenuItem.Size = new Size(126, 24);
            haftalikCiktilarMenuItem.Text = "Haftalık Çıkışlar";
            // 
            // senelikRaporMenuItem
            // 
            senelikRaporMenuItem.Name = "senelikRaporMenuItem";
            senelikRaporMenuItem.Size = new Size(114, 24);
            senelikRaporMenuItem.Text = "Senelik Rapor";
            // 
            // stokGuncelleAltMenuItem
            // 
            stokGuncelleAltMenuItem.Name = "stokGuncelleAltMenuItem";
            stokGuncelleAltMenuItem.Size = new Size(200, 26);
            stokGuncelleAltMenuItem.Text = "Stok Güncelle";
            // 
            // stokSilAltMenuItem
            // 
            stokSilAltMenuItem.Name = "stokSilAltMenuItem";
            stokSilAltMenuItem.Size = new Size(200, 26);
            stokSilAltMenuItem.Text = "Stok Sil";
            // 
            // mainPanel
            // 
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 28);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1674, 810);
            mainPanel.TabIndex = 1;
            mainPanel.Paint += mainPanel_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1674, 838);
            Controls.Add(mainPanel);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Gazi Fur - Yönetim Paneli";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem magazaGirdileriMenuItem;
        private System.Windows.Forms.ToolStripMenuItem magazaCiktilariMenuItem;
        private System.Windows.Forms.ToolStripMenuItem musteriOlusturMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokTakibiMenuItem;
        private System.Windows.Forms.ToolStripMenuItem konsiyeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kasaIslemleriMenuItem;
        private System.Windows.Forms.ToolStripMenuItem musteriOlusturAltMenuItem;
        private System.Windows.Forms.ToolStripMenuItem musteriListeleAltMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokEkleAltMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokListeleAltMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokGuncelleAltMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokSilAltMenuItem;
        private System.Windows.Forms.ToolStripMenuItem katalogMenuItem;
        private System.Windows.Forms.ToolStripMenuItem musteriOzgecmisMenuItem;
        private System.Windows.Forms.ToolStripMenuItem haftalikGirislerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem haftalikCiktilarMenuItem;
        private System.Windows.Forms.ToolStripMenuItem senelikRaporMenuItem;
        private System.Windows.Forms.Panel mainPanel;
    }
}
