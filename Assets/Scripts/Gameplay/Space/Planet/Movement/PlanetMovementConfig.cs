using Gameplay.Planet.Movement;
using System;
using UnityEngine;

[Serializable]
public class PlanetMovementConfig
{
    [Header("Speed")]
    [SerializeField] public float Speed;
    [SerializeField] public bool SideMove;

    [Header("Size")]
    [SerializeField] public int MinDiametrPlanet;
    [SerializeField] public int MaxDiametrPlanet;
    [SerializeField] internal float DiametrPlanet;

    [SerializeField] public int MinOrbit;
    [SerializeField] public int MaxOrbit;
    [SerializeField] internal float Orbit;

    [SerializeField] public Vector3 PositionPlanet;
    [SerializeField] public Vector3 PositionStar;

    [Header("Type Planet")]
    [SerializeField] public GameObject TypePlanet;
    [SerializeField] public int Resource;
}

