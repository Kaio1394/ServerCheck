using ServerCheck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ServerCheck.Windows
{
    /// <summary>
    /// Interaction logic for EditWebApiServerWindow.xaml
    /// </summary>
    public partial class EditWebApiServerWindow : Window
    {
        public WebApiServers EditedServer { get; private set; }
        public EditWebApiServerWindow(WebApiServers serverToEdit)
        {
            InitializeComponent();
            EditedServer = new WebApiServers
            {
                Uuid = serverToEdit.Uuid,
                Host = serverToEdit.Host,
                Port = serverToEdit.Port
            };
            DataContext = EditedServer;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
