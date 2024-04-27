using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Defense_Tower
{
    [CreateAssetMenu(fileName = "Tower Data", menuName = "Data/ Tower Data")]
    public class TowerData : ScriptableObject
    {
        public int attackRange = 50;
    }
}