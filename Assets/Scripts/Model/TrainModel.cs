using System.Collections.Generic;
using R3;
using UnityEngine;

public class TrainModel
{
    public readonly MapTrain Content;
    public ReadOnlyReactiveProperty<Vector3> Position => _position;
    private readonly ReactiveProperty<Vector3> _position = new();
    
    public ReadOnlyReactiveProperty<List<MapNode>> Route => _route;
    private readonly ReactiveProperty<List<MapNode>> _route = new();

    public TrainModel(MapTrain content)
    {
        Content = content;
    }

    public void SetPosition(Vector3 position)
    {
        _position.Value = position;
    }
    
    public void SetRoute(List<MapNode> route)
    {
        _route.Value = route;
    }
}