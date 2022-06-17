using Abstracts;
using Scriptables;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGenerateModel
{
    private readonly PlanetConfig planetConfig = new PlanetConfig();
    private readonly PlanetView planetView = new PlanetView();
    public PlanetGenerateModel(PlanetConfig _planetConfig, PlanetView _planetView)
    {
        planetView = _planetView;
        planetConfig = _planetConfig;
    }
    public (PlanetConfig, PlanetView) CustomPlanetConfig()
    {
        System.Random random = new System.Random();

        planetConfig.PlanetMovement.DiametrPlanet = (float)random.Next(planetConfig.PlanetMovement.MinDiametrPlanet * 100, planetConfig.PlanetMovement.MaxDiametrPlanet * 100) / 100;
        planetConfig.PlanetMovement.Orbit = (float)random.Next(planetConfig.PlanetMovement.MinOrbit * 100, planetConfig.PlanetMovement.MaxOrbit * 100) / 100;
        planetConfig.PlanetMovement.Speed = planetConfig.PlanetMovement.Speed == 0 ? (float)random.Next(1 * 100, 5 * 100) / 100 : planetConfig.PlanetMovement.Speed;
        planetConfig.PlanetMovement.SideMove = random.Next(1, 3) < 2 ? false : true;
            

        sbyte sectorPlanet = (sbyte)(((random.Next(100, 300) / 100) < 2) ? -1 : 1);
        planetConfig.PlanetMovement.PositionPlanet.x = sectorPlanet * random.Next(planetConfig.PlanetMovement.MinOrbit * 100, (int)planetConfig.PlanetMovement.Orbit * 100) / 100;
        
        sectorPlanet = (sbyte)(((random.Next(100, 300) / 100) < 2) ? -1 : 1);
        planetConfig.PlanetMovement.PositionPlanet 
            = new Vector3 ( planetConfig.PlanetMovement.PositionPlanet.x,
                            sectorPlanet * (float)System.Math.Sqrt(
                                                                planetConfig.PlanetMovement.Orbit * planetConfig.PlanetMovement.Orbit -
                                                                planetConfig.PlanetMovement.PositionPlanet.x * planetConfig.PlanetMovement.PositionPlanet.x),
                            0);
        planetView.gameObject.transform.position = planetConfig.PlanetMovement.PositionStar + planetConfig.PlanetMovement.PositionPlanet;
        planetView.gameObject.transform.localScale = new Vector3(planetConfig.PlanetMovement.DiametrPlanet, planetConfig.PlanetMovement.DiametrPlanet, 0) ;
        return (planetConfig, planetView);
    }

    public static int RandomSelectPlanet (List<ChanseSelectObjectConfig> allPlanetChanse)
    {
        int chanse = 0;
        foreach (var planetChanse in allPlanetChanse)
        {
            chanse = chanse + planetChanse.KoefficientChanse;
        }

        System.Random random = new System.Random();
        chanse = random.Next(chanse);

        for (int i = 0; i < allPlanetChanse.Count; i++)
        {
            if (allPlanetChanse[i].KoefficientChanse > chanse)
            {
                return i;
            }
            chanse = chanse - allPlanetChanse[i].KoefficientChanse;
        }
        return 0;
    }
    

}
