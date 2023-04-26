using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class AgentMovement : MonoBehaviour
{
    [field: SerializeField]
    public MovementSO MovementData { get; set; }

    [SerializeField]
    public float _dashAmount = 750f, _dashCooldown = 1.5f;
    private bool _canDash = true;

    [SerializeField]
    protected float _currentVelocity;

    protected Rigidbody2D _rigidBody2D;
    private Vector2 _movementDirection;
    private Vector2 _lastMovementDirection;

    protected bool _isKnockedBack = false;

    [field: SerializeField]
    public UnityEvent<float> OnVelocityChange { get; set; }

    private void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        OnVelocityChange?.Invoke(_currentVelocity);

        if (!_isKnockedBack) 
            _rigidBody2D.velocity = _currentVelocity * _movementDirection.normalized;
    }

    public void MoveAgent(Vector2 movementInput)
    {
        if (movementInput.magnitude != 0)
            _lastMovementDirection = movementInput;

        _movementDirection = movementInput;
        _currentVelocity = CalculateSpeed(movementInput);
    }

    private float CalculateSpeed(Vector2 movementInput)
    {
        if (movementInput.magnitude > 0)
            _currentVelocity += MovementData.Acceleration * Time.deltaTime;
        else
            _currentVelocity -= MovementData.Deacceleration / 2 * Time.deltaTime;

        return Mathf.Clamp(_currentVelocity, 0, MovementData.MaxSpeed);
    }

    public void Dash() => 
        StartCoroutine(Dash(_dashCooldown));

    private IEnumerator Dash(float cooldown)
    {
        if (_canDash)
        {
            _rigidBody2D.AddForce(_lastMovementDirection * _dashAmount);
            _canDash = false;

            yield return new WaitForSeconds(cooldown);
            _canDash = true;
        }
        else
            Debug.LogWarning("Dash on cd!");
    }

    public void KnockBack(Vector2 direction, float power, float duration)
    {
        if (!_isKnockedBack)
        {
            _isKnockedBack = true;
            StartCoroutine(KnockBackCoroutine(direction, power, duration));
        }
    }

    private IEnumerator KnockBackCoroutine(Vector2 direction, float power, float duration)
    {
        _rigidBody2D.AddForce(direction.normalized * power, ForceMode2D.Impulse);
        yield return new WaitForSeconds(duration);
        ResetKnockbackParams();
    }

    private void ResetKnockbackParams()
    {
        _currentVelocity = 0;
        _rigidBody2D.velocity = Vector2.zero;
        _isKnockedBack = false;
    }

    //public void ResetKnockBack()
    //{
    //    StopAllCoroutines();
    //    StopCoroutine("KnockBackCoroutine");
    //    ResetKnockbackParams();
    //}
}
