using Abstracts;
using Gameplay.Space.Star;

namespace Gameplay.Space
{
    public class SpaceController : BaseController
    {

        private readonly StarController _starConntroller;

        public SpaceController()
        {
            //TODO Generate map here
            //Загружаем конфиг (SO) с настройками объектов (посмотри пример в PlayerConfig)
            //Создаем контроллеры для каждого типа объекта
            //Делаем LoadView внутри дочерних контроллеров
            System.Random random = new System.Random();
            int numberPlanets = random.Next(1, 1 + 1);
            for (int i = 0; i < numberPlanets; i++)
            {
                _starConntroller = new StarController();
            }
        }
    }
}