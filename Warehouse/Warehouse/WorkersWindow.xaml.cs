using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Warehouse.Model;

namespace Warehouse
{
    /// <summary>
    /// Логика взаимодействия для WorkersWindow.xaml
    /// </summary>
    public partial class WorkersWindow : Window
    {
        public WorkersWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ApplicationContext db = new ApplicationContext();
            Worker w = new Worker { FirstName = txtbox1.Text, LastName = txtbox2.Text };
            db.Workers.AddRange(new List<Worker> { w });
            db.SaveChanges();
        }
    }
}
