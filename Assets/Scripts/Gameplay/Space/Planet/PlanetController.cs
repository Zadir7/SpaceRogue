using Abstracts;
using Configs.StarsConfigs;
using Gameplay.Planet.Movement;
using Scriptables;
using System.Collections.Generic;
using UnityEngine;
using Utilities.ResourceManagement;

namespace Gameplay.Planet
{
    public class PlanetController : BaseController
    {
        private readonly ResourcePath _allPlanetPath = new ResourcePath("Configs/ChanseConfigs/ChanseSelectPlanet");
        private readonly ResourcePath _configPath = new("Configs/PlanetsConfigs/");
        private readonly ResourcePath _viewPath = new("Prefabs/VariantPlanet/");
        
        private readonly PlanetConfig _config = new PlanetConfig();
        private readonly GameObject[] _allView;
        private readonly PlanetView _view = new PlanetView();

        private readonly StarConfig _starConfig;
        private readonly StarView _starView;

        private readonly PlanetMovementController _movementController;
        private readonly List<ChanseSelectObjectConfig> allPlanetChanse;

        public PlanetController(StarConfig starConfig, StarView starView)
        {
            _starConfig = starConfig;
            _starView = starView;
            System.Random random = new System.Random();

            allPlanetChanse = ResourceLoader.LoadObject<ChanseSelectedObject>(_allPlanetPath).ChanseSelectobjects;
            
            var select = PlanetGenerateModel.RandomSelectPlanet(allPlanetChanse);

            _config = ResourceLoader.LoadObject<PlanetConfig>(new ResourcePath($"{_configPath.PathToResource.ToString()}{allPlanetChanse[select].NameObject.ToString()}"));
            PlanetConfig planetConfig = new PlanetConfig();
            planetConfig.PlanetMovement = _config.PlanetMovement;
            _view = LoadView<PlanetView>(new ResourcePath($"{_viewPath.PathToResource.ToString()}{allPlanetChanse[select].NameObject.ToString()}"));

            planetConfig.PlanetMovement.PositionStar = starView.gameObject.transform.position;

            PlanetGenerateModel generateModel = new PlanetGenerateModel(planetConfig, _view);
            (planetConfig, _view) = generateModel.CustomPlanetConfig();

            _movementController = AddPlanetController(planetConfig.PlanetMovement, _view);
        }

        private PlanetMovementController AddPlanetController(PlanetMovementConfig movementConfig, PlanetView view)
        {
            var movementController = new PlanetMovementController(movementConfig, view);
            AddController(movementController);
            return movementController;
        }
    }
}