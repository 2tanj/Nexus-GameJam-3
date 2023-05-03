using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IHittable, IAgent, IKnockback
{
    [SerializeField]
    private EnemyDataSO _enemyData;

    public int  Health        { get; private set; } = 5;
    public bool IsKnockedBack { get; private set; }
    public bool IsDead        { get; private set; }

    [field: SerializeField]
    public UnityEvent OnDeath  { get; set; }
    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }

    private AgentMovement _agentMovement;
    private EnemyAttack   _enemyAttack;

    void Start() => Health = _enemyData.MaxHealth;
    void Awake() 
    { 
        _agentMovement = GetComponent<AgentMovement>();
        _enemyAttack   = GetComponent<EnemyAttack>();
    }

    #region KNOCKBACK
    public void Knockback(Vector2 direction, float power, float duration)
    {
        if (!IsKnockedBack)
        {
            IsKnockedBack = true;
            StartCoroutine(KnockBackCoroutine(direction, power, duration));
        }
    }
    private IEnumerator KnockBackCoroutine(Vector2 direction, float power, float duration)
    {
        Debug.Log(direction + " " + power + " " + duration);
        _agentMovement.RigidBody.AddForce(direction.normalized * power, ForceMode2D.Force);
        yield return new WaitForSeconds(duration);
        ResetKnockbackParams();
    }
    private void ResetKnockbackParams()
    {
        _agentMovement.CurrentVelocity = 0;
        _agentMovement.RigidBody.velocity = Vector2.zero;
        IsKnockedBack = false;
    }
    #endregion

    public void PerformAttack()
    {
        if (!IsDead)
            _enemyAttack.Attack(_enemyData.Damage);
    }

    public void GetHit(int damage, GameObject damageDealer)
    {
        //if (IsDead)
        //    return;

        Health -= damage;
        OnGetHit?.Invoke();

        Debug.Log(Health);

        if (Health <= 0) Death();
    }

    private void Death() 
    {
        IsDead = true;
        OnDeath?.Invoke();

        _enemyData.ExpPU.Spawn(transform.position);
        Destroy(gameObject); 
    }
}
