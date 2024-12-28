using System;
using System.Data;
using System.Windows.Forms;

namespace StockManagementApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Müşteri listesini yükle
            LoadCustomers();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DatabaseHelper db = new DatabaseHelper();
            Random random = new Random();

            int customerCount = random.Next(5, 11);

            for (int i = 0; i < customerCount; i++)
            {
                string name = "Customer" + i;
                float budget = random.Next(500, 3001);
                string type = (i < 2) ? "Premium" : "Standard";

                string query = $"INSERT INTO Customers (CustomerName, Budget, CustomerType, TotalSpent) " +
                               $"VALUES ('{name}', {budget}, '{type}', 0)";
                db.ExecuteNonQuery(query);
            }

            MessageBox.Show("Rastgele müşteriler oluşturuldu!");

            // DataGridView'de müşterileri göster
            LoadCustomers();
        }


        private void btnGenerateCustomers_Click(object sender, EventArgs e)
        {
            DatabaseHelper db = new DatabaseHelper();
            Random random = new Random();

            int customerCount = random.Next(5, 11); // 5-10 arası müşteri sayısı

            for (int i = 0; i < customerCount; i++)
            {
                string name = "Customer" + i;
                float budget = random.Next(500, 3001);
                string type = (i < 2) ? "Premium" : "Standard";

                string query = $"INSERT INTO Customers (CustomerName, Budget, CustomerType, TotalSpent) " +
                               $"VALUES ('{name}', {budget}, '{type}', 0)";
                db.ExecuteNonQuery(query);
            }

            MessageBox.Show("Rastgele müşteriler oluşturuldu!");
            LoadCustomers(); // Müşteri listesini yenile
        }
        private void LoadCustomers()
        {
            // Veritabanından müşteri listesini çekmek için SQL sorgusu
            string query = "SELECT CustomerID, CustomerName, Budget, CustomerType, TotalSpent FROM Customers";

            // Veritabanı bağlantısı ve sorguyu çalıştırmak için DatabaseHelper kullanıyoruz
            DatabaseHelper db = new DatabaseHelper();
            DataTable customers = db.ExecuteQuery(query);

            // Verileri DataGridView'e bağlama
            dgvCustomers.DataSource = customers;
        }

        private void btnAdminPanel_Click(object sender, EventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel();
            adminPanel.Show();
        }

        private void btnCustomerPanel_Click_1(object sender, EventArgs e)
        {
            CustomerPanel customerPanel = new CustomerPanel();
            customerPanel.Show();
        }
    }
}
