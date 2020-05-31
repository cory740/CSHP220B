using System;
using System.Windows;
using DogBusinessApp.Models;

namespace DogBusinessApp
{
    /// <summary>
    /// Interaction logic for BreederWindow.xaml
    /// </summary>
    public partial class BreederWindow : Window
    {
        public BreederWindow()
        {
            InitializeComponent();
        }

        public BreederModel Breeder { get; set; }
        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (uxMale.IsChecked.Value)
            {
                Breeder.Gender = "Male";
            }
            else
            {
                Breeder.Gender = "Female";
            }

            DialogResult = true;
            Close();

        }

        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Breeder != null)
            {
                if (Breeder.Gender == "Male")
                {
                    uxMale.IsChecked = true;
                }
                else
                {
                    uxFemale.IsChecked = true;
                }
               
            }
            else
            {
                Breeder = new BreederModel();
                Breeder.CreatedDate = DateTime.Now;
            }

            uxGrid.DataContext = Breeder;
        }
    }
}
