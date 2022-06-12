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

        private readonly StarConfig _starConfig;
        private readonly StarView _starView;

        private readonly SubscribedProperty<Vector3> _positionPlanet = new SubscribedProperty<Vector3>();

        private readonly PlanetMovementController _movementController;
        

        public PlanetController(StarConfig starConfig, StarView starView)
        {
            System.Random random = new System.Random();
            float orbitPlanet = random.Next(_config.PlanetMovement.MinOrbit * 100, _config.PlanetMovement.MaxOrbit * 100);
            _config.PlanetMovement.PositionPlanet.x = random.Next(_config.PlanetMovement.MinOrbit * 100, (int)orbitPlanet) / 100;
            orbitPlanet = orbitPlanet / 100;

            _config = ResourceLoader.LoadObject<PlanetConfig>(_configPath);
            _view = LoadView<PlanetView>(_viewPath, new Vector3(    _config.PlanetMovement.PositionPlanet.x,
                                                                    (float)System.Math.Sqrt(orbitPlanet * orbitPlanet - _config.PlanetMovement.PositionPlanet.x * _config.PlanetMovement.PositionPlanet.x),
                                                                    0));

            _starConfig = starConfig;
            _starView = starView;

            _movementController = AddPlanetController(_config.PlanetMovement, _view);
        }

        private PlanetMovementController AddPlanetController(PlanetMovementConfig movementConfig, PlanetView view)
        {
            var movementController = new PlanetMovementController(_positionPlanet, movementConfig, view);
            AddController(movementController);
            return movementController;
        }
    }
}