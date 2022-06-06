using System;
using UnityEngine;

[Serializable]
public class PlanetMovementModel
{
    [Header("Speed")]
    [SerializeField] public float Speed;
    [SerializeField] public float SideMove;

    [Header("Size")]
    [SerializeField] public float Diametr;
    [SerializeField] public float Orbita;
    [SerializeField] public Vector3 Centr;

    [Header("Type Planet")]
    [SerializeField] public GameObject TypePlanet;
    [SerializeField] public int Resource;
}

