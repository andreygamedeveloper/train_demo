using System.Collections.Generic;

namespace Game.Map
{
    public interface IPathfinder
    {
        List<MapNode> FindShortestPath(MapNode start, MapNode end, out float distance);
        float GetDistance(MapNode start, MapNode end);
    }
}