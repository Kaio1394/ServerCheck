using Microsoft.Win32;
using ServerCheck.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
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

namespace ServerCheck.Views
{
    /// <summary>
    /// Interaction logic for ScriptView.xaml
    /// </summary>
    public partial class ScriptView : UserControl
    {
        private readonly ScriptViewModel _viewModel;

        public ScriptView()
        {
            InitializeComponent();
            _viewModel = new ScriptViewModel();
            DataContext = _viewModel;
        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            var rawScript = CodeEditor.Text;
            _viewModel.ExecuteScriptCommand.Execute(rawScript);
        }

        private void ImportFileButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = "Select a scrypt python.",
                Filter = "Arquivos de texto (*.txt)|*.txt|Python (*.py)|*.py|Todos os arquivos (*.*)|*.*",
                Multiselect = false
            };

            if (dialog.ShowDialog() == true)
            {
                string filePath = dialog.FileName;
                string content = File.ReadAllText(filePath);
                CodeEditor.Text = content;  
            }
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            CodeEditor.Text = "";
        }
    }
}
