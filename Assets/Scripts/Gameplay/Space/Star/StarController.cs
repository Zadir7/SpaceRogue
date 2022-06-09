using Abstracts;
using Gameplay.Space.Star;
using Gameplay.Space.Star.Movement;
using Scriptables;
using Utilities.ResourceManagement;
using UnityEngine;

namespace Gameplay.Space.Star
{
    public class StarController : BaseController
    {
        private readonly ResourcePath _configPath = new("Configs/StarConfig");
        private readonly ResourcePath _viewPath = new("Prefabs/GamePlay/Star");
        
        private readonly StarConfig _config;
        private readonly StarView _view;

        private readonly StarMovementController _movementController;
        

        public StarController()
        {
            _config = ResourceLoader.LoadObject<StarConfig>(_configPath);
            _view = LoadView<StarView>(_viewPath, new Vector3 (25, 25, 0));

            //_movementController = AddInputController(_config.StarMovement, _view);
        }

        private StarMovementController AddInputController(StarMovementModel movementModel, StarView view)
        {
            var movementController = new StarMovementController(movementModel, view);
            AddController(movementController);
            return movementController;
        }
    }
}