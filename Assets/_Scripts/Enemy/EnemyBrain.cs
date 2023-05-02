using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBrain : MonoBehaviour, IAgentInput
{
    public GameObject Target;

    [field: SerializeField]
    public AiState CurrentState { get; private set; }

    [field: SerializeField]
    public UnityEvent OnFireButtonPressed  { get; set; }
    [field: SerializeField]
    public UnityEvent OnFireButtonReleased { get; set; }

    [field: SerializeField]
    public UnityEvent<Vector2> OnMovementKeyPressed    { get; set; }
    [field: SerializeField]
    public UnityEvent<Vector2> OnPointerPositionChange { get; set; }

    void Awake() => 
        Target = FindObjectOfType<Player>().gameObject;

    private void Update()
    {
        if (Target == null)
            OnMovementKeyPressed?.Invoke(Vector2.zero);
        else
            CurrentState.UpdateState();
    }

    public void Move(Vector2 movementDir, Vector2 targetPos)
    {
        OnMovementKeyPressed?.Invoke(movementDir);
        OnPointerPositionChange?.Invoke(targetPos);
    }
    public void Attack() => OnFireButtonPressed?.Invoke();

    internal void ChangeToState(AiState state) => CurrentState = state;
}
