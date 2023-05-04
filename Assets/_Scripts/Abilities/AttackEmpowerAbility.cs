using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackEmpowerAbility : IAbility
{
    private UnityEvent _attackCallback;

    private UnityAction Ability = null;

    static bool testing = false;

    private void Update()
    {
        Debug.Log(testing);
    }

    protected override void Start()
    {
        base.Start();

        ReferenceManager.Instance.OnAttack.AddListener(() => testing = true);
        Debug.Log("pocetak");
        //Ability += Testing;
        //_attackCallback?.AddListener(() => Debug.Log("cao brate"));
    }

    // this is Start()
    public override void ActivateAbility()
    {
        base.Start();

        ReferenceManager.Instance.OnAttack.AddListener(() => Debug.Log("molim te"));
    }

    public override void PerformAbility(Player player, Vector3 mousePos)
    {
        Debug.Log("testing:" + testing);

        //ReferenceManager.Instance.OnAttack.Invoke();
        ReferenceManager.Instance.OnAttack.AddListener(() => testing = true);
        ReferenceManager.Instance.OnAttack.AddListener(() => Debug.Log("aaa"));

        Debug.Log("testing:" + testing);

        //Debug.Log("cao");
        //_attackCallback.Invoke();
        //Ability.Invoke();
    }

    private void Testing() => Debug.Log("testing");

    private void OnDestroy()
    {
        // REMOVE LISTENER FROM ONATTACK
    }
}
