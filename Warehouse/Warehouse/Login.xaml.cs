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

namespace Warehouse
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            TxtBoxLogin.SelectionStart = TxtBoxLogin.Text.Length;
            TxtBoxLogin.Focus();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TxtBoxLogin.Text == "Login" && TxtBoxPas.Password == "00000")
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();
            }
            else 
            {
                LoginBtn.Background = new SolidColorBrush(Color.FromArgb(100, 0xFF, 0xa2, 0xd5));
            }

        }

        private void TxtBoxPas_DragEnter(object sender, DragEventArgs e)
        {

        }
    }
}
