using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer), typeof(CircleCollider2D))]
public abstract class IPickup : MonoBehaviour
{
    [SerializeField]
    protected int _amount;

    public UnityEvent OnPickUp;

    public virtual GameObject Spawn(Vector3 pos)
            => Instantiate(gameObject, pos, Quaternion.identity);

    public virtual void Pickup()
    {
        OnPickUp?.Invoke();
        Destroy(gameObject);
    }

    public void TESTING(int c)
    {
        _amount = c;
    }
}
