using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QuestPDF.Fluent;
using ServerCheck.Helpers;
using ServerCheck.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace ServerCheck.ViewModels
{
    public partial class ReportViewModel: ObservableObject
    {
        public ObservableCollection<WebApiServers> WebApiServers => SharedData.WebApiServers;

        [ObservableProperty]
        private string logOutput = string.Empty;

        [ObservableProperty]
        private string textFolder = string.Empty;  
        
        [ObservableProperty]
        private bool isOptionSelectedPDF;

        [ObservableProperty]
        private bool isOptionSelectedCSV;

        [ObservableProperty]
        private bool isOptionSelectedXlsx;

        [ObservableProperty]
        private bool isMonitoringEnabled;

        [ObservableProperty]
        private int? seconds = 0;

        [ObservableProperty]
        private int? interval = 5;

        [ObservableProperty]
        private WebApiServers? selectedServer;

        [RelayCommand]
        private void SelectFolder()
        {
            try
            {
                using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
                {
                    dialog.Description = "Select folder";
                    dialog.UseDescriptionForTitle = true;

                    System.Windows.Forms.DialogResult result = dialog.ShowDialog();

                    if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                    {
                        TextFolder = dialog.SelectedPath;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        [RelayCommand]
        private async Task Start()
        {
            try
            {
                LogOutput = "";
                var response = await ApiHelper.GenerateReport(SelectedServer.Host, SelectedServer.Port);

                var date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                var result = JsonSerializer.Deserialize<Report>(response);

                var output = $"""
                    {date}
                    {result.Cpu}
                    {result.Memory}
                    {string.Join("\n", result.ListDisk.Select(x => x.ToString()))}
                """;

                LogOutput = output;

                var reportPdf = new ReportDocument(output, $"Server: {SelectedServer.Host}. Port: {SelectedServer.Port}");
                QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
                reportPdf.GeneratePdf(Path.Combine(TextFolder, $"Report_{DateTime.Now.ToString("yyyy-MM-dd_HHmmss")}.pdf"));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
