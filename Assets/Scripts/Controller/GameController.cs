using System;
using Game.Map;
using Game.Model;
using R3;

namespace Game.Controller
{
    public class GameController
    {
        private readonly CompositeDisposable _disposable = new();
        private readonly GameModel _gameModel;
        private readonly MapOptimizer _mapOptimizer;

        public GameController(GameModel gameModel, MapOptimizer mapOptimizer)
        {
            _gameModel = gameModel;
            _mapOptimizer = mapOptimizer;
        }

        public IDisposable Init()
        {
            foreach (var trainModel in _gameModel.Trains)
            {
                var trainController = new TrainController(_gameModel, trainModel, _mapOptimizer);

                trainController
                    .Init()
                    .AddTo(_disposable);
            }

            return _disposable;
        }
    }
}
