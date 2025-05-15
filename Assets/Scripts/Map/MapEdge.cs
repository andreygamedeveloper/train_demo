using System;

namespace Game.Map
{
    [Serializable]
    public class MapEdge
    {
        public MapNode From;
        public MapNode To;
        public float Distance;
    }
}