using System.Collections.Generic;
using UnityEngine;

public class SceneContent : MonoBehaviour
{
    [SerializeField] private List<SourceContent> _sources;
    [SerializeField] private List<DestinationContent> _destinations;
    [SerializeField] private List<TrainContent> _trains;

    public IReadOnlyList<SourceContent> Sources => _sources;
    public IReadOnlyList<DestinationContent> Destinations => _destinations;
    public IReadOnlyList<TrainContent> Trains => _trains;
}