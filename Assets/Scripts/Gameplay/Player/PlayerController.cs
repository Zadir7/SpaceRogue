using System.Collections.Generic;
using Abstracts;
using Gameplay.Health;
using Gameplay.Input;
using Gameplay.Player.FrontalGuns;
using Gameplay.Player.Inventory;
using Gameplay.Player.Movement;
using Scriptables;
using Scriptables.Modules;
using UnityEngine;
using Utilities.Reactive.SubscriptionProperty;
using Utilities.ResourceManagement;

namespace Gameplay.Player
{
    public class PlayerController : BaseController
    {
        public PlayerView View => _view;
        public PlayerConfig PlayerConfig => _config;
        
        private readonly ResourcePath _configPath = new("Configs/PlayerConfig");
        private readonly ResourcePath _viewPath = new("Prefabs/Gameplay/Player");
        
        private readonly PlayerConfig _config;
        private readonly PlayerView _view;

        private readonly SubscribedProperty<float> _horizontalInput = new();
        private readonly SubscribedProperty<float> _verticalInput = new();
        private readonly SubscribedProperty<bool> _primaryFireInput = new();

        public PlayerController()
        {
            _config = ResourceLoader.LoadObject<PlayerConfig>(_configPath);
            _view = LoadView<PlayerView>(_viewPath, Vector3.zero);
            
            //���� ���������� ������� ������ �� ����������� �������� 
            //�������� � ���� ��� ������.
            HealthConfig playerhealth = new HealthConfig();
            ShieldModuleConfig playershield = new ShieldModuleConfig();
            _config.HealthShield = new HealthModel(playerhealth, playershield);
            //
            
            var inputController = new InputController(_horizontalInput, _verticalInput, _primaryFireInput);
            AddController(inputController);

            var inventoryController = AddInventoryController(_config.Inventory);
            var movementController = AddMovementController(inventoryController.Engine, _view);
            var frontalGunsController = AddFrontalGunsController(inventoryController.Turrets, _view);
        }

        private PlayerInventoryController AddInventoryController(PlayerInventoryConfig config)
        {
            var inventoryController = new PlayerInventoryController(_config.Inventory);
            AddController(inventoryController);
            return inventoryController;
        }

        private PlayerMovementController AddMovementController(EngineModuleConfig movementConfig, PlayerView view)
        {
            var movementController = new PlayerMovementController(_horizontalInput, _verticalInput, movementConfig, view);
            AddController(movementController);
            return movementController;
        }

        private FrontalGunsController AddFrontalGunsController(List<TurretModuleConfig> turretConfigs, PlayerView view)
        {
            var frontalGunsController = new FrontalGunsController(_primaryFireInput, turretConfigs, view);
            AddController(frontalGunsController);
            return frontalGunsController;
        }
    }
}