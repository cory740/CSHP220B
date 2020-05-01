using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for NavigatorWindow.xaml
    /// </summary>
    public partial class NavigatorWindow : Window
    {
        public NavigatorWindow()
        {
            InitializeComponent();
        }

        private void uxGo_Clicked(object sender, RoutedEventArgs e)
        {
            var fileName = uxURL.Text;

            var processStartInfo = new ProcessStartInfo(fileName)
            {
                UseShellExecute = true,
                Verb = "open",
            };

            Process.Start(processStartInfo);

        }
    }
}
