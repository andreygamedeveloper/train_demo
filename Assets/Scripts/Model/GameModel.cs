using System.Collections.Generic;
using R3;

namespace Game.Model
{
    public class GameModel
    {
        public ReadOnlyReactiveProperty<float> Points => _points;
        public readonly List<TrainModel> Trains;

        private readonly ReactiveProperty<float> _points = new();

        public GameModel(List<TrainModel> trains)
        {
            Trains = trains;
        }

        public void AddPoints(float points)
        {
            _points.Value += points;
        }
    }
}