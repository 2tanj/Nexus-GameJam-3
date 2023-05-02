using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class IPickup : MonoBehaviour
{
    [SerializeField]
    protected int _amount;

    public abstract void Pickup();
}
