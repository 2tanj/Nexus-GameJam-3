using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer))]
public class Weapon : MonoBehaviour
{
    [field: SerializeField]
    public WeaponDataSO WeaponData { get; private set; }

    public Vector3 OriginalScale   { get; private set; }

    protected bool _canAttack = true;


    private void Awake() => OriginalScale = transform.localScale;

    public void Attack()
    {
        if (!_canAttack)
            return;

        _canAttack = false;
        switch (WeaponData.WeaponType)
        {
            case WeaponType.LIGHT:
                LightAttack();
                break;
            case WeaponType.HEAVY:
                HeavyAttack();
                break;
        }
    }

    private void HeavyAttack()
    {
        transform.DOPunchRotation(
            punch: new Vector3(0, 0, -150f), 
            duration: WeaponData.AttackDuration,
            vibrato: 7,
            elasticity: .5f
        ).OnComplete(CompleteAttack);
    }

    private void LightAttack()
    {
        transform.DOPunchPosition(
            punch: transform.up * WeaponData.AttackRange,
            duration: WeaponData.AttackDuration,
            vibrato: 15,
            elasticity: .2f
        ).OnComplete(CompleteAttack);
    }

    private void CompleteAttack() => StartCoroutine(CompleteAttackCoroutine());
    private IEnumerator CompleteAttackCoroutine() 
    {
        yield return new WaitForSeconds(WeaponData.AttackDelay);
        _canAttack = true;
    }
}
