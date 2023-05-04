using UnityEngine;
using UnityEngine.Events;

public interface IHittable
{
    public UnityEvent OnGetHit { get; set; }
    void GetHit(float damage, GameObject damageDealer);
}
