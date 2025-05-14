using System;
using R3;

public class GameController
{
    private readonly CompositeDisposable _disposable = new();
    private readonly GameModel _gameModel;

    public GameController(GameModel gameModel)
    {
        _gameModel = gameModel;
    }

    public IDisposable Init()
    {
        foreach (var trainModel in _gameModel.Trains)
        {
            var trainController = new TrainController(trainModel);

            trainController
                .Init()
                .AddTo(_disposable);
        }

        return _disposable;
    }
}
