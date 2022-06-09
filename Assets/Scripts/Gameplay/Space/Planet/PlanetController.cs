using Abstracts;
using Gameplay.Planet.Movement;
using Scriptables;
using UnityEngine;
using Utilities.Reactive.SubscriptionProperty;
using Utilities.ResourceManagement;

namespace Gameplay.Planet
{
    public class PlanetController : BaseController
    {
        private readonly ResourcePath _configPath = new("Configs/PlanetConfig");
        private readonly ResourcePath _viewPath = new("Prefabs/Gameplay/Planet");
        
        private readonly PlanetConfig _config;
        private readonly PlanetView _view;

        private readonly SubscribedProperty<Vector3> _positionPlanet = new SubscribedProperty<Vector3>();

        private readonly PlanetMovementController _movementController;
        

        public PlanetController()
        {
            _config = ResourceLoader.LoadObject<PlanetConfig>(_configPath);
            _view = LoadView<PlanetView>(_viewPath, new Vector3(10, 10, 0));

            _movementController = AddPlanetController(_config.PlanetMovement, _view);
        }

        private PlanetMovementController AddPlanetController(PlanetMovementConfig movementConfig, PlanetView view)
        {
            var movementController = new PlanetMovementController(_positionPlanet, movementConfig, view);
            AddGameObject(view.gameObject);
            return movementController;
        }
    }
}