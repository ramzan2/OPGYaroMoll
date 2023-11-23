using OPGYaroMoll.ClassFolder;
using OPGYaroMoll.DataFolder;
using OPGYaroMoll.WindowFolder.ManagerFolder.PerformanceFolder;
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

namespace OPGYaroMoll.PageFolder.ManagerFolder
{
    /// <summary>
    /// Логика взаимодействия для ListPerformancePage.xaml
    /// </summary>
    public partial class ListPerformancePage : Page
    {
        public ListPerformancePage()
        {
            Performance performance = new Performance();
            InitializeComponent();
            VariableClass.ListPerformancePage1 = this;
            UpdateList();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();
        }

        public void UpdateList()
        {
            membersDataGrid.ItemsSource = DBEntities.GetContext()
          .Performance.Where(u => u.TitlePerformance
          .StartsWith(SearchTb.Text))
          .ToList().OrderBy(u => u.TitlePerformance);
            //if (VariableClass.AddTickersBtn_Click2 != null) VariableClass.AddTickersBtn_Click2.UpdateList();
        }

        private void EditPerformanceBtn_Click(object sender, RoutedEventArgs e)
        {
            new EditPerformanceWindow(membersDataGrid.SelectedItem as Performance).Show();
        }

        private void DeletePerformance_Click(object sender, RoutedEventArgs e)
        {
            Performance performance = membersDataGrid.SelectedItem as Performance;

            if (membersDataGrid.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите представление" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QuestionMB("Удалить " +
                    $"представление " +
                    $"{performance.TitlePerformance}?"))
                {
                    DBEntities.GetContext().Performance
                        .Remove(membersDataGrid.SelectedItem as Performance);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InfoMB("Представление удаленно");
                    membersDataGrid.ItemsSource = DBEntities.GetContext()
                        .Performance.ToList().OrderBy(u => u.TitlePerformance);
                }

            }
        }

        private void AddPerformanceBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddPerformanceWindow().Show();
        }
    }
}
