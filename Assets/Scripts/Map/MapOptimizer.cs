using System.Collections.Generic;

namespace Game.Map
{
    public class MapOptimizer
    {
        private readonly MapPathfinder _pathfinder;
        private readonly MapGraph _graph;

        public MapOptimizer(MapPathfinder pathfinder, MapGraph graph)
        {
            _pathfinder = pathfinder;
            _graph = graph;
        }

        public List<MapNode> GetBestRoute(MapTrain trainData)
        {
            var bestEfficiency = 0f;
            var bestPath = null as List<MapNode>;

            foreach (var source in _graph.GetNodes(MapNodeType.Source))
            {
                foreach (var destination in _graph.GetNodes(MapNodeType.Destination))
                {
                    var route = _pathfinder.FindShortestPath(source, destination, out var distance);

                    var tMove = 2 * distance / trainData.movementSpeed;
                    var tMine = trainData.miningTime * source.timeMultiplier;

                    var totalTime = tMove + tMine;
                    var efficiency = destination.pointsMultiplier / totalTime;

                    if (efficiency > bestEfficiency)
                    {
                        bestEfficiency = efficiency;
                        bestPath = new List<MapNode>(route);
                    }
                }
            }

            return bestPath;
        }

        public MapNode GetRandomNode()
        {
            var nodes = _graph.GetNodes(MapNodeType.Point);
            var index = UnityEngine.Random.Range(0, nodes.Count);
            return nodes[index];
        }

        public List<MapNode> GetShortestPath(MapNode start, MapNode end)
        {
            return _pathfinder.FindShortestPath(start, end, out _);
        }

        public float GetDistance(MapNode start, MapNode end)
        {
            return _pathfinder.GetDistance(start, end);
        }
    }
}