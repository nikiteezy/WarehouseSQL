using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Warehouse.Model;

namespace Warehouse
{
    /// <summary>
    /// Это модель данных работника
    /// Поля в ней соответсвуют тем, что будут отображатсья на странице
    /// </summary>
    public class RoomWorkerShow
    {
        public RoomWorkerShow(string firstName, string lastName, List<string> list)
        {
            FirstName = firstName;
            LastName = lastName;
            Rooms = string.Join(", ", list);
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Rooms { get; set; }
    }

    /// <summary>
    /// Логика взаимодействия для WorkersWindow.xaml
    /// </summary>
    public partial class WorkersWindow : Window
    {
        //Контекст нашей БД
        private static ApplicationContext _dbContext;
       
        /// <summary>
        /// Конструктор класса нашего окна
        /// </summary>
        public WorkersWindow()
        {
            InitializeComponent();

            //Инициализация нашего контекста
            _dbContext = new ApplicationContext();

            DataGridSetValue();

            if (User.UserStatus == "N")
            {
                btnDismissed.Visibility = Visibility.Hidden;
                txtBoxFirstName.Visibility = Visibility.Hidden;
                txtBoxLastName.Visibility = Visibility.Hidden;
                btnAdd.Visibility = Visibility.Hidden;
            }
            else if (User.UserStatus == "A") 
            {
                btnDismissed.Visibility = Visibility.Visible;
                txtBoxFirstName.Visibility = Visibility.Visible;
                txtBoxLastName.Visibility = Visibility.Visible;
                btnAdd.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Возврат на предыдущую страницу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();

        }
        

        /// <summary>
        /// Делаем запрос к бд и вытягиваем работников с нахваниями складов, где они работают
        /// Добавляем все это в DataGrid
        /// </summary>
        private void DataGridSetValue() 
        {
            ICollection<Worker> workers = _dbContext.Workers.Include(rw => rw.RoomWorkers).ThenInclude(r => r.Room).ToList();

            ICollection<RoomWorkerShow> showData = new List<RoomWorkerShow>();

            foreach (var wr in workers)
            {
                ICollection<string> rooms = wr.RoomWorkers.Select(r => r.Room.Name).ToList();

                showData.Add(new RoomWorkerShow(wr.FirstName,
                                                 wr.LastName,
                                                 rooms.ToList()));
            }
            // Отображение на dataGrid
            DataGridWorkers.ItemsSource = showData;
        }

        /// <summary>
        /// Добавление рабочего
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddWorker_Click(object sender, RoutedEventArgs e)
        {
            Worker w = new Worker { FirstName = txtBoxFirstName.Text, LastName = txtBoxLastName.Text };
            _dbContext.Workers.AddRange(new List<Worker> { w });
            _dbContext.SaveChanges();

            //обновление dataGrid
            DataGridSetValue();
        }
        
        /// <summary>
        /// Увольнение рабочего
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDismissed_Click(object sender, RoutedEventArgs e)
        {
            foreach (RoomWorkerShow data in DataGridWorkers.SelectedItems)
            {
                Worker worker = _dbContext.Workers.FirstOrDefault(x => x.FirstName == data.FirstName &&
                                                                        x.LastName == data.LastName);
                if (worker != null) 
                {
                    _dbContext.Workers.Remove(worker);
                }
            }

            _dbContext.SaveChanges();

            //обновление dataGrid
            DataGridSetValue();
        }

        
    }
}
