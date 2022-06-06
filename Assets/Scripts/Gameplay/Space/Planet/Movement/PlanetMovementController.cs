using Abstracts;
using UnityEngine;

namespace Gameplay.Player.Movement
{
    public class PlanetMovementController : BaseController
    {
        private readonly PlanetMovementModel _movementModel;
        private readonly PlanetView _view;

        public PlanetMovementController(
            PlanetMovementModel movementModel,
            PlanetView view)
        {
            _movementModel = movementModel;
            _view = view;
        }

        public Vector3 MovePlanet(GameObject planet, float orbita, float speedPlanet, int sideMove)
        {
            return planet.transform.position = new Vector3(
                                                (planet.transform.position.x + sideMove * orbita * Mathf.Cos(Mathf.PI * Time.unscaledTime * speedPlanet)),
                                                (planet.transform.position.y + orbita * Mathf.Sin(Mathf.PI * Time.unscaledTime * speedPlanet)), 0);

        }
    }
}