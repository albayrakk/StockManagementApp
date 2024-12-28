using System;
using System.Data;
using System.Windows.Forms;

namespace StockManagementApp
{
    public partial class CustomerPanel : Form
    {
        DatabaseHelper db = new DatabaseHelper();

        public CustomerPanel()
        {
            InitializeComponent();
            LoadCustomers();
            LoadProducts();
        }

        // Müşteri listesini yükler
        private void LoadCustomers()
        {
            string query = "SELECT * FROM Customers";
            DataTable customers = db.ExecuteQuery(query);
            dgvCustomerList.DataSource = customers;
        }

        // Ürün listesini yükler
        private void LoadProducts()
        {
            // Ürünleri seçmek için SQL sorgusu
            string query = "SELECT ProductName, Stock, Price FROM Products";
            DataTable products = db.ExecuteQuery(query);

            // DataGridView'e ürün listesini bağlama
            dgvProductList.DataSource = products;

            // ComboBox'u temizle ve yeniden doldur
            cmbProducts.Items.Clear();
            foreach (DataRow row in products.Rows)
            {
                cmbProducts.Items.Add(row["ProductName"].ToString());
            }
        }

        // Sipariş Ver butonuna tıklama olayı
        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (cmbProducts.SelectedItem == null || string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                MessageBox.Show("Lütfen bir ürün ve adet girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int quantity;
            if (!int.TryParse(txtQuantity.Text, out quantity) || quantity <= 0 || quantity > 5)
            {
                MessageBox.Show("Adet 1 ile 5 arasında olmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedProduct = cmbProducts.SelectedItem.ToString();
            int selectedCustomerID = Convert.ToInt32(dgvCustomerList.SelectedRows[0].Cells["CustomerID"].Value);

            // Veritabanından müşterinin bütçesini al
            string budgetQuery = $"SELECT Budget FROM Customers WHERE CustomerID = {selectedCustomerID}";
            DataTable result = db.ExecuteQuery(budgetQuery);

            if (result.Rows.Count == 0)
            {
                MessageBox.Show("Müşteri bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            float customerBudget = Convert.ToSingle(result.Rows[0]["Budget"]);

            // Ürün fiyatını ve stok bilgisini al
            string productQuery = $"SELECT Price, Stock FROM Products WHERE ProductName = '{selectedProduct}'";
            DataTable productResult = db.ExecuteQuery(productQuery);

            if (productResult.Rows.Count == 0)
            {
                MessageBox.Show("Ürün bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            float productPrice = Convert.ToSingle(productResult.Rows[0]["Price"]);
            int productStock = Convert.ToInt32(productResult.Rows[0]["Stock"]);
            float totalCost = productPrice * quantity;

            // Bütçe kontrolü
            if (customerBudget < totalCost)
            {
                MessageBox.Show("Müşteri bütçesi yetersiz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Stok kontrolü
            if (productStock < quantity)
            {
                MessageBox.Show("Ürün stoğu yetersiz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Siparişi veritabanına ekleyin
            string orderQuery = $"INSERT INTO Orders (CustomerID, ProductID, Quantity, OrderDate) " +
                                $"VALUES ({selectedCustomerID}, (SELECT ProductID FROM Products WHERE ProductName = '{selectedProduct}'), {quantity}, '{DateTime.Now:yyyy-MM-dd HH:mm:ss}')";
            db.ExecuteNonQuery(orderQuery);

            // Müşteri bütçesini güncelle
            float updatedBudget = customerBudget - totalCost;
            string updateBudgetQuery = $"UPDATE Customers SET Budget = {updatedBudget} WHERE CustomerID = {selectedCustomerID}";
            db.ExecuteNonQuery(updateBudgetQuery);

            // Ürün stoğunu güncelle
            int updatedStock = productStock - quantity;
            string updateStockQuery = $"UPDATE Products SET Stock = {updatedStock} WHERE ProductName = '{selectedProduct}'";
            db.ExecuteNonQuery(updateStockQuery);

            MessageBox.Show($"Sipariş alındı: {selectedProduct} - {quantity} adet\nKalan bütçe: {updatedBudget:C2}\nKalan stok: {updatedStock}",
                            "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // ProgressBar ve Sipariş Durumu
            progressBarOrder.Value = 0;
            Timer timer = new Timer();
            timer.Interval = 500;
            timer.Tick += (s, args) =>
            {
                if (progressBarOrder.Value < 100)
                {
                    progressBarOrder.Value += 20;
                    lblOrderStatus.Text = "İşleniyor...";
                }
                else
                {
                    lblOrderStatus.Text = "Sipariş Tamamlandı!";
                    timer.Stop();
                }
            };
            timer.Start();

            LoadCustomers(); // Müşteri listesini güncelle
            LoadProducts();  // Ürün listesini güncelle
        }


        private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvCustomerList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void progressBarOrder_Click(object sender, EventArgs e)
        {

        }

        private void btnPlaceOrder_Click_1(object sender, EventArgs e)
        {

        }

        private void btnViewOrders_Click(object sender, EventArgs e)
        {
            string query = "SELECT o.OrderID, c.CustomerName, p.ProductName, o.Quantity, o.OrderDate " +
                  "FROM Orders o " +
                  "JOIN Customers c ON o.CustomerID = c.CustomerID " +
                  "JOIN Products p ON o.ProductID = p.ProductID";
            DataTable orders = db.ExecuteQuery(query);
            dgvOrders.DataSource = orders;
        }
    }
}
