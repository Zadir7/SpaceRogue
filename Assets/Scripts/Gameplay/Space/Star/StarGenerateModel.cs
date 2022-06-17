using Configs.StarsConfigs;
using Scriptables;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerateModel
{
    System.Random random = new System.Random();
    private readonly StarConfig starConfig = new StarConfig();
    private readonly StarView starView = new StarView();
    public StarGenerateModel(StarConfig _starConfig, StarView _starView)
    {
        starView = _starView;
        starConfig = _starConfig;
    }

    public (StarConfig, StarView) CustomStarConfig()
    {
        starConfig.starFullConfigs.Diametr = (float)random.Next(starConfig.starFullConfigs.MinDiametr * 100, starConfig.starFullConfigs.MaxDiametr * 100) / 100;

        starView.gameObject.transform.position = SelectedPosition();
        starView.gameObject.transform.localScale = new Vector3(starConfig.starFullConfigs.Diametr, starConfig.starFullConfigs.Diametr, 0);

        return (starConfig, starView);
    }

    public static int RandomSelectPlanet(List<ChanseSelectObjectConfig> allPlanetChanse)
    {
        return PlanetGenerateModel.RandomSelectPlanet(allPlanetChanse);
    }

    public Vector3 SelectedPosition()
    {
        return new Vector3(random.Next(100), random.Next(100), 0);
    }
}
