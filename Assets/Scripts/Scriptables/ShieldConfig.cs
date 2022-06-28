using UnityEngine;

namespace Scriptables
{
    [CreateAssetMenu(fileName = nameof(ShieldConfig), menuName = "Configs/Stats/" + nameof(ShieldConfig))]
    public class ShieldConfig : ScriptableObject
    {
        [field: SerializeField, Min(1f)] public float MaximumShield { get; private set; }
        [field: SerializeField, Min(1f)] public float NowShield { get; private set; }
        [field: SerializeField, Min(0f)] public float ShieldRegen { get; private set; }
    }
}