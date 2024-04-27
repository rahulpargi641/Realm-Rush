using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IDefenseUnit
{
    void Attack();
}


public abstract class DefenseUnitFactory : ScriptableObject
{
    public abstract IDefenseUnit Create();
}
