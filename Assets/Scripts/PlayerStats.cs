using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	[SerializeField, Min(1)] private int _maxHealth = 100;
	[SerializeField, Min(0)] private int _startingHealth = 100;
	[SerializeField, Min(0f)] private float _damage = 10f;
	[SerializeField, Min(0.01f)] private float _attackInterval = 1f;
	[SerializeField, Min(0f)] private float _attackRange = 5f;

	public int MaxHealth => _maxHealth;
	public int StartingHealth => _startingHealth;
	public float Damage => _damage;
	public float AttackInterval => _attackInterval;
	public float AttackRange => _attackRange;

	private void OnValidate()
	{
		_maxHealth = Mathf.Max(1, _maxHealth);
		_startingHealth = Mathf.Clamp(_startingHealth, 0, _maxHealth);
		_damage = Mathf.Max(0f, _damage);
		_attackInterval = Mathf.Max(0.01f, _attackInterval);
		_attackRange = Mathf.Max(0f, _attackRange);
	}
}
