using System;

public class HealthSystem
{
	public int MaxHealth { get; private set; }
	public int Health { get; private set; }

	public void SetMaximumHealth(int maxHealth)
	{
		MaxHealth = Math.Max(1, maxHealth);
		Health = Math.Min(Health, MaxHealth);
	}

	public void SetHealth(int health) => Health = Math.Min(Math.Max(health, 0), MaxHealth);

	public void Heal(int healAmount)
	{
		if (healAmount > 0)
			Health = (int)Math.Min((long)Health + healAmount, MaxHealth);
	}

	public void TakeDamage(int damageAmount)
	{
		if (damageAmount > 0)
			Health = (int)Math.Max((long)Health - damageAmount, 0);
	}
}
