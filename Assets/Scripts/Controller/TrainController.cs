using System;
using System.Linq;
using Game.Map;
using Game.Model;
using R3;
using UnityEngine;

namespace Game.Controller
{
    public class TrainController
    {
        private readonly CompositeDisposable _disposable = new();
        private readonly GameModel _gameModel;
        private readonly TrainModel _trainModel;
        private readonly MapOptimizer _mapOptimizer;

        public TrainController(GameModel gameModel, TrainModel trainModel, MapOptimizer mapOptimizer)
        {
            _gameModel = gameModel;
            _trainModel = trainModel;
            _mapOptimizer = mapOptimizer;
        }

        public IDisposable Init()
        {
            var randomNode = _mapOptimizer.GetRandomNode();
            var bestRoute = _mapOptimizer.GetBestRoute(_trainModel.Content);
            var startRoute = _mapOptimizer.GetShortestPath(randomNode, bestRoute.First());

            var trainMachine = new TrainMachine(_gameModel, this, _trainModel, _mapOptimizer);
            trainMachine.AddTo(_disposable);

            trainMachine.ChangeState(new TrainMovingState(startRoute));

            return _disposable;
        }

        public Observable<Unit> Move(MapNode start, MapNode end)
        {
            return Observable.Create<Unit>(subject =>
            {
                var startPosition = start.Position;
                var endPosition = end.Position;
                var distance = _mapOptimizer.GetDistance(start, end);
                var totalTime = distance / _trainModel.Content.movementSpeed;
                var currentTime = 0.0f;

                var direction = endPosition - startPosition;
                _trainModel.SetDirection(direction.normalized);

                return Observable
                    .EveryUpdate()
                    .Subscribe(_ =>
                    {
                        currentTime += Time.deltaTime;
                        var ratio = Mathf.Clamp01(currentTime / totalTime);
                        var position = Vector3.Lerp(startPosition, endPosition, ratio);
                        _trainModel.SetPosition(position);

                        if (ratio >= 1.0f)
                        {
                            subject.OnNext(Unit.Default);
                            subject.OnCompleted();
                        }
                    });
            });
        }
    }
}