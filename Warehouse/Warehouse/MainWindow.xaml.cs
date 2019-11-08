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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Warehouse.Model;

namespace Warehouse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
   
    public partial class MainWindow : Window
    {
        private static bool openLogin = true;
        public MainWindow()
        {
            InitializeComponent();

            ApplicationContext context = new ApplicationContext();

            if (openLogin)
            {
                Login login = new Login();
                login.Show();
                this.Close();
                openLogin = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WorkersWindow workersWindow = new WorkersWindow();
            workersWindow.Show();
            this.Close();
        }
    }
}
