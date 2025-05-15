using System;
using System.Linq;
using R3;

public class TrainDestinationState : ITrainState
{
    private readonly MapNode _node;

    public TrainDestinationState(MapNode node)
    {
        _node = node;
    }
    
    public IDisposable Init(TrainMachine machine)
    {
        machine.GameModel.AddPoints(_node.pointsMultiplier);
        
        return Observable
            .TimerFrame(1)
            .Subscribe(_ =>
            {
                var route = machine.MapOptimizer.GetBestRoute(machine.TrainModel);
                route.Reverse();
                if (route.First() != _node)
                    route = machine.MapOptimizer.GetShortestPath(_node, route.First());
                machine.ChangeState(new TrainMovingState(route));
            });
    }
}
