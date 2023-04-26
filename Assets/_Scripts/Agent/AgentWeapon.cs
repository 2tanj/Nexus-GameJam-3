//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class AgentWeapon : MonoBehaviour
//{
//    //[SerializeField]
//    protected WeaponRenderer _weaponRenderer;

//    //[SerializeField]
//    protected Weapon _weapon;

//    protected float _desiredAngle;

//    private void Awake()
//    {
//        AssignWeapon();
//    }

//    // We call on awake or any time we want to switch weapon
//    private void AssignWeapon()
//    {
//        _weaponRenderer = GetComponentInChildren<WeaponRenderer>();
//        _weapon = GetComponentInChildren<Weapon>();
//    }

//    public virtual void AimWeapon(Vector2 pointerPosition)
//    {
//        var aimDirection = (Vector3)pointerPosition - transform.position;
//        _desiredAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
//        AdjustWeaponRendering();
//        transform.rotation = Quaternion.AngleAxis(_desiredAngle, Vector3.forward);
//    }

//    protected void AdjustWeaponRendering()
//    {
//        if (_weaponRenderer == null)
//            return;

//        _weaponRenderer.FlipSprite(_desiredAngle > 90 || _desiredAngle < -90);
//        _weaponRenderer.RenderBehindHead(_desiredAngle < 180 && _desiredAngle > 0);
//    }

//    public void Shoot()
//    {
//        if (_weaponRenderer == null)
//            return;

//        _weapon.TryShooting();
//    }

//    public void StopShooting()
//    {
//        if (_weaponRenderer == null)
//            return;

//        _weapon.StopShooting();
//    }
//}

