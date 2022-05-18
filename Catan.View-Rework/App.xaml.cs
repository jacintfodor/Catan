using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

using Catan.Model;
using Catan.Model.Enums;
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
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Startup += new StartupEventHandler(App_Startup);
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            // TODO modell creation

            _model = new();
            _viewModel = new(_model);
            _viewModel.BankConfirmRequested += _viewModel_BankConfirmRequested;
            _viewModel.WinnerRequested += _viewModel_WinnerRequested;
            _viewModel.ScoreCardEarned += _viewModel_ScoreCardEarned;
            _viewModel.KnightCardEarned += _viewModel_KnightCardEarned;
            _viewModel.LongestRoadTitleEarned += _viewModel_LongestRoadTitleEarned;
            _viewModel.LargestArmyTitleEarned += _viewModel_LargestArmyTitleEarned;
            _viewModel.NewGameRequested += _viewModel_NewGameRequested;

            _model.NewGame();

            _view = new MainWindow();
            _view.DataContext = _viewModel;

            _view.Show();
        }

        private void _viewModel_NewGameRequested(object? sender, EventArgs e)
        {
            var dialog = MessageBox.Show("Creating a new game will make you lose any progress. Are you sure", "Catan: new game", MessageBoxButton.YesNo);
            if (dialog == MessageBoxResult.Yes)
            {
                _viewModel.ConfirmNewGame();
                _model.NewGame();
            }
        }

        private void _viewModel_LargestArmyTitleEarned(object? sender, EventArgs e)
        {
            MessageBox.Show("Congrats, you command the largest army in the contintent of Catan");
        }

        private void _viewModel_LongestRoadTitleEarned(object? sender, EventArgs e)
        {
            MessageBox.Show("Congrats, you own the longest road in the game");
        }

        private void _viewModel_KnightCardEarned(object? sender, EventArgs e)
        {
            MessageBox.Show("Congrats, you managed to grow your army by one");
        }

        private void _viewModel_ScoreCardEarned(object? sender, EventArgs e)
        {
            MessageBox.Show("Congrats, you earned 1 score card which increased your score by one");
        }

        private void _viewModel_WinnerRequested(object? sender, EventArgs e)
        {
            MessageBox.Show("Congrats, you won");
        }

        private void _viewModel_BankConfirmRequested(object? sender, BankConfirmEventArgs e)
        {
            var bankDialog = new BankDialog(e.From);
            bankDialog.ShowDialog();
            ResourceEnum to = bankDialog.Result;
            if (to != ResourceEnum.Desert)
            {
                _model.ExchangeWithBank(e.From, to);
            }
        }
    }
}
