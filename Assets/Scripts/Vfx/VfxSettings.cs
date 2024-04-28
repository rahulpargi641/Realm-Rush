using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Vfx
{
    [CreateAssetMenu(menuName = "Flyweight/VFX Settings")]
    public class VfxSettings : FlyweightSettings
    {
        public float despawnDelay = 5f;

        public override Flyweight Create()
        {
            var go = Instantiate(prefab);
            go.SetActive(false);
            go.name = prefab.name;

            var vfx = go.AddComponent<Vfx>();
            vfx.settings = this;

            return vfx;
        }
    }
}