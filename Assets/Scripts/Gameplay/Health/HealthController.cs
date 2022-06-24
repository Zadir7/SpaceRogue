using Abstracts;
using Scriptables;
using Scriptables.Modules;

namespace Gameplay.Health
{
    public class HealthController : BaseController
    {
        private readonly HealthModel _healthModel;

        public HealthController(HealthConfig healthConfig, ShieldModuleConfig shieldConfig)
        {
            _healthModel = new HealthModel(healthConfig, shieldConfig);
        }
    }
}