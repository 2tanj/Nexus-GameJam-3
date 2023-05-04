using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class IAbility : MonoBehaviour
{
    [field: SerializeField]
    public AbilityDataSO AbilityData { get; private set; }

    public bool CanBeUsed { get; protected set; } = true;
    
    virtual protected void Start() => CanBeUsed = true;

    public abstract void PerformAbility(Player player, Vector3 mousePos);
    public virtual void  ActivateAbility() { }

    public virtual async Task FinishAbility()
    {
        // hande cd ui logic here

        await Task.Delay((int)AbilityData.Cooldown * 1000);
        CanBeUsed = true;
    }
}
