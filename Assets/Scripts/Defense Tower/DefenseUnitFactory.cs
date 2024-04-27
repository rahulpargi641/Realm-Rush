using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Defense_Tower
{
    public interface IDefenseUnit
    {
        void Shoot(bool bShoot);
    }


    public abstract class DenfenseUnitFactory : ScriptableObject
    {
        public GameObject prefab;
        public abstract IDefenseUnit Create();
    }
}
