﻿using ServerCheck.ViewModels;
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

namespace ServerCheck.Views
{
    /// <summary>
    /// Interaction logic for ProcessView.xaml
    /// </summary>
    public partial class ProcessView : UserControl
    {
        public ProcessView()
        {
            InitializeComponent();
            DataContext = new ProcessViewModel();
        }
    }
}
