using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Map
{
    public class MapGraph : MonoBehaviour
    {
        public List<MapTrain> Trains;
        public List<MapNode> Nodes;
        public List<MapEdge> Edges;
        public List<MapNode> GetNodes(MapNodeType type) => Nodes.Where(n => n.Type == type).ToList();
    }
}