using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace GaziFurApp
{
    public partial class KonsiyeForm : Form
    {
        private string connectionString = "Server=DESKTOP-PBR2LIP;Database=GazifurAppDb;Trusted_Connection=True;TrustServerCertificate=True;";
        public KonsiyeForm()
        {
            InitializeComponent();
        }
    }
} 