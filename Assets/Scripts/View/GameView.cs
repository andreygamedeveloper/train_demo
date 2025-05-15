using System;
using Game.Model;
using R3;
using UnityEngine;
using UnityEngine.UI;

namespace Game.View
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private Text _pointsText;

        private readonly CompositeDisposable _disposable = new();

        public IDisposable Init(GameModel model)
        {
            model.Points
                .Subscribe(points =>
                {
                    var roundPoints = Mathf.RoundToInt(points);
                    _pointsText.text = $"Points: {roundPoints}";
                })
                .AddTo(_disposable);

            return _disposable;
        }
    }
}