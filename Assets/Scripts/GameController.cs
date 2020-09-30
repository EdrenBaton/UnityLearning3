using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private List<InteractableObject> _interactableObjects;
    private MoveController _playerMoveController;
    private CameraMoveController _cameraMoveController;
    private ScoreController _scoreController;

    private void Awake()
    {
        _scoreController = new ScoreController(new UiTextScoreViewer());
        
        FindObjectsOfType<MyGameObject>().ToList().ForEach(o => o.Initialize());

        _interactableObjects = FindObjectsOfType<InteractableObject>().ToList();
        foreach (var interactableObject in _interactableObjects)
        {
            interactableObject.AddSubscriber(DeleteObjectFromCollection);
            interactableObject.AddSubscriber(_scoreController.UpdateScore);
        }

        _playerMoveController = FindObjectOfType<MoveController>();
        _cameraMoveController = FindObjectOfType<CameraMoveController>();
    }

    private void Update()
    {
        foreach (var interactableObject in _interactableObjects) interactableObject.Act();

        _playerMoveController.Move();
    }

    private void LateUpdate()
    {
        _cameraMoveController.SetPosition();
    }

    private void DeleteObjectFromCollection(InteractableObject interactableObject)
    {
        interactableObject.RemoveSubscriber(DeleteObjectFromCollection);
        _interactableObjects.Remove(interactableObject);
    }
}