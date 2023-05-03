using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class KnifeThrowAbility : IAbility
{
    [SerializeField, Range(1,50)]
    private int _damage = 5, _speed = 1;

    [SerializeField, Range(1, 10)]
    private float _knockbackPower, _knockbackDelay;

    [SerializeField]
    private float _delayToDestroy = 5f;

    private GameObject _instance;

    public override void PerformAbility(Player player, Vector3 mousePos)
    {
        _instance = Instantiate(
            gameObject,
            player.transform.position,
            Quaternion.identity);

        // rotating towards mouse pos
        var   direction = mousePos - _instance.transform.position;
        float angle     = Vector2.SignedAngle(Vector2.up, direction);
        _instance.transform.eulerAngles = new Vector3(0, 0, angle);

        _instance.transform.DOMove(mousePos.normalized * 10, _speed);
    }

    protected override IEnumerator FinishAbility()
    {
        yield return base.FinishAbility();

        yield return new WaitForSeconds(_delayToDestroy);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.TryGetComponent(out Enemy enemy);
        enemy?.GetHit(_damage, gameObject);

        collision.TryGetComponent(out IKnockback knockback);
        knockback.Knockback(_instance.transform.up, _knockbackPower, _knockbackDelay);
    }
}