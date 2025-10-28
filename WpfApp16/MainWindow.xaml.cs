using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp16.Data;

namespace WpfApp16
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(txt_name.Text)||string.IsNullOrEmpty(txt_pass.Password))
            {
                MessageBox.Show("please Enter all data");
                return;
            }
            using (var db=new MyDbcontext())
            {
                var checkUser = db.User.FirstOrDefault(t => t.Name==txt_name.Text&&t.Password==txt_pass.Password);
                if(checkUser==null)
                {
                    MessageBox.Show("Sorry User Not Found!");
                    return;
                }
                if(checkUser.Role=="Stock Clerk")
                {
                    Stockwindow stockwindow = new Stockwindow();    
                    stockwindow.Show(); 
                    this.Close();
                }
                if(checkUser.Role=="Administrator")
                {
                    Adminstrator adminstrator = new Adminstrator();
                    adminstrator.Show();    
                    this.Close();
                }

            }
        }
    }
}