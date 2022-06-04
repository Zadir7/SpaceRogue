using UnityEngine;

namespace Scriptables
{
    [CreateAssetMenu(fileName = nameof(PlanetConfig), menuName = "Configs/" + nameof(PlanetConfig))]
    public class PlanetConfig : ScriptableObject
    {
        public string PlanetName;
        public int Orbita;
        public int Diametr;
    }
}