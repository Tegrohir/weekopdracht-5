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

namespace ThatOneStore
{
    /// <summary>
    /// Interaction logic for Store.xaml
    /// </summary>
    public partial class Store : Window
    {
        private static List<Product> items = new List<Product>();
        private static String inventory = "hoi";
        private static List<Product> myInventory = new List<Product>();
        
        public Store()
        {
            InitializeComponent();
            items.Add(new Product() { Name = "Black Ops II", NumberAvailable = 5 });
            items.Add(new Product() { Name = "Mario Kart", NumberAvailable = 3 });
            items.Add(new Product() { Name = "Awesomely Awesomeness", NumberAvailable = 1 });

            Inventory.Text = inventory;
            ProductListBox.ItemsSource = items;
        }

        private void Click_Buy(object sender, RoutedEventArgs e)
        {
            Product item = null;
            String selectedItem = null;

            try
            {
                selectedItem = ProductListBox.SelectedItem.ToString();
            }
            catch(NullReferenceException)
            {
                
            }

            foreach(Product p in items)
            {
                if (p.Name.Equals(selectedItem))
                {
                    item = p;
                    break;
                }
            }

            if (item != null)
            {
                var hits = 0;
                foreach (Product p in myInventory)
                {
                    if (item.Name.Equals(p.Name)){
                        p.NumberAvailable += 1;
                        hits += 1;
                        break;
                    }
                }

                if (hits == 0)
                {
                    Product p = new Product() { Name = item.Name, NumberAvailable = 1 } ;
                    myInventory.Add(p);
                }

                item.NumberAvailable -= 1;

                if (item.NumberAvailable == 0)
                {
                    items.Remove(item);                    
                }                
            }
            RefreshMyInventory();
            Inventory.Text = inventory;
            ProductListBox.UpdateLayout();
            ProductListBox.Items.Refresh();
        }

        private void Click_Refresh(object sender, RoutedEventArgs e)
        {
            var hits = 0;
            foreach (Product p in items)
            {
                if (p.Name.Equals("New World"))
                {
                    p.NumberAvailable += 1;
                    hits += 1;
                }
            }
            if (hits == 0)
            {
                items.Add(new Product() { Name = "New World", NumberAvailable = 1 }); 
            }
            
            ProductListBox.ItemsSource = items;
            ProductListBox.UpdateLayout();
            ProductListBox.Items.Refresh();
        }

        private void RefreshMyInventory()
        {
            inventory = "";
            foreach (Product p in myInventory)
            {
                inventory += p.Name + " " + p.NumberAvailable + "\n";
            }
        }
    }

    public class Product {
        public string Name { get; set; }
        public int NumberAvailable { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

}
