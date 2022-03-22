using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Catan.ViewModel;
using Catan.Model;

namespace Catan.View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private CatanGameModel _model;
        private CatanViewModel _viewModel;
        private MainWindow _view;

        public App()
        {
            Startup += new StartupEventHandler(App_Startup);
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            // TODO modell creation

            _model = new();
            _viewModel = new(_model);
            _model.NewGame();

            _view = new MainWindow(_viewModel);
            _view.DataContext = _viewModel;
            _view.Show();
        }
    }
}
