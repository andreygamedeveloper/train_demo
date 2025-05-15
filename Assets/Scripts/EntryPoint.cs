using System.Linq;
using R3;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private MapGraph _mapGraph;
    [SerializeField] private GameView _gameView;
    [SerializeField] private SceneView _sceneView;

    private readonly CompositeDisposable _rootDisposable = new();
    
    private void Awake()
    {
        var gameModel = CreateGameModel();
        var mapPathfinder = new MapPathfinder(_mapGraph);
        var mapOptimizer = new MapOptimizer(mapPathfinder, _mapGraph);
        var controller = new GameController(gameModel, mapOptimizer);

        _gameView
            .Init(gameModel)
            .AddTo(_rootDisposable);
        
        _sceneView
            .Init(gameModel)
            .AddTo(_rootDisposable);
        
        controller
            .Init()
            .AddTo(_rootDisposable);
    }

    private GameModel CreateGameModel()
    {
        var trains = _mapGraph.Trains
            .Select(train => new TrainModel(train))
            .ToList();

        return new GameModel(trains);
    }

    private void OnDestroy()
    {
        _rootDisposable.Clear();
    }
}
