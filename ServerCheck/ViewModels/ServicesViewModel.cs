using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ServerCheck.Helpers;
using ServerCheck.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace ServerCheck.ViewModels
{
    public partial class ServicesViewModel : ObservableObject
    {
        public ObservableCollection<WebApiServers> WebApiServers => SharedData.WebApiServers;
        public ObservableCollection<Service> Services { get; } = new ObservableCollection<Service>();

        [ObservableProperty]
        private WebApiServers? selectedServer;

        [ObservableProperty]
        private Service? selectedService;

        [ObservableProperty]
        private bool isSelected;

        public ServicesViewModel()
        {
        }

        [RelayCommand]
        private async Task StartService()
        {
            if (SelectedService == null)
            {
                MessageBox.Show("No service selected");
                return;
            }

            string host = SelectedServer.Host;
            int port = SelectedServer.Port;

            try
            {
                string response = await ApiHelper.StartStopService(0, SelectedService.ServiceName, host, port);
                MessageBox.Show($"Response: {response}");
                await SearchAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        [RelayCommand]
        private async Task StopService()
        {
            if (SelectedService == null)
            {
                MessageBox.Show("No service selected");
                return;
            }

            string host = SelectedServer.Host;
            int port = SelectedServer.Port;

            try
            {
                string response = await ApiHelper.StartStopService(1, SelectedService.ServiceName, host, port);
                MessageBox.Show($"Response: {response}");
                await SearchAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        [RelayCommand]
        private async Task SearchAsync()
        {
            try
            {
                if (SelectedServer == null)
                {
                    MessageBox.Show("Selecione um servidor", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                string host = SelectedServer.Host;
                int port = SelectedServer.Port;

                List<Service> listServices = await ApiHelper.GetServicesAsync(host, port);

                Services.Clear();

                foreach (var service in listServices)
                {
                    Services.Add(service);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
