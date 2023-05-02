using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AiAction : MonoBehaviour
{
    protected AiActionData   _aiActionData;
    protected AiMovementData _aiMovementData;
    protected EnemyBrain     _enemyBrain;

    private void Awake()
    {
        _aiActionData   = transform.root.GetComponentInChildren<AiActionData>();
        _aiMovementData = transform.root.GetComponentInChildren<AiMovementData>();
        _enemyBrain     = transform.root.GetComponent<EnemyBrain>();
    }

    public abstract void TakeAction();
}