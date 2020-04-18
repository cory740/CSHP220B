using System;
using System.Collections.Generic;
using System.ComponentModel;
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

//Cory Eby
//Homework 3
//Sort ListView
namespace CEby_Homework3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private GridViewColumnHeader listViewSortCol = null;
        public MainWindow()
        {
            InitializeComponent();

            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "1DavePwd" });
            users.Add(new Models.User { Name = "Steve", Password = "2StevePwd" });
            users.Add(new Models.User { Name = "Lisa", Password = "3LisaPwd" });

            uxList.ItemsSource = users;
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortby = column.Tag.ToString();
            if(listViewSortCol != null)
            {
                uxList.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (listViewSortCol == column)
                newDir = ListSortDirection.Descending;

            listViewSortCol = column;
            uxList.Items.SortDescriptions.Add(new SortDescription(sortby, newDir));
        }
    }
}
