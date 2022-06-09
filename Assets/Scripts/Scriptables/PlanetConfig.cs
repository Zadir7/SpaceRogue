using UnityEngine;

namespace Scriptables
{
    [CreateAssetMenu(fileName = nameof(PlanetConfig), menuName = "Configs/" + nameof(PlanetConfig))]
    public class PlanetConfig : ScriptableObject
    {
        public PlanetMovementConfig PlanetMovement;
    }
}