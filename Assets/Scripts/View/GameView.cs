using System;
using R3;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    [SerializeField] private Text _pointsText;
    
    private readonly CompositeDisposable _disposable = new();

    public IDisposable Init(GameModel model)
    {
        model.Points
            .Subscribe(points => _pointsText.text = Mathf.RoundToInt(points).ToString())
            .AddTo(_disposable);
        
        return _disposable;
    }
}
