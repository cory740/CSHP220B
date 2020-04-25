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
            uxZipError.IsEnabled = false;


        }

        
        private static readonly Regex usZip = new Regex(@"^\d{5}(?:[-\s]\d{4})?$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static readonly Regex caZip = new Regex(@"[A-Za-z]\d[A-Za-z]\d[A-Za-z]\d");

        private static bool IsTextAllowed(string uxZip)
        {
            return !usZip.IsMatch(uxZip);
        }
      // private bool IsUSOrCanadianZip(string uxZip)
      // {
      //     var validZip = true;
      //
      //     if ((!Regex.Match(uxZ, usZip).Success) && (!Regex.Match(uxZip, caZip).Success))
      //     {
      //         validZip = true;
      //     }
      //     return validZip;
      // }
        private void uxZip_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.Match(uxZip.Text, usZip).Success || Regex.Match(uxZip.Text, caZip).Success)
            {
                uxSubmit.IsEnabled = false;
            }
            else
            {
                uxSubmit.IsEnabled = false;
                uxZipError.IsEnabled = true;

            }
        }
    }
}
