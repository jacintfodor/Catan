using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Catan.Model;
using Catan.Model.Events;

namespace Catan.ViewModel
{
    public class CatanViewModel : ViewModelBase
    {
        private CatanGameModel _model;
        
        int _firstDiceValue = 1;
        int _secondDiceValue = 1;
        public int FirstDiceFace { get => _firstDiceValue; set { _firstDiceValue = value; OnPropertyChanged(); OnPropertyChanged(nameof(SumOfDices)); } }
        public int SecondDiceFace { get => _secondDiceValue; set { _secondDiceValue = value; OnPropertyChanged(); OnPropertyChanged(nameof(SumOfDices)); } }
        public int SumOfDices { get => FirstDiceFace + SecondDiceFace; }


        public DelegateCommand ThrowDicesCommand { get; private set; }

        

        public CatanViewModel(CatanGameModel model)
        {
            _model = model;
            _model.DicesThrown += Model_DicesThrown;
            _model.GameStart += Model_NewGame;
            ThrowDicesCommand = new DelegateCommand(_ => _model.ThrowDices());

        }

        private void Model_NewGame(object? sender, GameStartEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Model_DicesThrown(object? sender, Model.Events.DicesThrownEventArg e)
        {
            FirstDiceFace = e.FirstDice;
            SecondDiceFace = e.SecondDice;
        }
    }
}
