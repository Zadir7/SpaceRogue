using System;
using UnityEngine;

[Serializable]
public class StarFullConfigs
{
    [Header("MainStar")]
    [SerializeField] public string Name;
    [SerializeField, Min(1)] public int Chanse;
    [SerializeField, Min(0.1f)] public float MinDistanceFromOtherStars;
    [SerializeField, Min(0.1f)] public float MaxDistanceFromOtherStars;
    [SerializeField, Min(0)] public int MinPlanetOnOrbit;
    [SerializeField, Min(0)] public int MaxPlanetOnOrbit;

    [Header("SizeStar")]
    [SerializeField] public float MinDiametr;
    [SerializeField] public float MaxDiametr;
    [SerializeField] public float KoefficientGravitation;

    [SerializeField] public GameObject TypeStart;
}
