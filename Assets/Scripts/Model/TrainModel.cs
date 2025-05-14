using R3;
using UnityEngine;

public class TrainModel
{
    public readonly TrainContent Content;
    public ReadOnlyReactiveProperty<Vector2> Position => _position;
    private readonly ReactiveProperty<Vector2> _position = new();

    public TrainModel(TrainContent content)
    {
        Content = content;
    }

    public void SetPosition(Vector2 position)
    {
        _position.Value = position;
    }
}