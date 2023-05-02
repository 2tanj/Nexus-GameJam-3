using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPManager : MonoBehaviour
{
    public static XPManager Instance;

    private int _currentLevel = 1;

    [SerializeField]
    // _levelIncrement = how much more xp will be needed on lvlUp = 5
    // _modifierIncrement = by how much will we increment the modifier = .2
    // _startingModifier = selfexplanatory = 1
    private float _increment, _modifierIncrement, _startingModifier;
        
    // we multiply _levelIncrement by _currentModifier, 
    // _xpToLevel = needed xp for leveleing
    private float _currentModifier, _xpToLevel;

    private float _currentXp;
    public float CurrentXp {
        get => _currentXp;
        set {
            _currentXp = value;
            Debug.Log("new xp: " + _currentXp);
            if (_currentXp >= _xpToLevel)
                LevelUP();
            UpdateUI();
        } 
    }

    void Awake() => Instance = this;

    private void Start() 
    { 
        _currentModifier = _startingModifier;
        _xpToLevel       = _increment;
    }


    public IPickup TESTING;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            var cao = UnityEngine.Random.Range(-10, 10);
            Debug.Log(cao);

            TESTING.TESTING(cao);
            TESTING.Spawn(Vector3.zero);
        }
    }

    public void UpdateUI()
    {

    }

    private void LevelUP()
    {
        ++_currentLevel;
        _xpToLevel += _increment *= _currentModifier += _modifierIncrement;

        Debug.LogWarning("Leveled up: " + _currentLevel);
        // perform card showing logic here
    }
}
