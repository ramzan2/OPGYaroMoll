using Microsoft.VisualBasic.ApplicationServices;
using OPGYaroMoll.ClassFolder;
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

namespace OPGYaroMoll.WindowFolder.CashierFolder
{
    /// <summary>
    /// Логика взаимодействия для MenuCashierWindow.xaml
    /// </summary>
    public partial class MenuCashierWindow : Window
    {
        public MenuCashierWindow(DataFolder.User user)
        {
            InitializeComponent();
            DataContext = user;
            MainFrame.Navigate(new PageFolder.CashierFolder.ListCashierPage());
        }

        private void ListTickersBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PageFolder.CashierFolder.ListCashierPage());
            ListTickersBtn.Background = new SolidColorBrush(Colors.White);
            AddTickersBtn.Background = new SolidColorBrush(Colors.Transparent);
        }

        private void AddTickersBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddTickersWindow().Show();
            AddTickersBtn.Background = new SolidColorBrush(Colors.White);
            ListTickersBtn.Background = new SolidColorBrush(Colors.Transparent);
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            new AuthorizationWindow().Show();
            Close();
        }

    }
}
