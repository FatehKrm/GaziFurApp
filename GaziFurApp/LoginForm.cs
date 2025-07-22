using System;
using System.Windows.Forms;
using System.Drawing; // Added for Image

namespace GaziFurApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            // Arka plan resmini ayarla
            try
            {
                this.BackgroundImage = Image.FromFile("Photos/BackGround.png");
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex)
            {
                // Resim bulunamazsa hata verme, sadece arka planı boş bırak
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // Basit kontrol: kullanıcı adı admin, şifre 1234
            if (textBoxUsername.Text == "admin" && textBoxPassword.Text == "1234")
            {
                this.Hide();
                Form1 mainForm = new Form1();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void labelWelcome_Click(object sender, EventArgs e)
        {

        }

        private void labelPassword_Click(object sender, EventArgs e)
        {

        }
    }
} 