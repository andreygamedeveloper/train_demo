using System;
using R3;
using UnityEngine;

public class TrainController
{
    private readonly CompositeDisposable _disposable = new();
    private readonly TrainModel _trainModel;

    public TrainController(TrainModel trainModel)
    {
        _trainModel = trainModel;
    }

    public IDisposable Init()
    {
        var position = GetRandomPosition();
        _trainModel.SetPosition(position);
        
        return _disposable;
    }

    private Vector2 GetRandomPosition()
    {
        throw new NotImplementedException();
    }
}
