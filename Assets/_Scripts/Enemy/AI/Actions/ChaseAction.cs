using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAction : AiAction
{
    public override void TakeAction()
    {
        var direction = _enemyBrain.Target.transform.position - transform.position;

        _aiMovementData.Direction       = direction.normalized;
        _aiMovementData.PointOfInterest = _enemyBrain.Target.transform.position;
        _enemyBrain.Move(_aiMovementData.Direction, _aiMovementData.PointOfInterest);
    }
}
