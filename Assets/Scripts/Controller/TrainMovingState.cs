using System;
using System.Collections.Generic;
using System.Linq;
using Game.Map;
using R3;

namespace Game.Controller
{
    public class TrainMovingState : ITrainState
    {
        private readonly List<MapNode> _route;

        public TrainMovingState(List<MapNode> route)
        {
            _route = route;
        }

        public IDisposable Init(TrainMachine machine)
        {
            machine.TrainModel.SetRoute(_route);

            var chain = Observable.ReturnUnit();

            for (var index = 0; index < _route.Count - 1; index++)
            {
                var start = _route[index];
                var end = _route[index + 1];

                chain = chain
                    .SelectMany(_ => machine.TrainController
                        .Move(start, end));
            }

            return chain
                .Subscribe(_ =>
                {
                    var target = _route.Last();
                    var state = target.Type == MapNodeType.Source
                        ? new TrainMiningState(target) as ITrainState
                        : new TrainDestinationState(target);

                    machine.ChangeState(state);
                });
        }
    }
}