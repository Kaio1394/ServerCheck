using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ServerCheck.Helpers;
using ServerCheck.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ServerCheck.ViewModels
{
    [ExcludeFromCodeCoverage]
    public partial class ProcessViewModel: ObservableObject
    {
        public ObservableCollection<Models.Process> ListProcess { get; } = new ObservableCollection<Models.Process>();
        public ObservableCollection<WebApiServers> WebApiServers => SharedData.WebApiServers;

        [ObservableProperty]
        private WebApiServers? selectedServer;

        [ObservableProperty]
        private Models.Process? selectedProcess;

        public ProcessViewModel() { }

        [RelayCommand]
        private async Task SearchAsync()
        {
            try
            {
                if (SelectedServer == null)
                {
                    MessageBox.Show("Select one server", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var listProcess = await ApiHelper.GetListProcess(selectedServer.Host, selectedServer.Port);

                ListProcess.Clear();

                foreach (var process in listProcess)
                {
                    ListProcess.Add(process);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        [RelayCommand]
        private async Task Kill()
        {
            var pid = selectedProcess.Id;

            try
            {
                var response = await ApiHelper.KillProcess(selectedServer.Host, selectedServer.Port, pid);
                MessageBox.Show($"Response: {response}");
                await SearchAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
