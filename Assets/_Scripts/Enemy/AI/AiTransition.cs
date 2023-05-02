using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiTransition : MonoBehaviour
{
    [field: SerializeField]
    public List<AiDecision> Decisions { get; set; }

    [field: SerializeField]
    public AiState PositiveResult { get; set; }
    [field: SerializeField]
    public AiState NegativeResult { get; set; }

    private void Awake()
    {
        Decisions.Clear();
        Decisions = new List<AiDecision>(GetComponents<AiDecision>());
    }
}
