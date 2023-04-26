using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Agent/MovementData")]
public class MovementSO : ScriptableObject
{
    [Range(1, 10)]
    public float MaxSpeed = 5;

    [Range(.1f, 100f)]
    public float Acceleration = 50, Deacceleration = 50;
}
