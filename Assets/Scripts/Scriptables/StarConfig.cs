using UnityEngine;

namespace Scriptables
{
    [CreateAssetMenu(fileName = nameof(StarConfig), menuName = "Configs/" + nameof(StarConfig))]
    public class StarConfig : ScriptableObject
    {
        public StarMovementModel StarMovement;
    }
}