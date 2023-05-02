using UnityEngine;

[CreateAssetMenu(menuName = "Enemies/EnemyData")]
public class EnemyDataSO : ScriptableObject
{
    [field: SerializeField]
    [field: Range(1, 100)]
    public int MaxHealth { get; private set; } = 5;

    [field: SerializeField]
    [field: Range(1, 100)]
    public int Damage { get; private set; } = 1;
}
