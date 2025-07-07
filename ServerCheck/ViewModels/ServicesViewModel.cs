using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ServerCheck.Helpers;
using ServerCheck.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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

        public ServicesViewModel()
        {
        }

        [RelayCommand]
        private async Task SearchAsync()
        {
            try
            {
                if (SelectedServer == null)
                {
                    System.Windows.MessageBox.Show("Select at least one item in the combobox", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
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
