using System.Collections.Generic;
using System.Linq;

namespace Game.Map
{
    public class MapPathfinder
    {
        private readonly MapGraph _graph;

        public MapPathfinder(MapGraph graph)
        {
            _graph = graph;
        }

        public List<MapNode> FindShortestPath(MapNode start, MapNode end, out float totalDistance)
        {
            var path = new List<MapNode>();
            var distances = new Dictionary<MapNode, float>();
            var previous = new Dictionary<MapNode, MapNode>();
            var unvisited = new HashSet<MapNode>(_graph.Nodes);

            foreach (var node in _graph.Nodes)
            {
                distances[node] = float.PositiveInfinity;
            }

            distances[start] = 0f;

            while (unvisited.Count > 0)
            {
                var current = unvisited.OrderBy(n => distances[n]).First();

                if (current == end)
                    break;

                unvisited.Remove(current);

                foreach (var neighbor in GetNeighbors(current))
                {
                    if (!unvisited.Contains(neighbor)) continue;

                    var edgeDistance = GetDistance(current, neighbor);
                    var tentative = distances[current] + edgeDistance;

                    if (tentative < distances[neighbor])
                    {
                        distances[neighbor] = tentative;
                        previous[neighbor] = current;
                    }
                }
            }

            var currentNode = end;

            if (!previous.ContainsKey(end) && start != end)
            {
                totalDistance = float.PositiveInfinity;
                return new List<MapNode>();
            }

            while (currentNode != null)
            {
                path.Insert(0, currentNode);
                previous.TryGetValue(currentNode, out currentNode);
            }

            totalDistance = distances[end];
            return path;
        }

        public float GetDistance(MapNode a, MapNode b)
        {
            var edge = _graph.Edges.FirstOrDefault(e => (e.From == a && e.To == b) || (e.From == b && e.To == a));
            return edge?.Distance ?? float.PositiveInfinity;
        }

        private List<MapNode> GetNeighbors(MapNode node)
        {
            return _graph.Edges
                .Where(e => e.From == node)
                .Select(e => e.To)
                .Concat(_graph.Edges.Where(e => e.To == node).Select(e => e.From))
                .Distinct()
                .ToList();
        }
    }
}