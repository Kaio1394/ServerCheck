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
        private bool isCheckEventViewer;

        [ObservableProperty]
        private bool isCheckMemory;

        [ObservableProperty]
        private bool isCheckDisk;

        [ObservableProperty]
        private bool isCheckCpu;

        [ObservableProperty]
        private bool isCheckProcess;

        [ObservableProperty]
        private bool isCheckService;


        [ObservableProperty]
        private int? seconds = 2;

        [ObservableProperty]
        private int? intervalSeconds = 1;

        [ObservableProperty]
        private WebApiServers? selectedServer;

        private string _output = "";

        private static List<string> _listOutput = new List<string>();

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
                string response = "";
                Report result;
                LogOutput = "";

                var dateOld = DateTime.Now;

                if (IsMonitoringEnabled)
                {
                    while ((DateTime.Now - dateOld).TotalSeconds <= Seconds)
                    {
                        _output = await GetReport();
                        _listOutput.Add(_output);
                        LogOutput += _output;
                    }
                }
                else
                {
                    _output = await GetReport();
                    _listOutput.Add(_output);
                    LogOutput += _output;
                }

                if (isOptionSelectedPDF)
                {
                    ReportDocument reportPdf = new ReportDocument(string.Join("\r\n", _listOutput), $"Server: {SelectedServer.Host}. Port: {SelectedServer.Port}");
                    QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
                    reportPdf.GeneratePdf(Path.Combine(TextFolder, $"Report_Hardware_{DateTime.Now.ToString("yyyy-MM-dd_HHmmss")}.pdf"));
                }else if (isOptionSelectedCSV)
                {

                }
                else if (isOptionSelectedXlsx)
                {

                }
                else
                {
                    MessageBox.Show($"Select one type file extension.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task<string> GetReport()
        {
            try
            {
                var response = await ApiHelper.GenerateReport(SelectedServer.Host, SelectedServer.Port);
                var result = JsonSerializer.Deserialize<Report>(response);
                _output =                 
                    (IsCheckCpu ? result.Cpu + "\n" : "") +
                    (IsCheckMemory ? result.Memory + "\n" : "") +
                    (IsCheckDisk ? string.Join("\n", result.ListDisk.Select(x => x.ToString())) : "");

                _output = string.Join("\n",
                    _output.Split('\n')
                            .Select(line => line.Trim())
                            .Where(line => !string.IsNullOrEmpty(line))
                );

                _output =
                    "\n____________________________________________________________________________\n" +
                    $"Date Collect: {DateTime.Now:yyyy-MM-dd HH:mm:ss}\n" +
                    _output;
                return _output;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
