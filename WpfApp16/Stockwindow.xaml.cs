using Microsoft.EntityFrameworkCore;
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
using WpfApp16.Data;

namespace WpfApp16
{
    /// <summary>
    /// Interaction logic for Stockwindow.xaml
    /// </summary>
    public partial class Stockwindow : Window
    {
        public Stockwindow()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            using (var db =new MyDbcontext())
            {
                var ShowProducts = db.Product.Include(t => t.Supplier).Where(t=>t.Quantity>10).ToList();
                data_grid1.ItemsSource= ShowProducts;
                datagrid2.ItemsSource=db.Product.Where(t=>t.Quantity<=10&&t.Quantity>0).Include(t=>t.Supplier).ToList(); 

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(txt_name.Text)||string.IsNullOrEmpty(txt_quantity.Text))
            {
               MessageBox.Show("please Enter all data");
                return;
            }
            using (var db=new MyDbcontext())
            {
                var ckeckProduct = db.Product.FirstOrDefault(t => t.Name==txt_name.Text);
                if(ckeckProduct==null)
                {
                MessageBox.Show("Sorry Product Not Found!");
                    return; 
                }
                ckeckProduct.Quantity-=int.Parse(txt_quantity.Text);
                db.SaveChanges();
                MessageBox.Show("Product Updated Successfully");
                LoadData();
            }
        }
    }
}
