using System;
using System.Collections.Generic;
using System.Linq;
using R3;

public class TrainMiningState : ITrainState
{
    private readonly MapNode _node;

    public TrainMiningState(MapNode node)
    {
        _node = node;
    }
    
    public IDisposable Init(TrainMachine machine)
    {
        var miningTime = machine.TrainModel.Content.miningTime * _node.timeMultiplier;
        
        return Observable
            .Timer(TimeSpan.FromSeconds(miningTime))
            .Subscribe(_ =>
            {
                var route = machine.MapOptimizer.GetBestRoute(machine.TrainModel);
                if (route.First() != _node)
                    route = machine.MapOptimizer.GetShortestPath(_node, route.First());
                machine.ChangeState(new TrainMovingState(route));
            });
    }
}
