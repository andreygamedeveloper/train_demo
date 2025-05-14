using System;
using R3;
using UnityEngine;

public class TrainView : MonoBehaviour
{
    private readonly CompositeDisposable _disposable = new();

    public IDisposable Init(TrainModel model)
    {
        model.Position
            .Subscribe(position => transform.localPosition = new Vector3(position.x, 0.0f, position.y))
            .AddTo(_disposable);
        
        return _disposable;
    }
}
