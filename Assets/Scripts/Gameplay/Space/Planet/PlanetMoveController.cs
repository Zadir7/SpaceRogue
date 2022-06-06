using Abstracts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMoveController : BaseController
{
    public Vector3 MovePlanet(GameObject planet, float orbita, float speedPlanet, int sideMove)
    {
        return planet.transform.position = new Vector3(
                                            (planet.transform.position.x + sideMove * orbita * Mathf.Cos(Mathf.PI * Time.unscaledTime * speedPlanet)),
                                            (planet.transform.position.y + orbita * Mathf.Sin(Mathf.PI * Time.unscaledTime * speedPlanet)), 0);

    }
}
