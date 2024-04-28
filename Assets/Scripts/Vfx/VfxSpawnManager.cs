using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Generic;

namespace Assets.Scripts.Vfx
{
    public class VfxSpawnManager : MonoSingletonGeneric<VfxSpawnManager>
    {
        [SerializeField] private List<VfxSettings> enemyVFXSettings;

        public void SpawnVfx(Vector3 spawnPoint)
        {
            var vfx = FlyweightFactory.Spawn(enemyVFXSettings[0]) as Vfx;
            if (vfx != null)
            {
                vfx.SetTransform(spawnPoint);
                vfx.PlayVFX();
            }
        }

    }
}