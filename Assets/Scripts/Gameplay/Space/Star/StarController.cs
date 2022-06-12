using Abstracts;
using Gameplay.Space.Star;
using Scriptables;
using Utilities.ResourceManagement;
using UnityEngine;
using Gameplay.Planet;

namespace Gameplay.Space.Star
{
    public class StarController : BaseController
    {
        private readonly ResourcePath _configPath = new("Configs/StarConfig");
        private readonly ResourcePath _viewPath = new("Prefabs/GamePlay/Star");
        
        private readonly StarConfig _config;
        private readonly StarView[] _allViews;
        private readonly StarView _view;

        //private readonly StarMovementController _movementController;


        public StarController()
        {
            _config = ResourceLoader.LoadObject<StarConfig>(_configPath);
            _view = LoadView<StarView>(_viewPath);

            AddPlanetInSpace(_config, _view);
        }

        
        private void AddPlanetInSpace(StarConfig config, StarView view)
        {
            System.Random random = new System.Random();
            for (int i = 0; i < random.Next(config.starFullConfigs.MinPlanetOnOrbit, config.starFullConfigs.MaxPlanetOnOrbit); i++)
            {
                var planetConntroller = new PlanetController(config, view);
                AddController(planetConntroller);
            }
            //return movementController;
        }
    }
}