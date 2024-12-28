using System;
using System.Data;
using System.Windows.Forms;

namespace StockManagementApp
{
    public partial class AdminPanel : Form
    {
        DatabaseHelper db = new DatabaseHelper();

        public AdminPanel()
        {
            InitializeComponent();
            LoadProducts();
        }

        // Ürün listesini DataGridView'e yükler
        private void LoadProducts()
        {
            string query = "SELECT * FROM Products";
            DataTable products = db.ExecuteQuery(query);
            dgvProducts.DataSource = products;
        }

        // Ürün ekleme butonu
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            string name = txtProductName.Text;

            int stockValue;
            if (string.IsNullOrWhiteSpace(txtStock.Text) || !int.TryParse(txtStock.Text, out stockValue))
            {
                MessageBox.Show("Lütfen geçerli bir stok miktarı girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            float priceValue;
            if (string.IsNullOrWhiteSpace(txtPrice.Text) || !float.TryParse(txtPrice.Text, out priceValue))
            {
                MessageBox.Show("Lütfen geçerli bir fiyat girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SQL sorgusu
            string query = $"INSERT INTO Products (ProductName, Stock, Price) VALUES ('{name}', {stockValue}, {priceValue})";
            db.ExecuteNonQuery(query);

            MessageBox.Show("Ürün eklendi!");
            LoadProducts(); // Listeyi yenile
        }

        // Ürün silme butonu
        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            int productId = int.Parse(dgvProducts.CurrentRow.Cells[0].Value.ToString());
            string query = $"DELETE FROM Products WHERE ProductID = {productId}";
            db.ExecuteNonQuery(query);

            MessageBox.Show("Ürün silindi!");
            LoadProducts(); // Listeyi yenile
        }

        // Stok güncelleme butonu
        private void btnUpdateStock_Click(object sender, EventArgs e)
        {
            int productId = int.Parse(dgvProducts.CurrentRow.Cells[0].Value.ToString());
            int stock = int.Parse(txtStock.Text);

            string query = $"UPDATE Products SET Stock = {stock} WHERE ProductID = {productId}";
            db.ExecuteNonQuery(query);

            MessageBox.Show("Stok güncellendi!");
            LoadProducts(); // Listeyi yenile
        }
        private void lblStock_Click(object sender, EventArgs e)
        {
            // Bu metod gereksizse boş bırakabilirsiniz
        }

        private void lblPrice_Click(object sender, EventArgs e)
        {
            // Bu metod gereksizse boş bırakabilirsiniz
        }
    }
}
