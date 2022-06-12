using Abstracts;
using Gameplay.GameState;
using Gameplay.Player;
using Gameplay.Space;
using Gameplay.Planet;
using Gameplay.Space.Star;

namespace Gameplay
{
    public class GameController : BaseController
    {
        private readonly CurrentState _currentState;
        private readonly PlayerController _playerController;
        private readonly SpaceController _spaceController;
        private readonly PlanetController _planetConntroller;
        private readonly StarController _starConntroller;

        public GameController(CurrentState currentState)
        {
            _currentState = currentState;
            
            _playerController = new PlayerController();
            AddController(_playerController);

            _spaceController = new SpaceController();
            AddController(_spaceController);
            
            _starConntroller = new StarController();
        }
    }
}