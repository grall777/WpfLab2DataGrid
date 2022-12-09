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
using System.Data.Entity;
using WpfApp1.Models;


namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        UsersContext db;
        public MainWindow()
        {
            InitializeComponent();
            

        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowAdd winAdd = new WindowAdd();
            winAdd.Show();
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            WindowDelete winDelete = new WindowDelete();
            winDelete.Show();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowEdit winEdit = new WindowEdit();
            winEdit.Show();
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            string request = TextBoxSearch.Text;

        }

        private void UsersGrid_Loaded(object sender, RoutedEventArgs e)
        {
            db = new UsersContext();
            db.Users.Load();
            UsersGrid.ItemsSource = db.Users.Local.ToBindingList();

            this.Closing += MainWindow_Closing;
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            db = new UsersContext();
            db.Users.Load();
            UsersGrid.ItemsSource = db.Users.Local.ToBindingList();

            this.Closing += MainWindow_Closing;
        }
    }
}
