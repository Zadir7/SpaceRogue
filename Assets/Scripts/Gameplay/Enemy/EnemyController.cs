using Abstracts;
using Gameplay.Enemy.Behaviour;
using Gameplay.Enemy.Movement;
using Gameplay.Health;
using Gameplay.Player;
using Gameplay.Shooting;
using Scriptables.Enemy;
using Scriptables.Health;

namespace Gameplay.Enemy
{
    public class EnemyController : BaseController
    {
        private readonly EnemyView _view;
        private readonly EnemyConfig _config;
        private readonly FrontalTurretController _turret;
        private readonly EnemyMovementController _movementController;
        private readonly EnemyMovementModel _movementModel;
        private readonly EnemyBehaviourController _behaviourController;
        private readonly HealthController _healthController;
        private readonly PlayerView _playerView;

        public EnemyController(EnemyConfig config, EnemyView view, PlayerView playerView)
        {
            _playerView = playerView;
            _config = config;
            _view = view;
            AddGameObject(_view.gameObject);
            _turret = WeaponFactory.CreateFrontalTurret(_config.Weapon, _view.transform);
            AddController(_turret);

            _movementModel = new EnemyMovementModel(_config.Movement);
            _movementController = new EnemyMovementController(_view, _movementModel);
            AddController(_movementController);

            _behaviourController = new EnemyBehaviourController(_movementModel, _view, _turret, _playerView);
            AddController(_behaviourController);

            _healthController = AddHealthController(_config.Health, _config.Shield);
        }

        private HealthController AddHealthController(HealthConfig healthConfig, ShieldConfig shieldConfig)
        {
            var healthController = _config.Shield is null
                ? new HealthController(_config.Health, _view)
                : new HealthController(_config.Health, _config.Shield, _view);
            
            healthController.SubscribeToOnDestroy(Dispose);
            return healthController;
        }
    }
}