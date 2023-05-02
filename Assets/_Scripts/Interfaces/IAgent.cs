using UnityEngine.Events;

public interface IAgent
{
    int Health  { get; }
    bool IsDead { get; }
    UnityEvent OnDeath { get; set; }
    UnityEvent OnGetHit { get; set; }
}
