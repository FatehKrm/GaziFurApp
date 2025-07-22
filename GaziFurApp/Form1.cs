using System;
using System.Windows.Forms;

namespace GaziFurApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            magazaGirdileriMenuItem.Click += (s, e) => OpenFormInPanel(new MagazaGirdileriForm());
            magazaCiktilariMenuItem.Click += (s, e) => OpenFormInPanel(new MagazaCiktilariForm());
            konsiyeMenuItem.Click += (s, e) => OpenFormInPanel(new KonsiyeForm());
            kasaIslemleriMenuItem.Click += (s, e) => OpenFormInPanel(new KasaIslemleriForm());
            // Müşteri işlemleri alt menüleri
            musteriOlusturAltMenuItem.Click += (s, e) => OpenFormInPanel(new MusteriOlusturForm());
            musteriListeleAltMenuItem.Click += (s, e) => OpenFormInPanel(new MusteriListeleForm());
            // Stok işlemleri alt menüleri
            stokEkleAltMenuItem.Click += (s, e) => OpenFormInPanel(new StokEkleForm());
            stokListeleAltMenuItem.Click += (s, e) => OpenFormInPanel(new StokListeleForm());
            // Katalog menüsü
            katalogMenuItem.Click += (s, e) => OpenFormInPanel(new KatalogForm());
            musteriOzgecmisMenuItem.Click += (s, e) => OpenFormInPanel(new MusteriOzgecmisForm());
            haftalikGirislerMenuItem.Click += (s, e) => OpenFormInPanel(new HaftalikGirislerForm());
            haftalikCiktilarMenuItem.Click += (s, e) => OpenFormInPanel(new HaftalikCiktilarForm());
            senelikRaporMenuItem.Click += (s, e) => OpenFormInPanel(new SenelikRaporForm());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OpenFormInPanel(new MagazaGirdileriForm());
        }

        private void OpenFormInPanel(Form frm)
        {
            mainPanel.Controls.Clear();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(frm);
            frm.Show();
        }

        private void musteriGuncelleAltMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
