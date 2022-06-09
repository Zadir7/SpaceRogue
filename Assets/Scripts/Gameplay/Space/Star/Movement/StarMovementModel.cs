using System;
using UnityEngine;

[Serializable]
public class StarMovementModel
{
    [Header("Size")]
    [SerializeField] public float Diametr;
    [SerializeField] public float KoefficientGravitation;

    [Header("Type Star")]
    [SerializeField] public GameObject TypeStart;
    [SerializeField] public Color ColorStar;
}
