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
using DogBusinessApp.Models;

namespace DogBusinessApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;
        public MainWindow()
        {
            InitializeComponent();
            LoadBreeders();
        }

        private void LoadBreeders()
        {
            var breeders = App.DogRepository.GetAll();

            uxBreederList.ItemsSource = breeders
                .Select(repostoryBreeder => BreederModel.ToModel(repostoryBreeder))
                .ToList();
        }

        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new BreederWindow();

            if (window.ShowDialog() == true)
            {
                var uiBreederModel = window.Breeder;

                var repositoryModel = uiBreederModel.ToRepositoryModel();

                App.DogRepository.Add(repositoryModel);

                LoadBreeders();
            }
        }

        private void uxBreederListColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();
            if (listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                uxBreederList.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (listViewSortCol == column)
                newDir = ListSortDirection.Descending;

            listViewSortCol = column;
            listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
            AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
            uxBreederList.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));

        }

        private BreederModel selectedBreeder;
        private void uxBreederList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedBreeder = (BreederModel)uxBreederList.SelectedValue;
        }

        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            App.DogRepository.Remove(selectedBreeder.Id);
            selectedBreeder = null;
            LoadBreeders();
        }

        private void uxFileDelete_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileDelete.IsEnabled = (selectedBreeder != null);
            uxContextFileDelete.IsEnabled = uxFileDelete.IsEnabled;
        }

        private void uxFileChange_Click(object sender, RoutedEventArgs e)
        {
            EditBreeder();
        }

        private void uxFileChange_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileChange.IsEnabled = (selectedBreeder != null);
            uxContextFileChange.IsEnabled = uxFileChange.IsEnabled;
        }

        private void EditBreeder()
        {
            var window = new BreederWindow();
            window.Breeder = selectedBreeder.Clone();

            if (window.ShowDialog() == true)
            {
                App.DogRepository.Update(window.Breeder.ToRepositoryModel());
                LoadBreeders();
            }
        }
    }
}
