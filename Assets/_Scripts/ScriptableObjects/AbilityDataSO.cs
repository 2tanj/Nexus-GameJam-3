using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/AbilityData")]
public class AbilityDataSO : ScriptableObject
{
    [field: SerializeField]
    public string         Name        { get; private set; }

    [field: SerializeField, TextArea]
    public string         Description { get; private set; }

    //[field: SerializeField]
    //public SpriteRenderer Icon        { get; private set; }

    [field: SerializeField, Range(0, 50)]
    public float          Cooldown    { get; private set; }
}
