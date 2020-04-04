using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


//Cory Eby Homework 1

namespace Ceby_Homework1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;

            uxName.Text = "";
            uxPassword.Text = "";
            uxSubmit.IsEnabled = false;
            uxThumbsUp.IsEnabled = false;
            
        }

        private void ButtonVisibility()
        {
            if (uxName.Text == string.Empty || uxPassword.Text == string.Empty)
            {
                uxSubmit.IsEnabled = false;
                uxThumbsUp.IsEnabled = false;
            }
            else
            {
                uxSubmit.IsEnabled = true;
                uxThumbsUp.IsEnabled = false;
            }
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"You entered credentials\n\nUsername: {uxName.Text}\nPassword: {uxPassword.Text}");
        }

        private void uxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ButtonVisibility();
        }

        private void uxPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            ButtonVisibility();
        }
    }
}
