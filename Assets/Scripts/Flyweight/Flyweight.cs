using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyweight : MonoBehaviour
{
    public FlyweightSettings settings; // Intrisic state
}

public enum FlyweightType
{
    EnemyShip, DefnseTower, HitVFX, DeathVFX
}
