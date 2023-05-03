using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentInput : MonoBehaviour, IAgentInput
{
    private bool _fireButtonDown = false;

    [field: SerializeField]
    public UnityEvent<Vector2> OnMovementKeyPressed    { get; set; }
    [field: SerializeField]
    public UnityEvent<Vector2> OnPointerPositionChange { get; set; }
    [field: SerializeField]
    public UnityEvent<Vector2> OnAbilityButtonPressed  { get; set; }

    [field: SerializeField]
    public UnityEvent OnFireButtonPressed    { get; set; }
    [field: SerializeField]                  
    public UnityEvent OnFireButtonReleased   { get; set; }
    [field: SerializeField]                  
    public UnityEvent OnDashButtonPressed    { get; set; }

    private void Update()
    {
        GetMovementInput();
        GetPointerInput();
        GetFireInput();
        GetDashInput();
        GetAbilityInput();
    }

    private void GetPointerInput()
    {
        var pointerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        OnPointerPositionChange?.Invoke(pointerPos);
    }

    private void GetMovementInput() => 
        OnMovementKeyPressed?.Invoke(new Vector2(
            Input.GetAxisRaw("Horizontal"), 
            Input.GetAxisRaw("Vertical")));

    private void GetDashInput()
    {
        if (Input.GetButtonDown("Jump"))
            OnDashButtonPressed?.Invoke();
    }

    private void GetAbilityInput()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            var pointerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            OnAbilityButtonPressed?.Invoke(pointerPos);
        }
    }

    private void GetFireInput()
    {
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            if (!_fireButtonDown)
            {
                _fireButtonDown = true;
                OnFireButtonPressed?.Invoke();
            }
        }
        else
        {
            if (_fireButtonDown)
            {
                _fireButtonDown = false;
                OnFireButtonReleased?.Invoke();
            }
        }
    }
}
