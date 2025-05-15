using System;
using Game.Model;
using R3;
using UnityEngine;

namespace Game.View
{
    public class SceneView : MonoBehaviour
    {
        [SerializeField] private TrainView _trainPrefab;
        [SerializeField] private Transform _trainAnchor;

        private readonly CompositeDisposable _disposable = new();

        public IDisposable Init(GameModel gameModel)
        {
            foreach (var trainModel in gameModel.Trains)
            {
                var trainInstance = GameObject.Instantiate(_trainPrefab, _trainAnchor);

                trainInstance
                    .Init(trainModel)
                    .AddTo(_disposable);

                Disposable
                    .Create(() => GameObject.Destroy(trainInstance.gameObject))
                    .AddTo(_disposable);
            }

            return _disposable;
        }
    }
}