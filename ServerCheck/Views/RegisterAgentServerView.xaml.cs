using ServerCheck.Data;
using ServerCheck.Repositories.Interfaces;
using ServerCheck.Repositories;
using ServerCheck.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;

namespace ServerCheck.Views
{
    /// <summary>
    /// Interaction logic for RegisterAgentView.xaml
    /// </summary>
    public partial class RegisterAgentView : UserControl
    {
        public RegisterAgentView()
        {
            InitializeComponent();

            IWebApiServersRepository repository = new WebApiServersRepository(new ServerCheckDbContext());

            DataContext = new RegisterAgentServerViewModel(repository);
        }
    }
}
