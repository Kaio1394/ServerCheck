using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ServerCheck.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCheck.ViewModels
{
    public partial class RegisterAgentServerViewModel: ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<WebApiServers> webApiServers;

        [ObservableProperty]
        private string host;

        [ObservableProperty]
        private int port;

        public RegisterAgentServerViewModel()
        {
            WebApiServers = new ObservableCollection<WebApiServers>();
        }

        [RelayCommand]
        private void Add()
        {
            if (!string.IsNullOrWhiteSpace(host))
            {
                WebApiServers.Add(new WebApiServers
                {
                    Uuid = Guid.NewGuid().ToString(),
                    Host = host,
                    Port = Port
                });

                host = string.Empty;
                Port = 0;
            }
        }

    }
}
