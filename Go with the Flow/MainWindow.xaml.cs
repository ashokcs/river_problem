/********************************************
 * Author: Brock Sawlor
 * 5558077
 * bsawlor8077@conestogac.on.ca
 * *****************************************/

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Go_with_the_Flow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly VM vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = VM.Instance;
            DataContext = vm;

            Title = "Go with the Flow";

        }

        private void TextBlock_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            vm.RiverCheck();
        }

        private void ImportFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                vm.Input = openFileDialog.FileName;
                try
                {
                    vm.Input = File.ReadAllText(openFileDialog.FileName);
                }
                catch (IOException ex)
                {
                    MessageBox.Show("The file could not be read: " + ex);
                }
            }
            if (vm.Input != "") { vm.OpenFile(); }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            vm.NumberWords = "";
            vm.NumberWordsThick = 0;
            vm.Paragraph = "";
        }
    }
}
