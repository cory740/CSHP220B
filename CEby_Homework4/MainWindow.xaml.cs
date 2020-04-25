using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
//Homework 4

namespace CEby_Homework4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            uxSubmit.IsEnabled = false;

        }

        private void uxZip_TextChanged(object sender, TextChangedEventArgs e)
        {
            string usZipPattern = @"^\d{5}(?:[-\s]\d{4})?$";
            string caZipPattern = @"[A-Za-z]\d[A-Za-z]\d[A-Za-z]\d";
            bool isUsZipAllowed = Regex.IsMatch(uxZip.Text, usZipPattern);
            bool isCaZipAllowed = Regex.IsMatch(uxZip.Text, caZipPattern);

            if (isUsZipAllowed || isCaZipAllowed)
            {
                uxSubmit.IsEnabled = true;
            }
            else
            {
                uxSubmit.IsEnabled = false;
               
            }
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"You've entered the follow Zip Code: {uxZip.Text} ");
        }
    }
}
