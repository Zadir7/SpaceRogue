using System;
using UnityEngine;

[Serializable]
public class StarFullConfigs
{
    [Header("MainStar")]
    [SerializeField] public string Name;
    [SerializeField, Min(1)] public int Chanse;

    [SerializeField, Min(1)] public int MinDistanceFromOtherStars;
    [SerializeField, Min(1)] public int MaxDistanceFromOtherStars;
    [SerializeField] public float DistanceFromOtherStars;

    [SerializeField, Min(0)] public int MinPlanetOnOrbit;
    [SerializeField, Min(0)] public int MaxPlanetOnOrbit;
    [SerializeField] public float PlanetOnOrbit;

    [Header("SizeStar")]
    [SerializeField] public int MinDiametr;
    [SerializeField] public int MaxDiametr;
    [SerializeField] public float Diametr;
    [SerializeField] public float KoefficientGravitation;

    [SerializeField] public GameObject TypeStart;
}
