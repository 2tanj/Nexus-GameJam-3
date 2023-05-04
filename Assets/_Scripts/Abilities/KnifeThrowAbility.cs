using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;

public class KnifeThrowAbility : IAbility
{
    [SerializeField, Range(0, 50)]
    private int _damage = 5;

    [SerializeField, Range(0, 10)]
    private float _knockbackPower, _knockbackDelay, _speed = 1;

    [SerializeField]
    private float _delayToDestroy = 5f;

    private static Vector3 _weaponUp;

    public override async void PerformAbility(Player player, Vector3 mousePos)
    {
        CanBeUsed = false;

        var ability = Instantiate(
            gameObject.GetComponent<IAbility>(),
            player.transform.position,
            Quaternion.identity);

        // rotating towards mouse pos
        var   direction = mousePos - ability.transform.position;
        float angle     = Vector2.SignedAngle(Vector2.up, direction);
        ability.transform.eulerAngles = new Vector3(0, 0, angle);

        ability.transform.DOMove(mousePos, _speed).SetEase(Ease.Linear);
        _weaponUp = ability.transform.up;

        //Debug.Log(ability.isActiveAndEnabled);
        FinishAbility();
        await DestroyAbility(ability.gameObject);
    }

    //public override IEnumerator FinishAbility(/*GameObject ability*/)
    //{
    //    //StartCoroutine(base.FinishAbility());
    //    //StartCoroutine(DestroyAbility(ability, _delayToDestroy));

    //    Debug.Log("started second finish");
    //    yield return new WaitForSeconds(_delayToDestroy);
    //    Debug.Log("finsihed second finish");
    //    Destroy(gameObject);
    //}

    private async Task DestroyAbility(GameObject ability)
    {
        await Task.Delay((int)_delayToDestroy * 1000);
        Destroy(ability);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.TryGetComponent(out Enemy enemy);
        enemy?.GetHit(_damage, gameObject);

        collision.TryGetComponent(out IKnockback knockback);
        knockback.Knockback(_weaponUp, _knockbackPower * 100, _knockbackDelay);

        Destroy(gameObject);
    }
}