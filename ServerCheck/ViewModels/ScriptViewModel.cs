using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using ServerCheck.Helpers;
using ServerCheck.Models;
using ServerCheck.Models.Response;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace ServerCheck.ViewModels
{
    public partial class ScriptViewModel: ObservableObject
    {
        public ObservableCollection<WebApiServers> WebApiServers => SharedData.WebApiServers;

        [ObservableProperty]
        private WebApiServers? selectedServer;

        [ObservableProperty]
        private string code = string.Empty;

        [ObservableProperty]
        private string scriptOutput = string.Empty;

        [RelayCommand]
        private async Task ExecuteScript(string? rawScript)
        {
            Code = rawScript ?? string.Empty;

            var scriptModel = new Script()
            {
                Code = Code,
                TimeoutSeconds = 60
            };

            string jsonString = JsonSerializer.Serialize(scriptModel);

            if (SelectedServer is null)
            {
                MessageBox.Show("Select one server", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var response = await ApiHelper.ExecuteScriptPython(SelectedServer.Host, SelectedServer.Port, jsonString);

            var responseModel = JsonSerializer.Deserialize<ResponseScriptOutput>(response);

            ScriptOutput = $"Executable: {responseModel?.PathExecutable}\n"
                + $"Output: {responseModel?.Output}";
        }

        //[RelayCommand]
        //private void ImportFile()
        //{
        //    var dialog = new OpenFileDialog
        //    {
        //        Title = "Select a scrypt python.",
        //        Filter = "Arquivos de texto (*.txt)|*.txt|Python (*.py)|*.py|Todos os arquivos (*.*)|*.*",
        //        Multiselect = false
        //    };

        //    if (dialog.ShowDialog() == true)
        //    {
        //        string filePath = dialog.FileName;
        //        string content = File.ReadAllText(filePath);

        //        Code = content; 
        //    }
        //}
    }
}
