using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKnockback
{
    bool IsKnockedBack { get; }
    void Knockback(Vector2 direction, float power, float duration);
}
