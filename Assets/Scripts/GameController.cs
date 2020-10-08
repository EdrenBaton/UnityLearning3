using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform _playerStarPoint;
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private BonusData _bonusData;
    private CameraMoveController _cameraMoveController;
    private ExecutableCollection _executable;

    private InteractableObjectCollection _interactables;
    private MoveController _moveController;
    private PlayerBase _player;
    private ScoreController _scoreController;

    private void Awake()
    {
        var resourceManager = new ResourcesManager();

        _player = resourceManager.Player;
        _player.transform.position = _playerStarPoint.position;

        _interactables = new InteractableObjectCollection(_bonusData);
        _executable = new ExecutableCollection(
            new List<IExecutable>
            {
                new MoveController(_player),
                new CameraMoveController(_player, resourceManager.MainCamera)
            },
            _interactables.GetExecutableCollection()
        );

        _scoreController = new ScoreController(new UiTextScoreViewer());

        FindObjectsOfType<BaseGameObject>().ToList().ForEach(o => o.Initialize());

        //_executable.AddOnDestroySubscribers(new Action<InteractableObject> [] {_scoreController.UpdateScore});
    }

    private void Update()
    {
        // Тут пока что обманул сам себя, перемудрил с коллекцией
        _executable.ExecuteAll();
    }
}