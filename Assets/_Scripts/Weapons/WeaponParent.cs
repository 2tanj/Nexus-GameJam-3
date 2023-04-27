using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public static WeaponParent Instance;

    [SerializeField]
    private Transform _lightParent, _heavyParent;

    // for testing
    [SerializeField]
    private List<Weapon> _weapons = new List<Weapon>();
    private int _currentWeaponIndex = 0;

    private Weapon _currentWeapon;

    private void Awake() 
    {
        Instance = this;

        ////TODO: remove this
        //_currentWeapon = GetComponentInChildren<Weapon>();

        ChangeWeapon(_weapons[_currentWeaponIndex++]);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeWeapon(_weapons[_currentWeaponIndex % _weapons.Count]);
            _currentWeaponIndex++;
        }
    }

    public void ChangeWeapon(Weapon newWeapon)
    {
        Destroy(_currentWeapon?.gameObject);

        if (newWeapon.WeaponData.WeaponType == WeaponType.HEAVY) SetupWeapon(newWeapon, _heavyParent);
        else                                                     SetupWeapon(newWeapon, _lightParent);
    }

    private void SetupWeapon(Weapon weapon, Transform parent)
    {
        _currentWeapon = Instantiate(weapon, parent);
        _currentWeapon.transform.localPosition = Vector3.zero;
    }

    public void AimWeapon(Vector2 aimDirection)
    {
        if (_currentWeapon.WeaponData.WeaponType == WeaponType.HEAVY)
            return;

        _currentWeapon.transform.up = (aimDirection - (Vector2)transform.position).normalized;
    }

    public void Attack() => _currentWeapon.Attack();
}
