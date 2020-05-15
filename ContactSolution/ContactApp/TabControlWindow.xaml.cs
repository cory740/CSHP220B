using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ContactApp
{
    /// <summary>
    /// Interaction logic for TabControlWindow.xaml
    /// </summary>
    public partial class TabControlWindow : Window
    {
        public TabControlWindow()
        {
            InitializeComponent();
        }

        private void btnPreviousTab_Click(object sender, RoutedEventArgs e)
        {
            int newIndex = uxTab.SelectedIndex - 1;
            if (newIndex < 0)
                newIndex = uxTab.Items.Count - 1;
            uxTab.SelectedIndex = newIndex;
        }

        private void btnNextTab_Click(object sender, RoutedEventArgs e)
        {
            int newIndex = uxTab.SelectedIndex + 1;
            if (newIndex >= uxTab.Items.Count)
                newIndex = 0;
            uxTab.SelectedIndex = newIndex;
        }

        private void btnSelectedTab_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Selected tab: " + (uxTab.SelectedItem as TabItem).Header);
        }
    }
}
