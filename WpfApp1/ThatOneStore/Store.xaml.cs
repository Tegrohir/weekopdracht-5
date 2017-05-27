using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ThatOneStore.FruitShopReference;

namespace ThatOneStore
{
    /// <summary>
    /// Interaction logic for Store.xaml
    /// </summary>
    public partial class Store : Window
    {
        private static List<ProductType> products = new List<ProductType>();
        
        public Store()
        {
            InitializeComponent();

            FruitShopClient service = new FruitShopClient();

            RefreshMyInventory();
            RefreshStock();
            RefreshBalance();
        }

        private void Click_Buy(object sender, RoutedEventArgs e)
        {
            ProductType selectedItem = null;

            try
            {
                selectedItem = (ProductType) ProductListBox.SelectedItem;
            }
            catch(NullReferenceException)
            {
                // Do nothing.
            }

            if (selectedItem != null)
            {

                FruitShopClient service = new FruitShopClient();

                var message = service.BuyProduct(Login.LoginDetails, selectedItem.Id);

                if (!message.IsError)
                {
                    RefreshMyInventory();
                    RefreshStock();
                    RefreshBalance();
                }

                MessageBox.Show(message.Content);
            } else
            {
                MessageBox.Show("Please select a product!");
            }
        }

        private void Click_Refresh(object sender, RoutedEventArgs e)
        {
            RefreshStock();
        }

        private void RefreshMyInventory()
        {
            FruitShopClient service = new FruitShopClient();
            var myInventory = service.GetBoughtProducts(Login.LoginDetails);

            string inventory = "";
            foreach (OwnedProductType ownedProduct in myInventory)
            {
                inventory += ownedProduct.ProductDetails.Name + " " + 
                    ownedProduct.Quantity + "\n";
            }

            Inventory.Text = inventory;
        }

        private void RefreshStock()
        {
            FruitShopClient service = new FruitShopClient();
            var availableProducts = service.GetAvailableProducts();

            ProductListBox.ItemsSource = availableProducts;

            ProductListBox.UpdateLayout();
            ProductListBox.Items.Refresh();
        }

        private void RefreshBalance()
        {
            FruitShopClient service = new FruitShopClient();
            Double balance = service.GetBalance(Login.LoginDetails);
            Balance.Text = "$" + balance + " USD";
        }
    }
}

