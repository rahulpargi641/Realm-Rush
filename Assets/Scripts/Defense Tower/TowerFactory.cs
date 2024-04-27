using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Defense_Tower
{
    [CreateAssetMenu(menuName = "Defense Unit Factory/Tower Factory", fileName = "Tower Factory")]
    public class TowerFactory : DenfenseUnitFactory
    {
        [SerializeField] TowerData data;

        public override IDefenseUnit Create()
        {
            var go = Instantiate(prefab);
            go.name = prefab.name;

            var tower = go.GetComponent<Tower>();
            tower.Data = data;

            return tower;
        }
    }
}