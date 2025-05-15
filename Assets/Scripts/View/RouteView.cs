using System;
using System.Collections.Generic;
using Game.Map;
using R3;
using UnityEngine;

namespace Game.View
{
    public class RouteView : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineRenderer;

        public IDisposable Init(Color color)
        {
            _lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
            _lineRenderer.widthMultiplier = 0.5f;
            _lineRenderer.positionCount = 0;
            _lineRenderer.startColor = color;
            _lineRenderer.endColor = color;
            _lineRenderer.useWorldSpace = true;

            return Disposable.Create(() => _lineRenderer.positionCount = 0);
        }

        public void ShowPath(List<MapNode> path)
        {
            if (path == null || path.Count == 0)
            {
                _lineRenderer.positionCount = 0;
                return;
            }

            _lineRenderer.positionCount = path.Count;

            for (var i = 0; i < path.Count; i++)
            {
                _lineRenderer.SetPosition(i, path[i].Position);
            }
        }
    }
}