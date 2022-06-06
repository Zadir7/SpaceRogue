using Abstracts;
using Gameplay.Player.Movement;
using Scriptables;
using Utilities.ResourceManagement;

namespace Gameplay.Player
{
    public class StarController : BaseController
    {
        private readonly ResourcePath _configPath = new("Configs/StarConfig");
        private readonly ResourcePath _viewPath = new("Prefabs/Star");
        
        private readonly StarConfig _config;
        private readonly StarView _view;

        private readonly StarMovementController _movementController;
        

        public StarController()
        {
            _config = ResourceLoader.LoadObject<StarConfig>(_configPath);
            _view = LoadView<StarView>(_viewPath);

            _movementController = AddInputController(_config.StarMovement, _view);
        }

        private StarMovementController AddInputController(StarMovementModel movementModel, StarView view)
        {
            var movementController = new StarMovementController(movementModel, view);
            AddController(movementController);
            return movementController;
        }
    }
}