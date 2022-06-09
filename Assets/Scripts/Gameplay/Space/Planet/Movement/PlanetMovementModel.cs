using UnityEngine;


namespace Gameplay.Planet.Movement
{
    public class PlanetMovementModel
    {
        private readonly PlanetMovementConfig _config;

        public float Speed { get; private set; }
        public float Side { get; private set; }
        
        public PlanetMovementModel(PlanetMovementConfig config)
        {
            _config = config;
            Speed = 1f;
            Side = 0.0f;
        }

        public void MovePlanet(PlanetMovementModel planet)
        {
            bool trueStar = false;
            Collider[] colliders = Physics.OverlapSphere(planet._config.PositionStar, 0);
            foreach (var centrStar in colliders)
            {
                trueStar = centrStar.tag == "Star" ? true : false;
            }
            if (!trueStar)
            {
                SearchFirstObject searchFirstObject = new SearchFirstObject();
                planet._config.PositionStar = searchFirstObject.SearchFirstObjectOnTag(_config.PositionPlanet, "Star");
            }
            planet._config.Speed = 1f;
            planet._config.Orbita = 1f;
            planet._config.PositionPlanet = new Vector3(
                                                (planet._config.PositionPlanet.x + planet._config.Orbita * Mathf.Cos(Mathf.PI * Time.unscaledTime * planet._config.Speed)),
                                                (planet._config.PositionPlanet.y + planet._config.Orbita * Mathf.Sin(Mathf.PI * Time.unscaledTime * planet._config.Speed)), 0);

        }

    }
}