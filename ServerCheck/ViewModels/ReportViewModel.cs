using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCheck.ViewModels
{
    public partial class ReportViewModel: ObservableObject
    {
        [ObservableProperty]
        private string logOutput = string.Empty;
    }
}
