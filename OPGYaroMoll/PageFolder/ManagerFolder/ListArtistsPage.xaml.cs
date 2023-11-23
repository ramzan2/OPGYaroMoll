using OPGYaroMoll.ClassFolder;
using OPGYaroMoll.DataFolder;
using OPGYaroMoll.WindowFolder.ManagerFolder.ArtistsFolder;
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
    /// Логика взаимодействия для ListArtistsPage.xaml
    /// </summary>
    public partial class ListArtistsPage : Page
    {
        public ListArtistsPage()
        {
            Artists artists = new Artists();
            InitializeComponent();
            VariableClass.ListArtistsPage1 = this;
            UpdateList();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();
        }

        public void UpdateList()
        {
            membersDataGrid.ItemsSource = DBEntities.GetContext()
          .Artists.Where(u => u.NameArtists
          .StartsWith(SearchTb.Text))
          .ToList().OrderBy(u => u.NameArtists);
        }

        private void EditArtistsBtn_Click(object sender, RoutedEventArgs e)
        {
            new EditArtistsWindow().Show();
        }

        private void DeleteArtists_Click(object sender, RoutedEventArgs e)
        {
            Artists artists = membersDataGrid.SelectedItem as Artists;

            if (membersDataGrid.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите артиста" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QuestionMB("Удалить " +
                    $"артиста " +
                    $"{artists.NameArtists}?"))
                {
                    DBEntities.GetContext().Artists
                        .Remove(membersDataGrid.SelectedItem as Artists);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InfoMB("Представление удаленно");
                    membersDataGrid.ItemsSource = DBEntities.GetContext()
                        .Artists.ToList().OrderBy(u => u.NameArtists);
                }

            }
        }

        private void AddArtistsBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
