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

//Cory Eby
//Homework 5

namespace CEby_Homework5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool turn = true;
        int turn_count = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var splitTag = button.Tag.ToString().Split(",");

            if (turn)
            {
                button.Content = "X";
            }
            else
            {
                button.Content = "O";
            }
            turn = !turn;
            button.IsEnabled = false;
            turn_count++;

            var row = from btn in uxGrid.Children.OfType<Button>()
                      where btn.Content != null &&
                      btn.Content.ToString() == button.Content.ToString() &&
                      btn.Tag.ToString().Split(",")[0] == button.Tag.ToString().Split(",")[0]
                      select btn;

            var col = from btn in uxGrid.Children.OfType<Button>()
                      where btn.Content != null &&
                      btn.Content.ToString() == button.Content.ToString() &&
                      btn.Tag.ToString().Split(",")[1] == button.Tag.ToString().Split(",")[1]
                      select btn;

            bool rowWinner = row.Count() == 3;
            bool colWinner = col.Count() == 3;
            
            if (rowWinner || colWinner)
            {
                MessageBox.Show($"The winner is {button.Content}!");
                disableAllButtons();
            }
        }


        private void disableAllButtons()
        {
            A1.IsEnabled = false;
            A2.IsEnabled = false;
            A3.IsEnabled = false;
            B1.IsEnabled = false;
            B2.IsEnabled = false;
            B3.IsEnabled = false;
            C1.IsEnabled = false;
            C2.IsEnabled = false;
            C3.IsEnabled = false;
        }

        void reset()
        {
            A1.IsEnabled = true;
            A2.IsEnabled = true;
            A3.IsEnabled = true;
            B1.IsEnabled = true;
            B2.IsEnabled = true;
            B3.IsEnabled = true;
            C1.IsEnabled = true;
            C2.IsEnabled = true;
            C3.IsEnabled = true;
            A1.Content = "";
            A2.Content = "";
            A3.Content = "";
            B1.Content = "";
            B2.Content = "";
            B3.Content = "";
            C1.Content = "";
            C2.Content = "";
            C3.Content = "";
            turn_count = 0;
        }



        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("A new game has started!");
            reset();

        }
    }
}

