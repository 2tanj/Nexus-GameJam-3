using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiActionData : MonoBehaviour
{
    [field: SerializeField]
    public bool Attack { get; set; }
    [field: SerializeField]
    public bool TargetSpooted { get; set; }
    [field: SerializeField]
    public bool Arrived { get; set; }
}
