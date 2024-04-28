using UnityEngine;

public interface IDefenseUnit
{
    void Shoot(bool bShoot);
}

public abstract class DenfenseUnitFactory : ScriptableObject
{
    public GameObject prefab;
    public abstract IDefenseUnit Create();
}
