using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for StatusWIndow.xaml
    /// </summary>
    public partial class StatusWIndow : Window
    {
        public StatusWIndow()
        {
            InitializeComponent();

            uxProgressBar.Maximum = uxTextEditor.MaxLength;

            //uxProgressBar.Maximum = 100;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            //worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;

            worker.RunWorkerAsync();
        }

        private void uxTextEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            int row = uxTextEditor.GetLineIndexFromCharacterIndex(uxTextEditor.CaretIndex);
            int col = uxTextEditor.CaretIndex - uxTextEditor.GetCharacterIndexFromLineIndex(row);
            uxStatus.Text = "Line " + (row + 1) + ", Column " + (col + 1);
            uxProgressBar.Value = uxTextEditor.Text.Length;

        //    int row = uxTextEditor.GetLineIndexFromCharacterIndex(uxTextEditor.CaretIndex);

         //   int col = uxTextEditor.CaretIndex - uxTextEditor.GetCharacterIndexFromLineIndex(row);

            if (uxTextEditor.CaretIndex == 0)
            {
                row = 0;
                col = 0;
            }

            int percentage = 100 * uxTextEditor.Text.Length / uxTextEditor.MaxLength;

         //   uxPercentageComplete.Text = string.Format("{0}", percentage);
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            uxProgressBar.Value = e.ProgressPercentage;
        }
    }
}
