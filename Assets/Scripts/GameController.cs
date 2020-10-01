using System;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private InteractableObjectsCollection _interactableObjects;
    private CameraMoveController _cameraMoveController;
    private ScoreController _scoreController;
    private MoveController _moveController;
    private PlayerBase _player;

    private void Awake()
    {
        var resourceManager = new ResourcesManager();
        
        _interactableObjects = new InteractableObjectsCollection();
        _scoreController = new ScoreController(new UiTextScoreViewer());
        _player = resourceManager.Player;
        _moveController = new MoveController(_player);
        _cameraMoveController = new CameraMoveController(_player, resourceManager.MainCamera);
        
        FindObjectsOfType<BaseGameObject>().ToList().ForEach(o => o.Initialize());
        
        _interactableObjects.AddOnDestroySubscribers(new Action<InteractableObject> [] {_scoreController.UpdateScore});
    }

    private void Update()
    {
        // Тут пока что обманул сам себя, перемудрил с коллекцией
        _interactableObjects.ExecuteAll();

        _cameraMoveController.Execute();
        _moveController.Execute();
    }
}