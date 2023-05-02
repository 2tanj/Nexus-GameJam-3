using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : AiAction
{
    public override void TakeAction()
    {
        _aiMovementData.Direction       = Vector2.zero;
        _aiMovementData.PointOfInterest = _enemyBrain.Target.transform.position;
        _enemyBrain.Move(_aiMovementData.Direction, _aiMovementData.PointOfInterest);

        _aiActionData.Attack = true;
        _enemyBrain.Attack();
    }
}
 