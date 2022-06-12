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
    [SerializeField] public float MinDiametrPlanet;
    [SerializeField] public float MaxDiametrPlanet;
    [SerializeField] public float DiametrPlanet;
    [SerializeField] public int MinOrbit;
    [SerializeField] public int MaxOrbit;
    [SerializeField] public float Orbit;
    [SerializeField] public Vector3 PositionPlanet;
    [SerializeField] public Vector3 PositionStar;

    [Header("Type Planet")]
    [SerializeField] public GameObject TypePlanet;
    [SerializeField] public int Resource;
}

