using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbXP : IPickup
{
    public override void Pickup() => 
        XPManager.Instance.CurrentXp += _amount;
}
