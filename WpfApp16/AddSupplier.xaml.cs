using Microsoft.EntityFrameworkCore.SqlServer;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp16.Data;
using WpfApp16.Models;

namespace WpfApp16
{
    /// <summary>
    /// Interaction logic for AddSupplier.xaml
    /// </summary>
    public partial class AddSupplier : Window
    {
        public AddSupplier()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_gmail.Text) || string.IsNullOrEmpty(txt_ID.Text) || string.IsNullOrEmpty(txt_name.Text) || string.IsNullOrEmpty(txt_Phone.Text))
            {
                MessageBox.Show("Please Enter All Data");
                return;
            }
            if (!txt_Phone.Text.Trim().All(char.IsDigit)|| !txt_ID.Text.Trim().All(char.IsDigit))
            {
                MessageBox.Show("Id And Phone number must Be Digit😒");
                return;
            }
            if(txt_Phone.Text.Length!=11)
            {
                MessageBox.Show("Phoner juyu");
                return;
            }
           
            using (var db=new MyDbcontext())
            {
                var check = db.Supplier.FirstOrDefault(t => t.SupplierID == int.Parse(txt_ID.Text));
                if (check != null)
                {
                    MessageBox.Show("This Supplier Available");
                    return;
                }
               
                Supplier _supplier = new Supplier
               { 
                 SupplierID=int.Parse(txt_ID.Text),
                 Name=txt_name.Text,
                 Email=txt_gmail.Text,
                 Phone=txt_Phone.Text,
               };
                db.Supplier.Add(_supplier);
                db.SaveChanges();
                MessageBox.Show("Suuplier Added Successfulyy");
                txt_Phone.Clear();
                txt_ID.Clear();
                txt_name.Clear();
                txt_gmail.Clear();  
            }

        }
    }
}
