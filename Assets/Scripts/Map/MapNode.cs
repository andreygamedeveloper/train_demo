using UnityEngine;

namespace Game.Map
{
    public class MapNode : MonoBehaviour
    {
        public MapNodeType Type;
        public float pointsMultiplier;
        public float timeMultiplier;
        public Vector3 Position => transform.position;
    }
}