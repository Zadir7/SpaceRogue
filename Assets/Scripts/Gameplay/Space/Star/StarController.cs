using Abstracts;
using Scriptables;
using Utilities.ResourceManagement;
using Gameplay.Planet;
using Configs.StarsConfigs;
using System.Collections.Generic;

namespace Gameplay.Space.Star
{
    public class StarController : BaseController
    {
        private readonly ResourcePath _allStarPath = new ResourcePath("Configs/ChanseConfigs/ChanseSelectStar");
        private readonly ResourcePath _configPath = new("Configs/StarsConfigs/");
        private readonly ResourcePath _viewPath = new("Prefabs/VariantStar/");
        
        private readonly StarConfig _config;
        private readonly StarView[] _allViews;
        private readonly StarView _view;

        private readonly List<ChanseSelectObjectConfig> allStarChanse;
        private readonly PlanetGenerateModel planetGenerateModel;
        private readonly StarGenerateModel starGenerateModel;

        public StarController()
        {
            System.Random random = new System.Random();

            allStarChanse = ResourceLoader.LoadObject<ChanseSelectedObject>(_allStarPath).ChanseSelectobjects;

            var select = PlanetGenerateModel.RandomSelectPlanet(allStarChanse);

            _config = ResourceLoader.LoadObject<StarConfig>(new ResourcePath($"{_configPath.PathToResource.ToString()}{allStarChanse[select].NameObject.ToString()}"));
            StarConfig starConfig = new StarConfig();
            starConfig.starFullConfigs = _config.starFullConfigs;

            _view = LoadView<StarView>(new ResourcePath($"{_viewPath.PathToResource.ToString()}{allStarChanse[select].NameObject.ToString()}"));

            starGenerateModel = new StarGenerateModel(starConfig, _view);
            (starConfig, _view) = starGenerateModel.CustomStarConfig();

            AddPlanetInSpace(starConfig, _view);
        }

        
        private void AddPlanetInSpace(StarConfig config, StarView view)
        {
            System.Random random = new System.Random();
            int numberPlanets = random.Next(config.starFullConfigs.MinPlanetOnOrbit, config.starFullConfigs.MaxPlanetOnOrbit + 1);
            for (int i = 0; i < numberPlanets; i++)
            {
                var planetConntroller = new PlanetController(config, view);
                AddController(planetConntroller);
            }
        }
    }
}