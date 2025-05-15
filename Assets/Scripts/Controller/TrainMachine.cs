using System;

public class TrainMachine : IDisposable
{
    public readonly GameModel GameModel;
    public readonly TrainController TrainController;
    public readonly TrainModel TrainModel;
    public readonly MapOptimizer MapOptimizer;

    private IDisposable _stateDisposable;

    public TrainMachine(GameModel gameModel, TrainController trainController, TrainModel trainModel, MapOptimizer mapOptimizer)
    {
        GameModel = gameModel;
        TrainController = trainController;
        TrainModel = trainModel;
        MapOptimizer = mapOptimizer;
    }

    public void ChangeState(ITrainState state)
    {
        _stateDisposable?.Dispose();
        _stateDisposable = state.Init(this);
    }

    public void Dispose()
    {
        _stateDisposable?.Dispose();
    }
}
