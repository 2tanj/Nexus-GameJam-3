using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReferenceManager : MonoBehaviour
{
    public static ReferenceManager Instance;

    [SerializeField]
    private AgentInput _agentInput;

    public UnityEvent OnAttack { get; private set; }

    void Awake() => Instance = this;

    private void Start()
    {
        OnAttack = _agentInput.OnFireButtonPressed;
    }
}
