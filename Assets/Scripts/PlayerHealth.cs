using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	private PlayerStats _playerStats;
	private HealthSystem _healthSystem;
	
	public int Health => _healthSystem.Health;
	public bool IsDead => Health <= 0;

	[SerializeField] private int _health;
	[SerializeField] private bool _isDead;

	private void Awake()
	{
		_playerStats = GetComponent<PlayerStats>();
		_healthSystem = new HealthSystem();

		_healthSystem.SetMaximumHealth(_playerStats.MaxHealth);
		_healthSystem.SetHealth(_playerStats.StartingHealth);
	}

	private void Update()
	{
		UpdateInspectorValues();
	}

	private void UpdateInspectorValues()
	{
		_health = Health;
		_isDead = IsDead;
	}

	public void TakeDamage(int damageAmount)
	{
		if (IsDead)
		{
			Debug.LogWarning("Player is dead. Shouldn't get damage.");
			return;
		}

		_healthSystem.TakeDamage(damageAmount);
	}

	public void Heal(int healAmount)
	{
		if (IsDead)
		{
			Debug.LogWarning("Player is dead. Shouldn't get heal.");
			return;
		}

		_healthSystem.Heal(healAmount);
	}
}
