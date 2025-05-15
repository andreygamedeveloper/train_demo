using System;
using R3;
using UnityEngine;
using Random = UnityEngine.Random;

public class TrainView : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private RouteView _routeView;
    
    private readonly CompositeDisposable _disposable = new();

    public IDisposable Init(TrainModel model)
    {
        var color = GetRandomColor();
        _renderer.material.color = color;
        
        model.Position
            .Subscribe(position => transform.position = position)
            .AddTo(_disposable);

        model.Route
            .Subscribe(route => _routeView.ShowPath(route))
            .AddTo(_disposable);

        _routeView
            .Init(color)
            .AddTo(_disposable);
        
        return _disposable;
    }

    private Color GetRandomColor()
    {
        var hue = Random.value;
        var saturation = 0.8f + 0.2f * Random.value;
        var value = 0.8f + 0.2f * Random.value;

        return Color.HSVToRGB(hue, saturation, value);
    }
}