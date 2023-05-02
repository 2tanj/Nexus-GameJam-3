using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceDecision : AiDecision
{
    [field: SerializeField]
    [field: Range(.1f, 10)]
    public float Distance { get; set; } = 5;

    public override bool MakeADecision()
    {
        if (Vector3.Distance(_enemyBrain.Target.transform.position, transform.position) < Distance)
        {
            if (!_aiActionData.TargetSpooted)
                _aiActionData.TargetSpooted = true;
        }
        else
            _aiActionData.TargetSpooted = false;
        
        return _aiActionData.TargetSpooted;
    }

#if UNITY_EDITOR // preventing crash on build
    protected void OnDrawGizmos()
    {
        if(UnityEditor.Selection.activeObject == gameObject)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, Distance);
            Gizmos.color = Color.white; // reset color
        }
    }
#endif
}
