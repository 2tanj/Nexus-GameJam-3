using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovementData : MonoBehaviour
{
    [field: SerializeField]
    public Vector2 Direction { get; set; }
    [field: SerializeField]
    public Vector2 PointOfInterest { get; set; } // Position of player or wherever ai wants to go
}
