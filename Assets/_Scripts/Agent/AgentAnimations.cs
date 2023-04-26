using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AgentAnimations : MonoBehaviour
{
    private Animator _agentAnimator;

    private void Awake()
    {
        _agentAnimator = GetComponent<Animator>();
    }

    public void SetWalkAnimation(bool val)
    {
        _agentAnimator.SetBool("Walk", val);
    }

    public void AnimatePlayer(float velocity)
    {
        SetWalkAnimation(velocity > 0);
    }
}
