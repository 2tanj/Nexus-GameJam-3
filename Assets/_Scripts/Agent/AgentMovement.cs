using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class AgentMovement : MonoBehaviour
{
    [field: SerializeField]
    public MovementDataSO MovementData { get; set; }

    [SerializeField]
    public float _dashAmount = 750f, _dashCooldown = 1.5f;
    private bool _canDash = true;

    public Rigidbody2D RigidBody { get; private set; }
    public float CurrentVelocity { get; set; }


    private Vector2 _movementDirection;
    private Vector2 _lastMovementDirection;

    protected bool _isKnockedBack = false;

    [field: SerializeField]
    public UnityEvent<float> OnVelocityChange { get; set; }

    private void Awake() => 
        RigidBody = GetComponent<Rigidbody2D>();

    private void FixedUpdate()
    {
        OnVelocityChange?.Invoke(CurrentVelocity);

        if (!_isKnockedBack) 
            RigidBody.velocity = CurrentVelocity * _movementDirection.normalized;
    }

    public void MoveAgent(Vector2 movementInput)
    {
        if (movementInput.magnitude != 0)
            _lastMovementDirection = movementInput;

        _movementDirection = movementInput;
        CurrentVelocity = CalculateSpeed(movementInput);
    }

    private float CalculateSpeed(Vector2 movementInput)
    {
        if (movementInput.magnitude > 0)
            CurrentVelocity += MovementData.Acceleration * Time.deltaTime;
        else
            CurrentVelocity -= MovementData.Deacceleration / 2 * Time.deltaTime;

        return Mathf.Clamp(CurrentVelocity, 0, MovementData.MaxSpeed);
    }

    public void Dash() => 
        StartCoroutine(Dash(_dashCooldown));

    private IEnumerator Dash(float cooldown)
    {
        if (_canDash)
        {
            RigidBody.AddForce(_lastMovementDirection * _dashAmount);
            _canDash = false;

            yield return new WaitForSeconds(cooldown);
            _canDash = true;
        }
        else
            Debug.LogWarning("Dash on cd!");
    }
}
