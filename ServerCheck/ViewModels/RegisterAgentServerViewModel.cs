using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ServerCheck.Helpers;
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
        public ObservableCollection<WebApiServers> WebApiServers => SharedData.WebApiServers;

        [ObservableProperty]
        private string host;

        [ObservableProperty]
        private int port;

        public RegisterAgentServerViewModel()
        {
        }

        [RelayCommand]
        private void Add()
        {
            if (!string.IsNullOrWhiteSpace(Host))
            {
                SharedData.WebApiServers.Add(new WebApiServers
                {
                    Uuid = Guid.NewGuid().ToString(),
                    Host = Host,
                    Port = Port
                });

                Host = string.Empty;
                Port = 0;
            }
        }

    }
}
