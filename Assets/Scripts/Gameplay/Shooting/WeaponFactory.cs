using System;
using Scriptables.Modules;
using UnityEngine;

namespace Gameplay.Shooting
{
    public static class WeaponFactory
    {
        public static FrontalTurretController CreateFrontalTurret(TurretModuleConfig config, Transform gunPointParentTransform)
        {
            return config.WeaponType switch
            {
                WeaponType.None => new FrontalNullGunController(config, gunPointParentTransform),
                WeaponType.Blaster => new FrontalBlasterController(config, gunPointParentTransform),
                WeaponType.Shotgun => new FrontalShotgunController(config, gunPointParentTransform),
                WeaponType.Minigun => new FrontalMinigunController(config, gunPointParentTransform),
                WeaponType.Railgun => new FrontalRailgunController(config, gunPointParentTransform),
                _ => throw new ArgumentOutOfRangeException(nameof(config.WeaponType), config.WeaponType, "A not-existent weapon type is provided")
            };
        }
    }
}