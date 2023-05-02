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

        ChangeWeapon(_weapons[_currentWeaponIndex++]);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            ChangeWeapon(_weapons[_currentWeaponIndex++ % _weapons.Count]);
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

        var direction = (aimDirection - (Vector2)transform.position).normalized;
        _currentWeapon.transform.up = direction;

        var scale = _currentWeapon.OriginalScale;
        scale.x = direction.x < 0 ? scale.x *= -1 : scale.x;
        _currentWeapon.transform.localScale = scale;
    }

    public void Attack() => _currentWeapon.Attack();
}
