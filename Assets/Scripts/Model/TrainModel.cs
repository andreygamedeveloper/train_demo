using System.Collections.Generic;
using Game.Map;
using R3;
using UnityEngine;

namespace Game.Model
{
    public class TrainModel
    {
        public readonly MapTrain Content;
        public ReadOnlyReactiveProperty<Vector3> Position => _position;
        private readonly ReactiveProperty<Vector3> _position = new();
        
        public ReadOnlyReactiveProperty<Vector3> Direction => _direction;
        private readonly ReactiveProperty<Vector3> _direction = new();

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
        
        public void SetDirection(Vector3 direction)
        {
            _direction.Value = direction;
        }

        public void SetRoute(List<MapNode> route)
        {
            _route.Value = route;
        }
    }
}