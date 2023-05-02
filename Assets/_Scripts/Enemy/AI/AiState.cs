using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiState : MonoBehaviour
{
    [SerializeField]
    private EnemyBrain _enemyBrain = null;
    [SerializeField]
    private List<AiAction> _actions = null;
    [SerializeField]
    private List<AiTransition> _transitions = null;

    private void Awake() =>
        _enemyBrain = transform.root.GetComponent<EnemyBrain>();

    public void UpdateState()
    {
        foreach (var action in _actions)
            action.TakeAction();
        foreach (var transition in _transitions)
        {
            // player in range > True > back to idle
            // player visible > True > chase

            bool res = false;
            foreach (var decision in transition.Decisions)
            {
                res = decision.MakeADecision();
                if (!res)
                    break;
            }

            if (res)
            {
                if (transition.PositiveResult != null)
                {
                    _enemyBrain.ChangeToState(transition.PositiveResult);
                    return;
                }
            }
            else
            {
                if (transition.NegativeResult != null)
                {
                    _enemyBrain.ChangeToState(transition.NegativeResult);
                    return;
                }
            }
        }
            
    }
}
