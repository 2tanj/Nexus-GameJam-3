using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IAgent, IHittable
{
    [SerializeField]
    private int _maxHealth;

    [SerializeField]
    private IAbility _currentAbility;
    public  IAbility CurrentAbility { 
                get => _currentAbility; 
        private set {
            _currentAbility = value;
            _currentAbility.ActivateAbility(); 
        } 
    }

    public float Health { get; private set; }

    public bool IsDead  { get; private set; }

    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }
    [field: SerializeField]
    public UnityEvent OnDeath  { get; set; }


    private void Start()
    {
        Health = _maxHealth;
        _currentAbility.ActivateAbility();
    }

    public void PerformAbility(Vector2 mousePos)
    {
        if (_currentAbility.CanBeUsed)
            _currentAbility.PerformAbility(this, mousePos);
    }

    public void GetHit(float damage, GameObject damageDealer)
    {
        if (IsDead)
            return;

        Debug.Log($"player took damage, HP:{Health}");

        Health -= damage;
        OnGetHit?.Invoke();

        if (Health <= 0)
        {
            Debug.Log("player dead");

            OnDeath?.Invoke();
            IsDead = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.TryGetComponent(out IPickup pickup);
        pickup?.Pickup();
        
    }
}
