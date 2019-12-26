using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Логика взаимодействия для RoomsWindow.xaml
    /// </summary>
    public partial class RoomsWindow : Window
    {
        private class RoomShow
        {
            public string Name { get; set; }
            public int Area { get; set; }
            public int Temperature { get; set; }
        }

        //Контекст нашей БД
        private static ApplicationContext _dbContext;

        public RoomsWindow()
        {
            InitializeComponent();
            _dbContext = new ApplicationContext();
            DataGridSetValue();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void DataGridSetValue()
        {
            ICollection<Room> rooms = _dbContext.Rooms.ToList();

            ICollection<RoomShow> showData = new List<RoomShow>();

            foreach (var r in rooms)
            {
                showData.Add(new RoomShow()
                {
                    Name = r.Name,
                    Area = r.Area,
                    Temperature = r.Temperature
                });
            }
            // Отображение на dataGrid
            DataGridRooms.ItemsSource = showData;
        }

        private void btnDelete_click(object sender, RoutedEventArgs e)
        {
            foreach (RoomShow data in DataGridRooms.SelectedItems)
            {
                Room room = _dbContext.Rooms.FirstOrDefault(x => x.Name == data.Name &&
                                                                        x.Area == data.Area &&
                                                                        x.Temperature == data.Temperature
                                                                        );
                if (room != null)
                {
                    _dbContext.Rooms.Remove(room);
                }
            }
            
            _dbContext.SaveChanges();

            //обновление dataGrid
            DataGridSetValue();
        }

        private void btnUpdate_click(object sender, RoutedEventArgs e)
        {
            foreach (RoomShow data in DataGridRooms.SelectedItems)
            {
                if (data != null)
                {
                    var newRom = new Room() {Name = data.Name, Area = data.Area, Temperature = data.Temperature };
                    _dbContext.Rooms.Add(newRom);
                }
            }

            _dbContext.SaveChanges();

            //обновление dataGrid
            DataGridSetValue();
        }

        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            if (User.UserStatus == "A")
            {
                btnDelete.Visibility = Visibility.Visible;
                BtnUpdate.Visibility = Visibility.Hidden;
            }
            else if (User.UserStatus == "N")
            {
                btnDelete.Visibility = Visibility.Hidden;
                BtnUpdate.Visibility = Visibility.Hidden;
            }

        }
    }
}
