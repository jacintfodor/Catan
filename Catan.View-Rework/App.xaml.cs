using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using Catan.Model;
using Catan.ViewModel;

namespace Catan.View_Rework
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
            _viewModel.BankConfirmRequested += _viewModel_BankConfirmRequested;
            _viewModel.WinnerRequested += _viewModel_WinnerRequested;

            _model.NewGame();

            _view = new MainWindow();
            _view.DataContext = _viewModel;

            _view.Show();
        }

        private void _viewModel_WinnerRequested(object? sender, EventArgs e)
        {
            MessageBox.Show("Congrats you, you won");
        }

        private void _viewModel_BankConfirmRequested(object? sender, BankConfirmEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(e.Message, "Catan", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                _model.ExchangeWithBank(e.From, e.To);
            }
        }
    }
}
