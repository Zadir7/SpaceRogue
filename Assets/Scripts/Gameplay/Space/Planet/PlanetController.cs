using Abstracts;
using Gameplay.Player.Movement;
using Scriptables;
using UnityEngine;
using Utilities.Reactive.SubscriptionProperty;
using Utilities.ResourceManagement;

namespace Gameplay.Player
{
    public class PlanetController : BaseController
    {
        private readonly ResourcePath _configPath = new("Configs/PlanetConfig");
        private readonly ResourcePath _viewPath = new("Prefabs/Planet");
        
        private readonly PlanetConfig _config;
        private readonly PlanetView _view;

        private readonly PlanetMovementController _movementController;
        

        public PlanetController()
        {
            _config = ResourceLoader.LoadObject<PlanetConfig>(_configPath);
            _view = LoadView<PlanetView>(_viewPath);

            _movementController = AddInputController(_config.PlanetMovement, _view);
        }

        private PlanetMovementController AddInputController(PlanetMovementModel movementModel, PlanetView view)
        {
            var movementController = new PlanetMovementController(movementModel, view);
            AddController(movementController);
            return movementController;
        }
    }
}