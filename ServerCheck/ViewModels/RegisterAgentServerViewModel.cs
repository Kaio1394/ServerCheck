using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ServerCheck.Helpers;
using ServerCheck.Models;
using ServerCheck.Repositories.Interfaces;
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
