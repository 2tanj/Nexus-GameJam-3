using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/WeaponData")]
public class WeaponDataSO : ScriptableObject
{
    public WeaponType WeaponType;

    public string WeaponName;

    [Range(0, 10), SerializeField]
    private float _attackDelay = 1f;
    public float AttackDelay {
        set => _attackDelay = value;
        get {
            if (WeaponType == WeaponType.LIGHT) return 0;
            else                                return _attackDelay;
        }
    }
    
    [Range(0, 10), SerializeField]
    private float _attackRange = 1f;
    public float AttackRange {
        set => _attackRange = value;
        get {
            if (WeaponType == WeaponType.HEAVY) return 0;
            else                                return _attackRange;
        }
    }

    [Range(0, 5)]
    public float AttackDuration = 1f;
}

[System.Serializable]
public enum WeaponType
{
    LIGHT = 0,
    HEAVY = 1
}
