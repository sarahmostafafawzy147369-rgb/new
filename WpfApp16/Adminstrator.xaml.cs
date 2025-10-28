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
using WpfApp16.Models;

namespace WpfApp16
{
   
    public partial class Adminstrator : Window
    {
        public Adminstrator()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            using (var db = new MyDbcontext())
            {
                var showDataa = db.Product.Include(t => t.Supplier).ToList();
                datagridd.ItemsSource=showDataa;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_name.Text)||string.IsNullOrEmpty(txt_price.Text)||string.IsNullOrEmpty(txt_quantity.Text)|string.IsNullOrEmpty(txt_supplier.Text))
            {
                MessageBox.Show("please Enter all data");
                return;
            }
            if (!txt_price.Text.Trim().All(char.IsDigit)||!txt_quantity.Text.Trim().All(char.IsDigit))
            {
                MessageBox.Show("please Enter valid data");
                return;
            }
            using (var db = new MyDbcontext())
            {
                var chackvailproduct = db.Product.FirstOrDefault(t => t.Name==txt_name.Text);
                if (chackvailproduct!=null)
                {
                    MessageBox.Show("Product already exists");
                    return;
                }
                var _suplier = db.Supplier.FirstOrDefault(t => t.Name==txt_supplier.Text);
                if (_suplier==null)
                {
                    MessageBox.Show("Supplier not found");
                    return;
                }
                var newproduct = new Product
                {
                    Name=txt_name.Text,
                    Price=int.Parse(txt_price.Text),
                    Quantity=int.Parse(txt_quantity.Text),
                    Description="good product",
                    SupplierID=_suplier.SupplierID
                };
                db.Product.Add(newproduct);
                db.SaveChanges();
                MessageBox.Show("Product added successfully");
                LoadData();
            }
        }

        private void datagridd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datagridd.SelectedItem==null)
            {
                return;
            }
            Product selectitem = (Product)datagridd.SelectedItem;
            txt_name.Text=selectitem.Name;
            txt_price.Text=selectitem.Price.ToString();
            txt_quantity.Text=selectitem.Quantity.ToString();
            txt_supplier.Text=selectitem?.Supplier?.Name;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_name.Text)||string.IsNullOrEmpty(txt_price.Text)||string.IsNullOrEmpty(txt_quantity.Text)|string.IsNullOrEmpty(txt_supplier.Text))
            {
                MessageBox.Show("please Enter or Select all data to update");
                return;
            }
            using (var db = new MyDbcontext())
            {
                var checkisvailideProduct = db.Product.FirstOrDefault(t => t.Name==txt_name.Text);
                if (checkisvailideProduct==null)
                {
                    MessageBox.Show("Product not found");
                    return;

                }
                checkisvailideProduct.Name=txt_name.Text;
                checkisvailideProduct.Price=int.Parse(txt_price.Text);
                checkisvailideProduct.Quantity=int.Parse(txt_quantity.Text);
                var checksup = db.Supplier.FirstOrDefault(t => t.SupplierID==checkisvailideProduct.SupplierID);
                checksup.Name=txt_supplier.Text;
                checkisvailideProduct.SupplierID=checksup.SupplierID;
                checkisvailideProduct.Description=checkisvailideProduct.Description;
                db.SaveChanges();
                MessageBox.Show("Product updated successfully");
                LoadData();

            }

        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(txt_name.Text)||string.IsNullOrEmpty(txt_price.Text)||string.IsNullOrEmpty(txt_quantity.Text)|string.IsNullOrEmpty(txt_supplier.Text))
            {
                MessageBox.Show("please Enter or Select all data to update");
                return;
            }
            using (var db = new MyDbcontext())
            {
                var checkisvailideProduct = db.Product.FirstOrDefault(t => t.Name==txt_name.Text);
                if (checkisvailideProduct==null)
                {
                    MessageBox.Show("Product not found");
                    return;

                }
                db.Product.Remove(checkisvailideProduct);
                db.SaveChanges();
                MessageBox.Show("Product deleted successfully");
                LoadData();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AddSupplier addSupplier=new AddSupplier();
            addSupplier.Show();
            this.Close();
        }
    }
}

