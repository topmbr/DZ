using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        private IDbproviderFactoryWrapper _currentDbFactory;
        public Form1()
        {
            InitializeComponent();
            ComboBox.Items.Add("SQL Server");
            ComboBox.Items.Add("MySQL");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ComboBox.SelectedItem.ToString())
            {
                case "SQL Server":
                    _currentDbFactory = new SqlServerFactoryWrapper
                    {
                        ConnectionString = @"Data Source = DESKTOP-2J3MN6S; Initial Catalog = SHOP; Trusted_Connection=True; TrustServerCertificate = True"
                    };
                    break;
                case "MySQL":
                    _currentDbFactory = new MySqlClient
                    {
                        ConnectionString = @"Server=DESKTOP-2J3MN6S;Database=QWERQ;User=asd;Password=8jo_sd12M;"
                    };
                    break;
                default:
                    break;
            }
        }
        private void LoadData()
        {
            using (var connection = _currentDbFactory.CreateConnection())
            {
                connection.Open();

                var qury = "SELECT * FROM Users";
                var command = connection.CreateCommand();
                command.CommandText = qury;

                var dataTable = new DataTable();
                using (var reader = command.ExecuteReader())
                {
                    dataTable.Load(reader);
                }
                DataGridView.DataSource = dataTable;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
