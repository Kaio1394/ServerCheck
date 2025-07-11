using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ServerCheck.Helpers;
using ServerCheck.Models;
using ServerCheck.Repositories.Interfaces;
using ServerCheck.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace ServerCheck.ViewModels
{
    public partial class RegisterAgentServerViewModel: ObservableObject
    {
        private readonly IWebApiServersRepository _webApiServersRepository;
        public ObservableCollection<WebApiServers> WebApiServers => SharedData.WebApiServers;

        [ObservableProperty]
        private string host;

        [ObservableProperty]
        private int port;

        [ObservableProperty]
        private WebApiServers selectedWebApiServers;

        public RegisterAgentServerViewModel(IWebApiServersRepository webApiServersRepository)
        {
            _webApiServersRepository = webApiServersRepository;
            LoadlistDataBase();         
        }

        private async Task LoadlistDataBase()
        {
            var listDb = await _webApiServersRepository.GetAllWebApiServers();
            SharedData.WebApiServers.Clear();
            foreach (var item in listDb)
            {
                SharedData.WebApiServers.Add(item);
            }
        }

        [RelayCommand]
        private async Task Edit()
        {
            if (selectedWebApiServers == null)
                return;

            var window = new EditWebApiServerWindow(selectedWebApiServers);
            var result = window.ShowDialog();

            if (result == true)
            {
                var edited = window.EditedServer;

                var index = WebApiServers.IndexOf(selectedWebApiServers);
                if (index >= 0)
                {
                    WebApiServers[index] = edited;
                    MessageBox.Show($"Save with successfull!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        [RelayCommand]
        private async Task Delete()
        {
            if (selectedWebApiServers == null)
                return;

            var result = MessageBox.Show($"Are you sure?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
                return;

            WebApiServers.Remove(selectedWebApiServers);
        }

        [RelayCommand]
        private async Task Add()
        {
            if (!string.IsNullOrWhiteSpace(Host))
            {
                var newServer = new WebApiServers
                {
                    Uuid = Guid.NewGuid().ToString(),
                    Host = Host,
                    Port = Port
                };

                var webApiServer = await _webApiServersRepository.GetWebApiServerByHost(host);

                if (webApiServer != null)
                {
                    MessageBox.Show($"Config. Web Server alreay exists.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                try
                {
                    await _webApiServersRepository.AddWebApiServer(newServer);
                    SharedData.WebApiServers.Add(newServer);
                    Host = string.Empty;
                    Port = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
