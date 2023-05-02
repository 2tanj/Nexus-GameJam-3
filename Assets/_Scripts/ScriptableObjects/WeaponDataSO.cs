using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/WeaponData")]
public class WeaponDataSO : ScriptableObject
{
    public WeaponType WeaponType;

    public string WeaponName;

    [field: SerializeField]
    public GameObject ImpactPrefab { get; private set; }


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

    [field: SerializeField, Range(0, 5)]
    public float AttackDuration { get; private set; } = 1f;

    [field: SerializeField, Range(1, 50)]
    public int Damage { get; private set; } = 1;

    [field: SerializeField, Range(1, 50)]
    public float KnockbackPower { get; private set; } = 1;

    [field: SerializeField, Range(1, 50)]
    public float KnockbackDelay { get; private set; } = .01f;
}

[System.Serializable]
public enum WeaponType
{
    LIGHT = 0,
    HEAVY = 1
}
