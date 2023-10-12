using ModuleListy.ViewModels;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace ModuleListy.Views
{
    /// <summary>
    /// Interaction logic for ModuleListView.xaml
    /// </summary>
    public partial class ListView : UserControl
    {
        public ListView(ListViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
