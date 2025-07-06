using ServerCheck.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCheck.Helpers
{
    public static class SharedData
    {
        public static ObservableCollection<WebApiServers> WebApiServers { get; } = new ObservableCollection<WebApiServers>();
    }
}
