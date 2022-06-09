using Abstracts;
using UnityEngine;
using Utilities.Reactive.SubscriptionProperty;

namespace Gameplay.Planet.Movement
{
    public class PlanetMovementController : BaseController
    {
        private readonly SubscribedProperty<Vector3> _positionPlanet;

        private readonly PlanetMovementModel _movementModel;
        private readonly PlanetView _view;

        public PlanetMovementController(
            SubscribedProperty<Vector3> positionPlanet,
            PlanetMovementConfig movementModel,
            PlanetView view)
        {
            _positionPlanet = positionPlanet;
            _movementModel  = new PlanetMovementModel(movementModel);
            _view = view;

            _positionPlanet.Subscribe(MovePlanet);
        }

        public void MovePlanet(Vector3 planetPosition)
        {
            PlanetMovementModel newMovementModel = _movementModel;
            newMovementModel.MovePlanet(_movementModel);

        }
    }
}