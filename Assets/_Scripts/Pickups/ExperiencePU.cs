using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ExperiencePU : IPickup
{
    void Start()
    {
        //float distance = 1.5f, duration = 2f;
        transform.DOMoveY(transform.position.y + .2f, 2.5f)
                 .SetEase(Ease.Linear)
                 .SetLoops(-1, LoopType.Yoyo);
    }

    public override void Pickup()
    {
        XPManager.Instance.CurrentXp += _amount;
        base.Pickup();
    }

    public override GameObject Spawn(Vector3 pos)
    {
        var pu = base.Spawn(pos);
        var modifier = Mathf.Clamp(_amount, 0, 20) * .07f;
        pu.transform.localScale += new Vector3(modifier, modifier);

        return pu;
    }
}
