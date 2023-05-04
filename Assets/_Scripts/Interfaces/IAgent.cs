using UnityEngine.Events;

public interface IAgent
{
    float Health  { get; }
    bool IsDead { get; }
    UnityEvent OnDeath { get; set; }
    UnityEvent OnGetHit { get; set; }
}
