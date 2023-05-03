using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class IAbility : MonoBehaviour
{
    [field: SerializeField]
    public AbilityDataSO AbilityData { get; private set; }

    protected bool _canBeUsed = true;

    public abstract void PerformAbility(Player player, Vector3 mousePos);

    protected virtual IEnumerator FinishAbility()
    {
        // perform UI CD logic here

        yield return new WaitForSeconds(AbilityData.Cooldown);
        _canBeUsed = true;
    }
}
