using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ServerCheck.Helpers;
using ServerCheck.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ServerCheck.ViewModels
{
    public partial class EventViewerViewModel: ObservableObject
    {
        public ObservableCollection<WebApiServers> WebApiServers => SharedData.WebApiServers;

        public ObservableCollection<Models.EventView> ListEventViewer { get; } = new ObservableCollection<Models.EventView>();

        [ObservableProperty]
        private string? selectedEntryType; 
        
        [ObservableProperty]
        private string? selectedLogName;

        [ObservableProperty]
        private int limitMessages;

        [ObservableProperty]
        private DateTime? selectedDate;

        [ObservableProperty]
        private WebApiServers? selectedServer;

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

                string host = SelectedServer.Host;
                int port = SelectedServer.Port;

                var date = SelectedDate.Value.ToString("yyyy-MM-dd");

                ListEventViewer.Clear();

                var listEventViewer = await ApiHelper.GetListEventViewer(host, port, SelectedEntryType, SelectedLogName, date, LimitMessages);
                foreach (var eventV in listEventViewer)
                {
                    ListEventViewer.Add(eventV);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
