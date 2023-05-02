using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{
    [field: SerializeField]
    public float AttackDelay { get; private set; } = 1;

    protected EnemyBrain _enemyBrain;

    protected bool _waitngForNextAttack;

    void Awake() => 
        _enemyBrain = GetComponent<EnemyBrain>();

    public abstract void Attack(int damage);

    protected IEnumerator WaitBeforeAttackCoroutine()
    {
        _waitngForNextAttack = true;
        yield return new WaitForSeconds(AttackDelay);
        _waitngForNextAttack = false;
    }

    protected GameObject GetTarget() => _enemyBrain.Target;
}
