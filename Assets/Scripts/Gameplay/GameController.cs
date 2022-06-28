using Abstracts;
using Gameplay.Enemy;
using Gameplay.Camera;
using Gameplay.GameState;
using Gameplay.Player;
using Gameplay.Space;

namespace Gameplay
{
    public class GameController : BaseController
    {
        private readonly CurrentState _currentState;
        private readonly PlayerController _playerController;
        private readonly SpaceController _spaceController;
        private readonly EnemySpawnController _enemySpawnController;
        private readonly CameraController _cameraController;
        private readonly HealtShieldToolBarController _healtShieldToolBarController;

        public GameController(CurrentState currentState)
        {
            _currentState = currentState;
            
            _playerController = new PlayerController();
            AddController(_playerController);

            _cameraController = new CameraController(_playerController.View);
            AddController(_cameraController);

            _healtShieldToolBarController = new HealtShieldToolBarController();
            AddController(_healtShieldToolBarController);

            _spaceController = new SpaceController();
            AddController(_spaceController);

            _enemySpawnController = new EnemySpawnController();
            AddController(_enemySpawnController);
        }
    }
}